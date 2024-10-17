using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DESKTOP_II__01_
{
    public partial class QuizForm : Form
    {
        Connection Con = new Connection();
        private Dictionary<int, string> answers = new Dictionary<int, string>();
        private int currentQuestionIndex = 0;
        private List<Question> questions;
        private Timer timer;
        private DateTime startTime;
        private TimeSpan elapsedTime;
        string nickName;
        int QuizId;

        public QuizForm()
        {
            InitializeComponent();
        }

        /*private int GetQuestionCount()
        {
            int count = 0;
            try
            {
                using (SqlConnection con = Con.GetConnection())
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Question WHERE QuizID = @quizId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@quizId", QuizId);
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return count;
        }
*/
        private List<Question> GetQuestions()
        {
            List<Question> questions = new List<Question>();
            try
            {
                using (SqlConnection con = Con.GetConnection())
                {
                    con.Open();
                    string query = "SELECT ID, Question, OptionA, OptionB, OptionC, OptionD, CorrectAnswer FROM Question WHERE QuizID = @quizId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@quizId", QuizId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                questions.Add(new Question
                                {
                                    QuestionId = reader.GetInt32(0),
                                    QuestionText = reader.GetString(1),
                                    OptionA = reader.GetString(2),
                                    OptionB = reader.GetString(3),
                                    OptionC = reader.GetString(4),
                                    OptionD = reader.GetString(5),
                                    CorrectAnswer = reader.GetString(6)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return questions;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int questionIndex = int.Parse(btn.Text) - 1;
            ShowQuestion(questionIndex);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Hitung waktu yang berlalu sejak dimulainya quiz
            elapsedTime = DateTime.Now - startTime;

            // Tampilkan waktu yang berlalu dalam format yang diinginkan
            lblElapsed.Text = $"Elapsed Time: {elapsedTime.Hours:D2}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            // Inisialisasi timer
            timer = new Timer();
            timer.Interval = 1000; // Set interval ke 1 detik (1000 milidetik)
            timer.Tick += Timer_Tick;

            // Atur waktu awal saat form dimuat
            startTime = DateTime.Now;

            // Mulai timer
            timer.Start();

            GuestJoin guestJoin = GuestInfo.GetGuestJoin();
            if (guestJoin != null)
            {
                nickName = guestJoin.NickName;
                QuizId = guestJoin.QuizID;
                lblNickName.Text = nickName;
            }

            questions = GetQuestions();
            int questionCount = questions.Count;

            // Buat tombol dengan teks berupa angka
            for (int i = 0; i < questionCount; i++)
            {
                int index = i; // Simpan indeks saat ini untuk digunakan dalam event handler
                Button btn = new Button
                {
                    Text = (i + 1).ToString(),
                    Width = 30, // Atur lebar tombol
                    Height = 30 // Atur tinggi tombol
                };
                btn.Click += Button_Click;
                flowLayoutPanel.Controls.Add(btn); // flowLayoutPanel adalah panel di mana tombol akan ditampilkan
            }

            if (questionCount > 0)
            {
                ShowQuestion(0);
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                ShowQuestion(currentQuestionIndex - 1);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            // Implementasi logika ketika tombol "Next" diklik
            // Misalnya, lanjut ke pertanyaan berikutnya
            if (currentQuestionIndex < questions.Count - 1)
            {
                ShowQuestion(currentQuestionIndex + 1);
            }
            else
            {
                using (SqlConnection con = Con.GetConnection())
                {
                    con.Open();
                    DialogResult dr = MessageBox.Show("Are you sure you want to submit your answers?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        double elapsedSeconds = elapsedTime.TotalSeconds;
                        SqlTransaction transaction = con.BeginTransaction();
                        try
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO Participant(QuizID, ParticipantNickName, ParticipationDate, TimeTaken) VALUES(@quiz, @name, @date, @time); SELECT SCOPE_IDENTITY();", con, transaction);
                            cmd.Parameters.AddWithValue("@quiz", QuizId);
                            cmd.Parameters.AddWithValue("@name", nickName);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@time", elapsedSeconds);

                            int participantId = Convert.ToInt32(cmd.ExecuteScalar());

                            if (participantId > 0)
                            {
                                foreach (var answer in answers)
                                {
                                    SqlCommand cmdd = new SqlCommand(
                                        "INSERT INTO ParticipantAnswer(ParticipantID, QuestionID, Answer) VALUES(@id, @question, @answer)", con, transaction);
                                    cmdd.Parameters.AddWithValue("@id", participantId);
                                    cmdd.Parameters.AddWithValue("@question", answer.Key);
                                    cmdd.Parameters.AddWithValue("@answer", answer.Value);

                                    cmdd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Thank you for participating, I hope your score is perfect", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            Login l = new Login();
                            l.Show();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void ShowQuestion(int index)
        {
            /*MessageBox.Show($"ShowQuestion called with index: {index}");*/

            if (index < 0 || index >= questions.Count)
            {
                /*MessageBox.Show("Invalid question index!");*/
                return;
            }

            currentQuestionIndex = index;
            Question question = questions[index];

            flowLayoutPanel1.Controls.Clear(); // Bersihkan panel sebelum menambahkan pertanyaan baru
            /*MessageBox.Show("FlowLayoutPanel2 cleared");*/

            Label lblQuestion = new Label
            {
                Text = question.QuestionText,
                AutoSize = true,
                Margin = new Padding(3, 3, 3, 10) // Jarak antara label dan kontrol berikutnya
            };

            RadioButton rbOptionA = new RadioButton
            {
                Text = question.OptionA,
                AutoSize = true,
                Margin = new Padding(3, 3, 3, 3) // Jarak antar RadioButton
            };

            RadioButton rbOptionB = new RadioButton
            {
                Text = question.OptionB,
                AutoSize = true,
                Margin = new Padding(3, 3, 3, 3) // Jarak antar RadioButton
            };

            RadioButton rbOptionC = new RadioButton
            {
                Text = question.OptionC,
                AutoSize = true,
                Margin = new Padding(3, 3, 3, 3) // Jarak antar RadioButton
            };

            RadioButton rbOptionD = new RadioButton
            {
                Text = question.OptionD,
                AutoSize = true,
                Margin = new Padding(3, 3, 3, 3) // Jarak antar RadioButton
            };

            /*// Tambahkan tombol "Previous" dan "Next" di akhir flowLayoutPanel1
            Button btnPrevious = new Button
            {
                Text = "Previous",
                Margin = new Padding(3, 3, 10, 3) // Margin kanan untuk memberikan jarak antara tombol dengan tombol Next
            };

            Button btnNext = new Button
            {
                Text = "Next",
                Margin = new Padding(10, 3, 3, 3) // Margin kiri untuk memberikan jarak antara tombol dengan tombol Previous
            };*/

            // Tambahkan kontrol ke flowLayoutPanel1
            flowLayoutPanel1.Controls.Add(lblQuestion);
            flowLayoutPanel1.Controls.Add(rbOptionA);
            flowLayoutPanel1.Controls.Add(rbOptionB);
            flowLayoutPanel1.Controls.Add(rbOptionC);
            flowLayoutPanel1.Controls.Add(rbOptionD);

            // Isi kontrol dengan jawaban yang disimpan
            if (answers.ContainsKey(question.QuestionId))
            {
                string savedAnswer = answers[question.QuestionId];
                if (savedAnswer == rbOptionA.Text) rbOptionA.Checked = true;
                else if (savedAnswer == rbOptionB.Text) rbOptionB.Checked = true;
                else if (savedAnswer == rbOptionC.Text) rbOptionC.Checked = true;
                else if (savedAnswer == rbOptionD.Text) rbOptionD.Checked = true;
            }

            // Handle jawaban saat opsi dipilih
            // Handle jawaban saat opsi dipilih
            rbOptionA.CheckedChanged += (s, e) => { if (rbOptionA.Checked) answers[question.QuestionId] = rbOptionA.Text; };
            rbOptionB.CheckedChanged += (s, e) => { if (rbOptionB.Checked) answers[question.QuestionId] = rbOptionB.Text; };
            rbOptionC.CheckedChanged += (s, e) => { if (rbOptionC.Checked) answers[question.QuestionId] = rbOptionC.Text; };
            rbOptionD.CheckedChanged += (s, e) => { if (rbOptionD.Checked) answers[question.QuestionId] = rbOptionD.Text; };
            // Atur event handler untuk tombol "Previous" dan "Next"
            /**/

            /*MessageBox.Show("Controls added to FlowLayoutPanel1");*/
            // Buat FlowLayoutPanel untuk menampung tombol Previous dan Next

            flowLayoutPanel2.Controls.Clear();
            // Buat tombol Previous
            Button btnPrevious = new Button
            {
                Text = "Previous",
                Margin = new Padding(3, 3, 10, 3) // Margin kanan untuk memberikan jarak antara tombol dengan tombol Next
            };

            // Buat spacer untuk mengisi ruang kosong
            Control spacer = new Control() 
            { 
                Width = 220, 
                Height = 0, 
                Dock = DockStyle.Fill 
            };

            // Buat tombol Next
            Button btnNext = new Button
            {
                Text = "Next",
                Margin = new Padding(10, 3, 3, 3) // Margin kiri untuk memberikan jarak antara tombol dengan tombol Previous
            };

            // Tambahkan kontrol ke panel tombol
            if (index <= 0)
            {
                btnPrevious.Enabled = false;
            }
            else if (index == questions.Count - 1)
            {
                btnNext.Text = "Finish";
            }

            flowLayoutPanel2.Controls.Add(btnPrevious);
            flowLayoutPanel2.Controls.Add(spacer); // Spacer akan mengisi ruang kosong di tengah
            flowLayoutPanel2.Controls.Add(btnNext);

            btnPrevious.Click += BtnPrevious_Click;
            btnNext.Click += BtnNext_Click;
        }

        public class Question
        {
            public int QuestionId { get; set; }
            public string QuestionText { get; set; }
            public string OptionA { get; set; }
            public string OptionB { get; set; }
            public string OptionC { get; set; }
            public string OptionD { get; set; }
            public string CorrectAnswer { get; set; }
        }
    }
}

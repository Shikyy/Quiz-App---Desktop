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
    public partial class AddQuiz : Form
    {
        Connection Con = new Connection();
        int userId;

        public AddQuiz()
        {
            InitializeComponent();
            /*dgvQ.Columns.Add("No", "No");
            dgvQ.Columns.Add("Question", "Question");
            dgvQ.Columns.Add("OptionA", "OptionA");
            dgvQ.Columns.Add("OptionB", "OptionB");
            dgvQ.Columns.Add("OptionC", "OptionC");
            dgvQ.Columns.Add("OptionD", "OptionD");
            dgvQ.Columns.Add("CorrectAnswer", "CorrectAnswer");
            dgvQ.Columns.Add("Action", "Action");*/

            dgvQ.ColumnCount = 7;
            dgvQ.Columns[0].Name = "No";
            dgvQ.Columns[1].Name = "Question";
            dgvQ.Columns[2].Name = "OptionA";
            dgvQ.Columns[3].Name = "OptionB";
            dgvQ.Columns[4].Name = "OptionC";
            dgvQ.Columns[5].Name = "OptionD";
            dgvQ.Columns[6].Name = "CorrectAnswer";

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Action";
            btnDelete.HeaderText = "Action";
            btnDelete.Text = "DELETE";
            btnDelete.UseColumnTextForButtonValue = true;
            dgvQ.Columns.Add(btnDelete);


        }

        public void refresh()
        {
            txtQn.Text = "";
            txtQc.Text = "";
            txtQd.Text = "";
            txtQ.Text = "";
            txtOa.Text = "";
            txtOb.Text = "";
            txtOc.Text = "";
            txtOd.Text = "";
            Oa.Checked = false;
            Ob.Checked = false;
            Oc.Checked = false;
            Od.Checked = false;
            dgvQ.Rows.Clear();
        }

        public void refresh2()
        {
            txtQ.Text = "";
            txtOa.Text = "";
            txtOb.Text = "";
            txtOc.Text = "";
            txtOd.Text = "";
            Oa.Checked = false;
            Ob.Checked = false;
            Oc.Checked = false;
            Od.Checked = false;
        }

        private void AddQuiz_Load(object sender, EventArgs e)
        {
            LoggedInUser loggedInUser = LoggedInUserInfo.GetLoggedInUser();
            if (loggedInUser != null)
            {
                userId = loggedInUser.ID;
            }
        }

        private void txtQn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtQc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQc_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = txtQc.SelectionStart;
            int selectionLength = txtQc.SelectionLength;

            txtQc.Text = txtQc.Text.ToUpper();

            txtQc.SelectionStart = selectionStart;
            txtQc.SelectionLength = selectionLength;
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            if (txtQ.Text.Equals("") || txtOa.Text.Equals("") || txtOb.Text.Equals("") || txtOc.Text.Equals("") || txtOd.Text.Equals(""))
            {
                MessageBox.Show("Fill the Question with option and a correct answer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Oa.Checked && !Ob.Checked && !Oc.Checked && !Od.Checked)
            {
                MessageBox.Show("Select the correct answer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
            else
            {
                int no = dgvQ.Rows.Count + 1;
                string Question = txtQ.Text;
                string OptionA = txtOa.Text;
                string OptionB = txtOb.Text;
                string OptionC = txtOc.Text;
                string OptionD = txtOd.Text;
                string CorrectAnswer = null;

                if (Oa.Checked == true)
                {
                    CorrectAnswer = txtOa.Text;
                }
                else if (Ob.Checked == true)
                {
                    CorrectAnswer = txtOb.Text;
                }
                else if (Oc.Checked == true)
                {
                    CorrectAnswer = txtOc.Text;
                }
                else if (Od.Checked == true)
                {
                    CorrectAnswer = txtOd.Text;
                }

                string[] row = new string[] { no.ToString(), Question, OptionA, OptionB, OptionC, OptionD, CorrectAnswer};

                dgvQ.Rows.Add(row);
                refresh2();
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void dgvQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvQ.Columns["Action"].Index && e.RowIndex >= 0)
            {
                dgvQ.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            if (txtQn.Text.Equals("") || txtQc.Text.Equals("") || txtQd.Text.Equals(""))
            {
                MessageBox.Show("Fill the Quiz Data", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dgvQ.Rows.Count == 0)
            {
                MessageBox.Show("Add your questions", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                using (SqlConnection con = Con.GetConnection())
                {
                    con.Open();

                    SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM Quiz WHERE Code = @quizCode", con);
                    cmdCheck.Parameters.AddWithValue("@quizCode", txtQc.Text);
                    int quizCheck = (int)cmdCheck.ExecuteScalar();
                    if (quizCheck > 0)
                    {
                        MessageBox.Show("Quiz Code is already used, please choose another one", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlTransaction transaction = con.BeginTransaction();

                        try
                        {
                            // Insert quiz information and get the QuizID
                            SqlCommand cmd = new SqlCommand("INSERT INTO Quiz(UserID, Name, Code, Description, CreatedAt) VALUES(@userid, @name, @code, @descrip, @createdat); SELECT SCOPE_IDENTITY();", con, transaction);
                            cmd.Parameters.AddWithValue("@userid", userId);
                            cmd.Parameters.AddWithValue("@name", txtQn.Text);
                            cmd.Parameters.AddWithValue("@code", txtQc.Text);
                            cmd.Parameters.AddWithValue("@descrip", txtQd.Text);
                            cmd.Parameters.AddWithValue("@createdat", DateTime.Now);

                            int quizId = Convert.ToInt32(cmd.ExecuteScalar());

                            // Iterate over DataGridView rows to insert questions
                            foreach (DataGridViewRow row in dgvQ.Rows)
                            {
                                if (row.IsNewRow) continue;

                                SqlCommand cmdd = new SqlCommand("INSERT INTO Question(QuizID, Question, OptionA, OptionB, OptionC, OptionD, CorrectAnswer) VALUES(@quizId, @question, @optionA, @optionB, @optionC, @optionD, @correctAnswer)", con, transaction);
                                cmdd.Parameters.AddWithValue("@quizId", quizId);
                                cmdd.Parameters.AddWithValue("@question", row.Cells["Question"].Value);
                                cmdd.Parameters.AddWithValue("@optionA", row.Cells["OptionA"].Value);
                                cmdd.Parameters.AddWithValue("@optionB", row.Cells["OptionB"].Value);
                                cmdd.Parameters.AddWithValue("@optionC", row.Cells["OptionC"].Value);
                                cmdd.Parameters.AddWithValue("@optionD", row.Cells["OptionD"].Value);
                                cmdd.Parameters.AddWithValue("@correctAnswer", row.Cells["CorrectAnswer"].Value);

                                cmdd.ExecuteNonQuery();
                                refresh2();
                            }

                            transaction.Commit();
                            MessageBox.Show("Quiz and questions saved successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*Home h = new Home();
                            h.MdiParent = this;
                            h.Dock = DockStyle.Fill;
                            h.Show();*/

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class QuizReport : Form
    {
        Connection Con = new Connection();
        int userId, quizId;

        public QuizReport()
        {
            InitializeComponent();
            /*dgvR.ColumnCount = 3;
            dgvR.Columns[0].Name = "ParticipantNickName";
            dgvR.Columns[1].Name = "TimeTaken";
            dgvR.Columns[2].Name = "CorrectPercentage";*/
            
        }

        private void displaydata(int quizId)
        {
            try
            {
                using (SqlConnection con = Con.GetConnection())
                {
                    con.Open();
                    string query = @"
                SELECT 
                    p.ParticipantNickName, 
                    p.TimeTaken, 
                    COUNT(pa.QuestionID) AS TotalQuestions,
                    SUM(CASE WHEN pa.Answer = q.CorrectAnswer THEN 1 ELSE 0 END) AS CorrectAnswers,
                    (SUM(CASE WHEN pa.Answer = q.CorrectAnswer THEN 1 ELSE 0 END) * 100.0 / COUNT(pa.QuestionID)) AS PercentageCorrect
                FROM 
                    Participant p
                    INNER JOIN ParticipantAnswer pa ON p.ID = pa.ParticipantID
                    INNER JOIN Question q ON pa.QuestionID = q.ID
                WHERE 
                    p.QuizID = @quizId
                GROUP BY 
                    p.ParticipantNickName, 
                    p.TimeTaken";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@quizId", quizId);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "ParticipantResults");

                    dgvR.DataSource = ds.Tables["ParticipantResults"];
                    dgvR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Formatting the PercentageCorrect column
                    dgvR.Columns["PercentageCorrect"].DefaultCellStyle.Format = "0'%'";

                    // Hiding unwanted columns
                    dgvR.Columns["TotalQuestions"].Visible = false;
                    dgvR.Columns["CorrectAnswers"].Visible = false;

                    // Calculate the average PercentageCorrect, average TimeTaken, and ParticipantCount
                    double totalPercentage = 0;
                    double totalTimeTaken = 0;
                    int rowCount = ds.Tables["ParticipantResults"].Rows.Count;

                    foreach (DataRow row in ds.Tables["ParticipantResults"].Rows)
                    {
                        totalPercentage += Convert.ToDouble(row["PercentageCorrect"]);
                        totalTimeTaken += Convert.ToDouble(row["TimeTaken"]);
                    }

                    double averagePercentage = rowCount > 0 ? totalPercentage / rowCount : 0;
                    double averageTimeTaken = rowCount > 0 ? totalTimeTaken / rowCount : 0;

                    TimeSpan averageTimeSpan = TimeSpan.FromSeconds(averageTimeTaken);

                    // Display the calculated values in the labels
                    lblAveragePercentage.Text = $"Average Percentage Correct: {averagePercentage:0.00}%";
                    lblAverageTimeTaken.Text = $"Average Time Taken: {averageTimeSpan:hh\\:mm\\:ss}";
                    lblTotalParticipant.Text = $"Total Participants: {rowCount} participant(s) ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FillComboBox()
        {
            SqlConnection con = Con.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Quiz WHERE UserID = @userId", con);
            cmd.Parameters.AddWithValue("@userId", userId);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            cmbQ.Items.Add("Choose Quiz");
            foreach (DataRow dr in dt.Rows)
            {
                cmbQ.Items.Add(dr["Name"].ToString());
            }
            cmbQ.SelectedIndex = 0;
        }

        private int GetQuizIdByName(string quizName)
        {
            int quizId = -1;
            using (SqlConnection con = Con.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID FROM Quiz WHERE Name = @quizName AND UserID = @userId", con);
                cmd.Parameters.AddWithValue("@quizName", quizName);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    quizId = Convert.ToInt32(reader["ID"]);
                }
                con.Close();
            }
            return quizId;
        }

        private void cmbQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQ.SelectedIndex > 0) // Ignore the first item ("Choose Quiz")
            {
                string selectedQuizName = cmbQ.SelectedItem.ToString();
                int quizId = GetQuizIdByName(selectedQuizName);

                if (quizId != -1)
                {
                    displaydata(quizId);
                }
                else
                {
                    MessageBox.Show("Quiz ID not found.");
                }
            }
        }

        private void QuizReport_Load(object sender, EventArgs e)
        {
            
            LoggedInUser loggedInUser = LoggedInUserInfo.GetLoggedInUser();
            if (loggedInUser != null)
            {
                userId = loggedInUser.ID;
                FillComboBox();
            }
        }
    }
}

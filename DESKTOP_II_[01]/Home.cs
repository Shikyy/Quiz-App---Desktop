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
    public partial class Home : Form
    {
        Connection Con = new Connection();
        int userId;
        string fullName;

        public Home()
        {
            InitializeComponent();
        }

        private void displaydata()
        {
            try
            {
                SqlConnection con = Con.GetConnection();
                con.Open();

                string query = @"SELECT qz.ID as 'QuizID', qz.Name as 'QuizName', qz.Code as 'Code', CAST(qz.Description as varchar(max)) as 'Description', COUNT(q.QuizID) as 'NumberOfQuestion' " +
                    "FROM Quiz qz " +
                    "INNER JOIN Question q ON qz.ID = q.QuizID " +
                    "WHERE qz.UserID = @userId " +
                    "GROUP BY qz.ID, qz.Name, qz.Code, CAST(qz.Description as varchar(max))";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, "Quiz");

                dgvQuiz.DataSource = ds.Tables["Quiz"];
                dgvQuiz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvQuiz.Columns["QuizID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void dgvQuiz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            
            LoggedInUser loggedInUser = LoggedInUserInfo.GetLoggedInUser();
            if (loggedInUser != null)
            {
                userId = loggedInUser.ID;
                fullName = loggedInUser.FullName;
                label1.Text = "Welcome " + fullName;
                displaydata();

                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "Action";
                btnDelete.HeaderText = "Action";
                btnDelete.Text = "DELETE";
                btnDelete.UseColumnTextForButtonValue = true;
                dgvQuiz.Columns.Add(btnDelete);
            }
            else
            {
                MessageBox.Show("Error: User not logged in.");
            }
        }

        private void dgvQuiz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvQuiz.Columns["Action"].Index && e.RowIndex >= 0)
            {
                int quizID = Convert.ToInt32(dgvQuiz.Rows[e.RowIndex].Cells["QuizID"].Value);

                DialogResult dr = MessageBox.Show("Are u sure want to delete this data?", " Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection con = Con.GetConnection();
                        con.Open();
                        
                        SqlCommand cmdQuestion = new SqlCommand("DELETE FROM Question WHERE QuizID = @quizId", con);
                        cmdQuestion.Parameters.AddWithValue("@quizId", quizID);
                        cmdQuestion.ExecuteNonQuery();

                        SqlCommand cmd = new SqlCommand("DELETE FROM Quiz WHERE ID = @quizid", con);
                        cmd.Parameters.AddWithValue("@quizid", quizID);
                        cmd.ExecuteNonQuery();
                        displaydata();
                        MessageBox.Show("Delete succesfull", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void dgvQuiz_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

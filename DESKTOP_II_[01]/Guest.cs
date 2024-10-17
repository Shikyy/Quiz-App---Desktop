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
    public partial class Guest : Form
    {
        Connection Con = new Connection();

        public Guest()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            txtName.Text = "";
            txtCode.Text = "";
        }
        private void btnL_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Equals("") || txtName.Text.Equals(""))
            {
                MessageBox.Show("");
            }
            else
            {
                SqlConnection con = Con.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Quiz WHERE Code = @code", con);
                cmd.Parameters.AddWithValue("@code", txtCode.Text);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int quizId = Convert.ToInt32(dr["ID"].ToString());
                        string name = txtName.Text;
                        string code = dr["Code"].ToString();

                        GuestJoin guestJoin = new GuestJoin(quizId, name, code);

                        GuestInfo.SetGuestInfo(guestJoin);

                        QuizForm qf = new QuizForm();
                        qf.Show();
                        MessageBox.Show("Good luck with the quiz");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Quiz code not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = txtCode.SelectionStart;
            int selectionLength = txtCode.SelectionLength;

            txtCode.Text = txtCode.Text.ToUpper();

            txtCode.SelectionStart = selectionStart;
            txtCode.SelectionLength = selectionLength;
        }
    }
}

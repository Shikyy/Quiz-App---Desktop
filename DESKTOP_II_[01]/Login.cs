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
    public partial class Login : Form
    {
        Connection Con = new Connection();

        public Login()
        {
            InitializeComponent();
            btnL.BackColor = Color.FromArgb(150, 150, 150);
            btnL.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void show_CheckedChanged(object sender, EventArgs e)
        {
            if (show.Checked == true)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register r = new Register();
            r.Show();
            this.Hide();
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals("") || txtPass.Text.Equals(""))
            {
                MessageBox.Show("Enter username and password", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SqlConnection con = Con.GetConnection();
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Username = @user AND Password = @pass", con);
                cmd.Parameters.AddWithValue("@user", txtUser.Text);
                cmd.Parameters.AddWithValue("@pass", Con.HashedPass(txtPass.Text));

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int id = Convert.ToInt32(dr["ID"].ToString());
                        string user = dr["Username"].ToString();
                        string fullName = dr["FullName"].ToString();
                        string date = dr["DateOfBirth"].ToString();

                        LoggedInUser loggedInUser = new LoggedInUser(id, user, fullName, date);

                        LoggedInUserInfo.SetLoggedInUser(loggedInUser);

                        UserMain um = new UserMain();

                        MessageBox.Show("Login success", "Yeay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        um.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Username or password wrong!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void guest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Guest g = new Guest();
            g.Show();
            this.Hide();
        }
    }
}

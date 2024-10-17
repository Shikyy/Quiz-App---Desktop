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
using System.Text.RegularExpressions;

namespace DESKTOP_II__01_
{
    public partial class Register : Form
    {
        Connection Con = new Connection();
        ErrorProvider er = new ErrorProvider();

        public Register()
        {
            InitializeComponent();
            dob.Format = DateTimePickerFormat.Custom;
            dob.CustomFormat = "dddd, dd MMMM yyyy";
            btnR.BackColor = Color.FromArgb(150, 150, 150);
            btnR.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnR_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals("") || txtPass.Text.Equals("") || txtFn.Text.Equals(""))
            {
                MessageBox.Show("Fill the register data", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtPass.Text != txtRp.Text)
            {
                MessageBox.Show("Password doesn't match !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlConnection con = Con.GetConnection();
                con.Open();

                SqlCommand checkcmd = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username = @username", con);
                checkcmd.Parameters.AddWithValue("@username", txtUser.Text);
                int user = (int)checkcmd.ExecuteScalar();
                if (user > 0)
                {
                    MessageBox.Show("Username is already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [User](Username, FullName, DateOfBirth, Password)VALUES(@user, @name, @birth, @pass)", con);
                    cmd.Parameters.AddWithValue("@user", txtUser.Text);
                    cmd.Parameters.AddWithValue("@name", txtFn.Text);
                    cmd.Parameters.AddWithValue("@birth", dob.Value);
                    cmd.Parameters.AddWithValue("@pass", Con.HashedPass(txtPass.Text));

                    int check = cmd.ExecuteNonQuery();

                    if (check > 0)
                    {
                        MessageBox.Show("Register successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login l = new Login();
                        l.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Register failed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtFn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Text.Length < 4)
            {
                er.SetError(textbox, "Password must contains atleast 4 character");
                e.Cancel = true;
            }
            else
            {
                er.SetError(textbox, "");
            }
        }

        private void login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Dispose();
        }
    }
}

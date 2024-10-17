using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKTOP_II__01_
{
    public partial class UserMain : Form
    {
        private int childFormNumber = 0;

        public UserMain()
        {
            InitializeComponent();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.MdiParent = this;
            h.Dock = DockStyle.Fill;
            h.Show();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login l = new Login();
            l.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoutMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login l = new Login();
            l.Show();
        }

        private void homeMenu_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.MdiParent = this;
            h.Dock = DockStyle.Fill;
            h.Show();
        }

        private void addQuizMenu_Click(object sender, EventArgs e)
        {
            AddQuiz aq = new AddQuiz();
            aq.MdiParent = this;
            aq.Dock = DockStyle.Fill;
            aq.Show();
        }

        private void viewQuizReportMenu_Click(object sender, EventArgs e)
        {
            QuizReport qr = new QuizReport();
            qr.MdiParent = this;
            qr.Dock = DockStyle.Fill;
            qr.Show();
        }

        private void UserMain_Load(object sender, EventArgs e)
        {
            Home h = new Home();
            h.MdiParent = this;
            h.Dock = DockStyle.Fill;
            h.Show();
        }
    }
}

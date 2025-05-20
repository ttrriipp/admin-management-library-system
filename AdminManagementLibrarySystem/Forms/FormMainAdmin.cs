using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdminManagementLibrarySystem
{
    public partial class FormMainAdmin : Form
    {
        public FormMainAdmin()
        {
            InitializeComponent();
            show(new FormDashboard());
        }

        void show(Form frm)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            frm.MdiParent = this;
	    frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            show(new FormBooks());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            show(new FormDashboard());
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            show(new FormStudents());

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes){
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                Hide();
            }
        }

        private void FormMainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void FormMainAdmin_Load(object sender, EventArgs e)
        {
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            show(new FormReturnBook());

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            show(new FormIssueBook());

        }
    }
}

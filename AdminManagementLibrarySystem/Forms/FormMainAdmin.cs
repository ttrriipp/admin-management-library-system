using System;
using System.Windows.Forms;

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
                Config.username = "";
                Config.user_id = "";
                Hide();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            show(new FormBookLoans());
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            show(new FormIssueBook());

        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using AdminManagementLibrarySystem.Models;

namespace AdminManagementLibrarySystem
{
    public partial class FormMainAdmin : Form
    {
        public FormMainAdmin()
        {
            InitializeComponent();
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
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {

        }

        private void btnLoan_Click(object sender, EventArgs e)
        {

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
    }
}

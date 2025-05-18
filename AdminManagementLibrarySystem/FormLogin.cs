using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminManagementLibrarySystem
{
    public partial class FormLogin : Form
    {
        MySqlConnection connect = new MySqlConnection("server=localhost;user id=root;password=;database=librarysys");
        MySqlCommand comm;
        MySqlDataReader mdr;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void login()
        {
            if (!string.IsNullOrEmpty(this.txtUsername.Text) && !string.IsNullOrEmpty(this.txtPassword.Text))
            {
                connect.Open();
                string selectque = "SELECT * FROM admin_acc WHERE username = '" + this.txtUsername.Text + "' AND password = '" + this.txtPassword.Text + "'";
                comm = new MySqlCommand(selectque, connect);
                mdr = comm.ExecuteReader();
                if (mdr.HasRows)
                {
                    this.Hide();
                    FormMainAdmin formMainAdmin = new FormMainAdmin();
                    formMainAdmin.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Login Information! Try again.");
                }
            }
            else if (string.IsNullOrEmpty(this.txtUsername.Text) || string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
            }
            connect.Close();
        }

        private void clearFields()
        {
            this.txtUsername.Clear();
            this.txtPassword.Clear();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}

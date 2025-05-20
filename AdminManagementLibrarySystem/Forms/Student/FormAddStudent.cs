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
    public partial class FormAddStudent : Form
    {
        MySqlConnection connect = new MySqlConnection("server=localhost;user id=root;password=;database=librarysys");
        MySqlCommand comm;
        public FormAddStudent()
        {
            InitializeComponent();
        }
        private void addBook()
        {
            if (string.IsNullOrEmpty(this.txtLname.Text) || string.IsNullOrEmpty(this.txtFname.Text) ||
                string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtDept.Text) ||
                string.IsNullOrEmpty(this.txtCourse.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            try
            {
                connect.Open();
                string query = "INSERT INTO `students`(`last_name`, `first_name`, `email`, `department`, `course`) VALUES ('"+this.txtLname.Text+"','"+this.txtFname.Text+"','"+this.txtEmail.Text+"','"+this.txtDept.Text+"','"+this.txtCourse.Text+"')";
                comm = new MySqlCommand(query, connect);
                comm.ExecuteNonQuery();
                MessageBox.Show("Student added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        private void clear()
        {
            this.txtLname.Clear();
            this.txtFname.Clear();
            this.txtEmail.Clear();
            this.txtDept.Clear();
            this.txtCourse.Clear();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            addBook();
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}

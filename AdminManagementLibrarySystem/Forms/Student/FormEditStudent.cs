using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AdminManagementLibrarySystem
{
    public partial class FormEditStudent : Form
    {
        MySqlConnection connect = new MySqlConnection("server=localhost;user id=root;password=;database=librarysys");
        MySqlCommand comm;
        private string id;
        private string lname;
        private string fname;
        private string email;
        private string dept;
        private string course;
        public FormEditStudent(String id, String lname, String fname, String email, String dept, String course)
        {
            InitializeComponent();
            this.id = id;
            this.lname = lname;
            this.fname = fname;
            this.email = email;
            this.dept = dept;
            this.course = course;
        }
        private void updateEdit()
        {
            connect.Open();
            string selectque = "UPDATE `students` SET `last_name`='" + this.lname + "',`first_name`='" + this.fname + "',`email`='" + this.email + "',`department`='" + this.dept + "',`course`='" + this.course + "' WHERE `id` = '" + this.id + "'";
            comm = new MySqlCommand(selectque, connect);
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connect.Close();
        }
        private void editdata()
        {
            if (MessageBox.Show("The data will be update. Confirm?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                updateEdit();
                MessageBox.Show("Student updated successfully!");
            }
            else
            {
                MessageBox.Show("Student not updated!");
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

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            editdata();
        }
        private void FormEditStudent_Load(object sender, EventArgs e)
        {
            this.txtLname.Text = this.lname;
            this.txtFname.Text = this.fname;
            this.txtEmail.Text = this.email;
            this.txtDept.Text = this.dept;
            this.txtCourse.Text = this.course;
        }
    }
}

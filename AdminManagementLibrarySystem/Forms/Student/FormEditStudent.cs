using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AdminManagementLibrarySystem
{
    public partial class FormEditStudent : Form
    {
        MySqlConnection connect = new MySqlConnection(Config.connString);
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

            try
            {
                connect.Open();
                string selectque = "UPDATE `students` SET `last_name`=@lastName, `first_name`=@firstName, `Email`=@email, `department`=@department, `course`=@course WHERE id=@id";
                comm = new MySqlCommand(selectque, connect);
                comm.Parameters.AddWithValue("@lastName", this.txtLname.Text);
                comm.Parameters.AddWithValue("@firstName", this.txtFname.Text);
                comm.Parameters.AddWithValue("@email", this.txtEmail.Text);
                comm.Parameters.AddWithValue("@department", this.txtDept.Text);
                comm.Parameters.AddWithValue("@course", this.txtCourse.Text);
                comm.Parameters.AddWithValue("@id", this.id);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
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

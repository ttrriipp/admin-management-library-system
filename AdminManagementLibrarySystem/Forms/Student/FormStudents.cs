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
    public partial class FormStudents : Form
    {
        MySqlConnection connect = new MySqlConnection("server=localhost;user id=root;password=;database=librarysys");
        MySqlCommand comm;
        string idrow;
        public FormStudents()
        {
            InitializeComponent();
        }
        private void studView()
        {
            Table.style(dgvStudents);
            try
            {
                connect.Open();
                string selectque = "SELECT * FROM `students` WHERE `status`='Active'";
                comm = new MySqlCommand(selectque, connect);
                MySqlDataAdapter da = new MySqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvStudents.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }
        private void setStatus()
        {
            idrow = dgvStudents.SelectedRows[0].Cells[0].Value.ToString();
            connect.Open();
            string selectque = "UPDATE `students` SET `status`='Inactive' WHERE id=@id";
            comm = new MySqlCommand(selectque, connect);
            comm.Parameters.AddWithValue("@id", idrow);
            comm.ExecuteNonQuery();
            connect.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddStudent addStudent = new FormAddStudent();
            addStudent.Show();
            studView();
        }

        private void FormStudents_Load(object sender, EventArgs e)
        {
            studView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to set the status of this student to Inactive?","Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                setStatus();
                MessageBox.Show("Student deactivated successfully!");
                studView();
            }
            else
            {
                MessageBox.Show("Student deactivation cancelled.");
            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            studView();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            String id = dgvStudents.SelectedRows[0].Cells[0].Value.ToString();
            String lname = dgvStudents.SelectedRows[0].Cells[1].Value.ToString();
            String fname = dgvStudents.SelectedRows[0].Cells[2].Value.ToString();
            String email = dgvStudents.SelectedRows[0].Cells[3].Value.ToString();
            String department = dgvStudents.SelectedRows[0].Cells[4].Value.ToString();
            String course = dgvStudents.SelectedRows[0].Cells[5].Value.ToString();
            FormEditStudent FEB = new FormEditStudent(id, lname, fname, email, department, course);
            FEB.Show();
        }
    }
}

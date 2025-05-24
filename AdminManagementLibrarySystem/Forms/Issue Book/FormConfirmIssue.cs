using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdminManagementLibrarySystem
{
    public partial class FormConfirmIssue: Form
    {
        private string dateIssue;
        private string dateDue;
        private string bookId;
        private string title;
        private string author;
        private string ISBN;
        private string category;
        private string studentId;
        private string fullName;
        private string email;
        private string department;
        private string course;
        private string notes;
        MySqlConnection conn;
        MySqlCommand cmd;
        
        public FormConfirmIssue(string[] book, string[] student, string dateIssue, string dateDue, string notes)
        {
            InitializeComponent();
            this.dateIssue = dateIssue;
            this.dateDue = dateDue;
            this.notes = notes;

            // book
            this.bookId = book[0];
            this.title= book[1];
            this.author = book[2];
            this.ISBN = book[3];
            this.category = book[4];

            // student
            this.studentId = student[0];
            this.fullName = student[1];
            this.email = student[2];
            this.department = student[3];
            this.course = student[4];

            conn = new MySqlConnection(Config.connString);
        }
        private void FormConfirmIssue_Load(object sender, EventArgs e)
        {
            // book
            lblBookId.Text += this.bookId;
            lblTitle.Text += this.title;
            lblAuthor.Text += this.author;
            lblISBN.Text += this.ISBN;
            lblCategory.Text += this.category;

            // student
            lblStudentId.Text += this.studentId;
            lblFullName.Text += this.fullName;
            lblEmail.Text += this.email;
            lblDepartment.Text += this.department;
            lblCourse.Text += this.course;

            lblIssue.Text = this.dateIssue;
            lblDue.Text = this.dateDue;
            lblNotes.Text = this.notes;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "INSERT INTO loans (book_id, student_id, issue_date," +
                " due_date, status, issued_by, notes) VALUES (@bookId, @studentId," +
                " @issueDate, @dueDate, 'Active', @issuedBy, @notes)";
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@bookId", this.bookId);
            cmd.Parameters.AddWithValue("@studentId", this.studentId);
            cmd.Parameters.AddWithValue("@issueDate", this.dateIssue);
            cmd.Parameters.AddWithValue("@dueDate", this.dateDue);
            cmd.Parameters.AddWithValue("@issuedBy", Config.user_id);
            cmd.Parameters.AddWithValue("@notes", this.notes);
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Issued Succesfully!");
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return;
            }
            finally
            {
                this.Hide();
            }
        }
    }
}

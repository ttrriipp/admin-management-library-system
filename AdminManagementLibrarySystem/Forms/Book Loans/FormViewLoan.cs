using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdminManagementLibrarySystem
{
    public partial class FormViewLoan: Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;
        private string loanId;
        public FormViewLoan(string loanId)
        {
            InitializeComponent();
            try
            {
                conn = new MySqlConnection(Config.connString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            this.loanId = loanId;
        }
        private void FormConfirmIssue_Load(object sender, EventArgs e)
        {
            string query;
            string[] tables = { "books", "students", "admin_acc" };
            conn = new MySqlConnection(Config.connString);
            conn.Open();

            query = $"SELECT * FROM loans WHERE id = {this.loanId}";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                MessageBox.Show("erawr");
            }

            string bookId = reader["book_id"].ToString();
            string studentId = reader["student_id"].ToString();
            string adminId = reader["issued_by"].ToString();
            this.lblIssueDate.Text += reader["issue_date"].ToString().Remove(10);
            this.lblDueDate.Text += reader["due_date"].ToString().Remove(10);
            this.lblReturnDate.Text += reader["return_date"].ToString();

            if (this.lblReturnDate.Text.Length > 12)
            {
                this.lblReturnDate.Text.Remove(10);
            }
            this.lblStatus.Text += reader["status"].ToString();
            this.lblFineAmount.Text += reader["fine_amount"].ToString();
            this.lblNotes.Text += reader["notes"].ToString();

            MySqlDataReader bookReader = GetData(tables[0], bookId);

            while (bookReader.Read())
            {
                this.lblBookId.Text += bookReader["id"].ToString();
                this.lblTitle.Text += bookReader["title"].ToString();
                this.lblAuthor.Text += bookReader["author"].ToString();
                this.lblISBN.Text += bookReader["ISBN"].ToString();
                this.lblCategory.Text += bookReader["category"].ToString();
            }

            MySqlDataReader studentReader = GetData(tables[1], studentId);
            while (studentReader.Read())
            {
                this.lblStudentId.Text += studentReader["id"].ToString();
                this.lblFullName.Text += studentReader["first_name"].ToString() + " " + studentReader["last_name"].ToString();
                this.lblEmail.Text += studentReader["email"].ToString();
                this.lblDepartment.Text += studentReader["department"].ToString();
                this.lblCourse.Text += studentReader["course"].ToString();
            }

            MySqlDataReader adminReader = GetData(tables[2], adminId);
            while (adminReader.Read())
            {
                this.lblIssuedBy.Text += adminReader["username"].ToString();
            }
        }
        MySqlDataReader GetData(string tableName, string id) 
        {
            conn = new MySqlConnection(Config.connString);
            conn.Open();

            string query = $"SELECT * FROM {tableName} WHERE id = {id}";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            return reader;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

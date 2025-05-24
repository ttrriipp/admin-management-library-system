using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdminManagementLibrarySystem
{
    public partial class FormIssueBook : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;
        MySqlDataAdapter da;
        DataTable dt;
        private string[] tables = { "books", "students" };
        private string activeTable;
        private Timer searchTimer;

        public FormIssueBook()
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
            SelectTable(tables[0]);
        }

        private void FormIssueBook_Load(object sender, EventArgs e)
        {
            ShowSelectedTable();
        }

        void ShowSelectedTable()
        {
            Table.style(dgv);
            conn = new MySqlConnection(Config.connString);
            conn.Open();
            string query;
            switch (activeTable)
            {
                case "books":
                    query = "SELECT id, title, author, ISBN, category, quantity FROM books WHERE status = 'active' AND quantity > 0";
		    da = new MySqlDataAdapter(query, conn);
                    break;
                case "students":
                    query = "SELECT id, last_name, first_name, email, department, course FROM students WHERE status = 'active'";
		    da = new MySqlDataAdapter(query, conn);
                    break;
            }
            dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
        }
        
        void SelectTable(string table)
        {
            activeTable = table;
            switch (activeTable)
            {
                case "books":
                    btnBooks.BackColor = Color.SkyBlue;
                    btnStudents.BackColor = Color.Transparent;
                    lblSearch.Text = "Search Book by ID, Title, or ISBN ";
		    ShowSelectedTable();
                    break;
                case "students":
                    btnBooks.BackColor = Color.Transparent;
                    btnStudents.BackColor = Color.SkyBlue;
                    lblSearch.Text = "Search Student by ID, Name, or Email";
		    ShowSelectedTable();
                    break;
            }
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            SelectTable(tables[0]);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            SelectTable(tables[1]);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (activeTable == "books")
            {
                txtBookId.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
                txtTitle.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
                txtAuthor.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
                txtISBN.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();
                txtCategory.Text = dgv.SelectedRows[0].Cells[4].Value.ToString();
            }
            else if (activeTable == "students")
            {
                txtStudentId.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
                txtLastName.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
                txtFirstName.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
                txtEmail.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();
                txtDepartment.Text = dgv.SelectedRows[0].Cells[4].Value.ToString();
                txtCourse.Text = dgv.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        void ReportIncomplete()
        {
            MessageBox.Show("Please complete all the necessary details.", "Incomplete Details", MessageBoxButtons.OK , MessageBoxIcon.Information);
        }

        bool InputsAreComplete(string issueDate, string dueDate, string[] book, string[] student)
        {
            if (string.IsNullOrEmpty(issueDate) || string.IsNullOrEmpty(dueDate))
            {
                ReportIncomplete();
            }

            foreach (var data in book)
            {
                if (string.IsNullOrEmpty(data))
                {
                    ReportIncomplete();
                    return false;
                }
            }

            foreach (var data in student)
            {
                if (string.IsNullOrEmpty(data))
                {
                    ReportIncomplete();
                    return false;
                }
            }
            return true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            string dateIssue = dtpIssue.Text;
            string dateDue = dtpDue.Text;
            string notes = txtNotes.Text;

            // book
            string bookId = txtBookId.Text;
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string ISBN = txtISBN.Text;
            string category = txtCategory.Text;
            string[] book = { bookId, title, author, ISBN, category };

            // student 
            string studentId = txtStudentId.Text;
            string fullName = $"{txtFirstName.Text} {txtLastName.Text}";
            string email = txtEmail.Text;
            string department = txtDepartment.Text;
            string course = txtCourse.Text;
            string[] student = { studentId, fullName, email, department, course };

            if (InputsAreComplete(dateIssue, dateDue, book, student) && ValidDates(dtpIssue.Value, dtpDue.Value))
            {
                FormConfirmIssue FCI = new FormConfirmIssue(book, student, dateIssue, dateDue, notes);
                FCI.Show();
            }
        }

        void SearchData(string input)
        {
            conn = new MySqlConnection(Config.connString);
            conn.Open();
            string query;
            switch(activeTable)
            {
                case "books":
                    query = "SELECT id, title, author, ISBN, category, quantity " +
                        "FROM books WHERE status = 'active' AND quantity > 0 AND (title LIKE @input OR id LIKE @input OR ISBN LIKE @input)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@input", $"%{input}%");
                    break;
                case "students":
                    query = "SELECT id, last_name, first_name, email, department, course FROM students WHERE status = 'active' AND (last_name " +
                        "LIKE @input OR first_name LIKE @input OR id LIKE @input OR email LIKE @input)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@input", $"%{input}%");
                    break;
            }
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer?.Stop();
            searchTimer = new Timer();
            searchTimer.Interval = 300;
            searchTimer.Tick += (s, args) => {
                SearchData(txtSearch.Text);
                searchTimer.Stop();
            };
            searchTimer.Start();
        }

        private bool ValidDates(DateTime dateIssue, DateTime dateDue)
        {
            if (dateDue < dateIssue)
            {
                MessageBox.Show("Due Date must not be earlier than Issue Date!", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}

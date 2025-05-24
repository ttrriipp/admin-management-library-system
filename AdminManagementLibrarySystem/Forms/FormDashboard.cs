using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdminManagementLibrarySystem
{
    public partial class FormDashboard : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;
        object result;
        private string activeTable;
        private string[] tables = { "recentBooks", "recentIssues" };

        public FormDashboard()
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
            SelectTable(this.tables[0]);
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            string query;
            conn = new MySqlConnection(Config.connString);
            conn.Open();

            query = "SELECT COUNT(*) FROM books WHERE status = 'Active'";
            cmd = new MySqlCommand(query, conn);
            result = cmd.ExecuteScalar();

            if (result != null)
            {
		    this.lblTotalBooks.Text = result.ToString(); 
            }

            query = "SELECT COUNT(*) FROM students WHERE status = 'Active'";
            cmd = new MySqlCommand(query, conn);
            result = cmd.ExecuteScalar();

            if (result != null)
            {
		    this.lblTotalStudents.Text = result.ToString(); 
            }

            query = "SELECT COUNT(*) FROM loans";
            cmd = new MySqlCommand(query, conn);
            result = cmd.ExecuteScalar();
            
            if (result != null)
            {
		    this.lblBooksIssued.Text = result.ToString(); 
            }
        }

        void SelectTable(string table)
        {
            this.activeTable = table;
            switch (this.activeTable)
            {
                case "recentBooks":
                    btnRecentBooks.BackColor = Color.SkyBlue;
                    btnRecentIssues.BackColor = Color.Transparent;
                    ShowSelectedTable();
                    break;
                case "recentIssues":
                    btnRecentBooks.BackColor = Color.Transparent;
                    btnRecentIssues.BackColor = Color.SkyBlue;
                    ShowSelectedTable();
                    break;
            }
        }

        private void btnRecentBooks_Click(object sender, EventArgs e)
        {
            SelectTable(this.tables[0]);
        }

        private void btnRecentIssues_Click(object sender, EventArgs e)
        {
            SelectTable(this.tables[1]);
        }
        void ShowSelectedTable()
        {
            Table.style(dgv);
            conn = new MySqlConnection(Config.connString);
            conn.Open();
            string query;
            switch (this.activeTable)
            {
                case "recentBooks":
                    query = "SELECT id AS 'Book ID', title AS Title, author AS Author, ISBN, category AS Category, quantity AS Quantity FROM books WHERE status = 'active' AND quantity > 0 ORDER BY id DESC";
		    da = new MySqlDataAdapter(query, conn);
                    break;
                case "recentIssues":
                    query = "SELECT loans.id AS 'Loan ID', books.title AS 'Book Title', CONCAT(students.first_name, ' ', students.last_name) AS 'Student Name', issue_date AS 'Issue Date', due_date AS 'Due Date', admin_acc.username AS 'Issued By' FROM loans INNER JOIN books ON loans.book_id = books.id INNER JOIN students ON loans.student_id = students.id INNER JOIN admin_acc ON loans.issued_by = admin_acc.id " +
                        "ORDER BY loans.issue_date DESC";
		    da = new MySqlDataAdapter(query, conn);
                    break;
            }
            dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdminManagementLibrarySystem
{
    public partial class FormBookLoans : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter da;
        DataTable dt;
        MySqlCommand cmd;
        MySqlDataReader reader;
        private string loanId;
        public FormBookLoans()
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
        }


        void ShowTable()
        {
            Table.style(dgvLoans);
            conn = new MySqlConnection(Config.connString);
            conn.Open();
            string query = "SELECT loans.id AS 'Loan ID', books.title AS 'Book Title', CONCAT(students.first_name, ' ', students.last_name) AS 'Student Name', issue_date AS 'Issue Date', due_date AS 'Due Date', admin_acc.username AS 'Issued By', loans.status AS 'Status' FROM loans INNER JOIN books ON loans.book_id = books.id INNER JOIN students ON loans.student_id = students.id INNER JOIN admin_acc ON loans.issued_by = admin_acc.id";
            da = new MySqlDataAdapter(query, conn);
            dt = new DataTable();
            da.Fill(dt);
            checkStatus(dt);
            dgvLoans.DataSource = dt;
        }

        private void checkStatus(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime dueDate = ((DateTime)dt.Rows[i]["Due Date"]).Date;
                string statusCell = dt.Rows[i]["status"].ToString();

                if (statusCell == "Active" && DateTime.Today > dueDate)
                {
                    if (DateTime.Today > dueDate)
                    {
                        dt.Rows[i]["status"] = "Overdue";
                    }
                }
            }
        }
        private void FormBookLoans_Load(object sender, System.EventArgs e)
        {
            ShowTable();
            loanId = dgvLoans.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btnView_Click(object sender, System.EventArgs e)
        {
            FormView FVL = new FormView(loanId);
            FVL.Show();
        }

        private void dgvLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loanId = dgvLoans.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            conn = new MySqlConnection(Config.connString);
            conn.Open();
            string query = "SELECT loans.id AS 'Loan ID', books.title AS 'Book Title', CONCAT(students.first_name, ' ', students.last_name) AS 'Student Name', issue_date AS 'Issue Date', due_date AS 'Due Date', admin_acc.username AS 'Issued By', loans.status AS 'Status' FROM loans INNER JOIN books ON loans.book_id = books.id INNER JOIN students ON loans.student_id = students.id INNER JOIN admin_acc ON loans.issued_by = admin_acc.id " +
                " WHERE loans.id = @id OR books.title LIKE @search OR students.first_name LIKE @search OR students.last_name LIKE @search OR loans.issued_by LIKE @search OR loans.status LIKE @search";
            cmd = new MySqlCommand(query, conn);
            string searchValue = txtSearch.Text.Trim();
            cmd.Parameters.AddWithValue("@id", searchValue);
            cmd.Parameters.AddWithValue("@search", $"%{searchValue}%"); 
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvLoans.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            ShowTable();
            txtSearch.Text = "";
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            FormEdit fr = new FormEdit(loanId);
            fr.Show();
        }

        private void DgvLoans_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLoans.Columns[e.ColumnIndex].Name == "Status")
            {
                string status = e.Value?.ToString();
                switch (status)
                {
                    case "Active":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        break;
                    case "Overdue":
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.DarkRed;
                        break;
                    case "Lost":
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.DarkRed;
                        break;
                    case "Returned":
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.DarkSlateGray;
                        break;
                }
            }
        }
    }
}

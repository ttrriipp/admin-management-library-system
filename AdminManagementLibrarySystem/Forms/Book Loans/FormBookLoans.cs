using System.Data;
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
            string query = "SELECT loans.id AS 'Loan ID', books.title AS 'Book Title', CONCAT(students.first_name, ' ', students.last_name) AS 'Student Name', issue_date AS 'Issue Date', due_date AS 'Due Date', admin_acc.username AS 'Issued By' FROM loans INNER JOIN books ON loans.book_id = books.id INNER JOIN students ON loans.student_id = students.id INNER JOIN admin_acc ON loans.issued_by = admin_acc.id";
            da = new MySqlDataAdapter(query, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvLoans.DataSource = dt;
        }

        private void FormBookLoans_Load(object sender, System.EventArgs e)
        {
            ShowTable();
            loanId =  dgvLoans.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btnView_Click(object sender, System.EventArgs e)
        {
            FormViewLoan FVL = new FormViewLoan(loanId);
            FVL.Show();
        }

        private void dgvLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loanId =  dgvLoans.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btnReturn_Click(object sender, System.EventArgs e)
        {
            FormReturn fr = new FormReturn(loanId);
            fr.Show();
        }
    }
}

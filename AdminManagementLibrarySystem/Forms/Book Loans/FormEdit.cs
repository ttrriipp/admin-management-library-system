using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdminManagementLibrarySystem
{
    public partial class FormEdit: Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;
        private string loanId;
        public FormEdit(string loanId)
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
            this.txtNotes.Text = reader["notes"].ToString();
            DateTime issueDate = (DateTime)reader["issue_date"];
            DateTime dueDate = (DateTime)reader["due_date"];
            this.dtpIssueDate.Value = issueDate;
            this.dtpDueDate.Value = dueDate;

            if (!string.IsNullOrEmpty(reader["return_date"].ToString()))
            {
                DateTime returnDate = (DateTime)reader["return_date"];
                this.dtpReturnDate.Value = returnDate;
            }

            this.txtFineAmount.Text = CalculateFineAmount(reader["fine_amount"].ToString(), dueDate);
            this.cmbStatus.Text = reader["status"].ToString();

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
                this.txtIssuedBy.Text = adminReader["username"].ToString();
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem.ToString() == "Returned")
            {
                dtpReturnDate.Enabled = true;
            }
            else
                dtpReturnDate.Enabled = false;

        }

        // Fine rate is 100
        private string CalculateFineAmount(string initialFineAmount, DateTime dueDate)
        {
            bool fineAmountIsSet = Double.TryParse(initialFineAmount, out double result);
            if (fineAmountIsSet && result != 0.00)
            {
                return initialFineAmount;
            }
            double daysDifference = (int)(DateTime.Now - dueDate).TotalDays;
            string calculatedFineAmount = (daysDifference * 100.00).ToString();
            return calculatedFineAmount;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpDueDate.Value < dtpIssueDate.Value)
            {
                MessageBox.Show("Due Date must not be earlier than Issue Date!", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool FineAmountInputIsValid = double.TryParse(txtFineAmount.Text, out double fineAmount);
            if (!FineAmountInputIsValid)
            {
                MessageBox.Show("Fine amount must be a valid number!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
            conn = new MySqlConnection(Config.connString);
            conn.Open();
            string query;
            query = "UPDATE loans SET issue_date = @issueDate, due_date = @dueDate, return_date = @returnDate, status = @status, " +
                "fine_amount = @fineAmount, notes = @notes WHERE id = @id";

            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", this.loanId);
            cmd.Parameters.AddWithValue("@issueDate", dtpIssueDate.Text);
            cmd.Parameters.AddWithValue("@dueDate", dtpDueDate.Text);
            if (dtpReturnDate.Enabled)
            {
                cmd.Parameters.AddWithValue("@returnDate", dtpReturnDate.Text);
                if (dtpReturnDate.Value < dtpIssueDate.Value || dtpReturnDate.Value < dtpDueDate.Value)
                    {
                        MessageBox.Show("Return Date must not be earlier than Issue Date or Return Date!", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
	    else
            {
                cmd.Parameters.AddWithValue("@returnDate", null);
            }
            cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
            cmd.Parameters.AddWithValue("@fineAmount", txtFineAmount.Text);
            cmd.Parameters.AddWithValue("@notes", txtNotes.Text);
	    if (cmd.ExecuteNonQuery() > 0)
	    {
	        MessageBox.Show("Updated Succesfully!");
	    }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return;
            }
            this.Hide();
        }
    }
}

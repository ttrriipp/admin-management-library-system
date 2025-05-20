using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminManagementLibrarySystem.Models;
using MySql.Data.MySqlClient;

namespace AdminManagementLibrarySystem
{
    public partial class FormIssueBook : Form
    {
        private string connString = "server=localhost;user id=root;password=;database=librarysys";
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;
        MySqlDataAdapter da;
        DataTable dt;

        public FormIssueBook()
        {
            InitializeComponent();
            try
            {
                conn = new MySqlConnection(connString);
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

        private void txtSearchBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            string input = txtSearchBook.Text;




        }

        void style(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.LightGray;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.RowTemplate.Height = 35;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToResizeRows = false;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
        }

        private void FormIssueBook_Load(object sender, EventArgs e)
        {
            style(dgvBooks);
            conn = new MySqlConnection(connString);
            conn.Open();

            string qry = "SELECT * FROM books WHERE quantity > 0";

	    da = new MySqlDataAdapter(qry, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvBooks.DataSource = dt;
        }
    }
}

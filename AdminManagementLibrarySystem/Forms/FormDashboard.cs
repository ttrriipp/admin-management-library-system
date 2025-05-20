using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdminManagementLibrarySystem
{
    public partial class FormDashboard : Form
    {
        private string connString = "server=localhost;user id=root;password=;database=librarysys";
        MySqlConnection conn;
        MySqlCommand cmd;
        object result;
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connString);
            conn.Open();

            string query = "SELECT COUNT(*) FROM books";
            cmd = new MySqlCommand(query, conn);
            result = cmd.ExecuteScalar();
            if (result != null)
            {
		    this.lblTotalBooks.Text = result.ToString(); 
            }
        }
    }
}

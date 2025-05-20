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
    public partial class FormBooks : Form
    {
        MySqlConnection connect = new MySqlConnection("server=localhost;user id=root;password=;database=librarysys");
        MySqlCommand comm;
        MySqlDataReader mdr;
        int selectedRow, idrow;
        public FormBooks()
        {
            InitializeComponent();
        }
        private void view()
        {
            try
            {
                connect.Open();
                string selectque = "SELECT * FROM books";
                comm = new MySqlCommand(selectque, connect);
                MySqlDataAdapter da = new MySqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);

                bookGrid.DataSource = ds.Tables[0];
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
        private void update()
        {
            connect.Open();
            string selectque = "UPDATE `books` SET `title`='"+this.txtTitle2.Text+"',`author`='"+this.txtAuthor2.Text+ "',`ISBN`='"+this.txtISBN2.Text+ "',`category`='"+this.category2.Text+ "',`quantity`='"+this.txtQuantity2.Text+"' where book_id = '"+idrow+"'";
            comm = new MySqlCommand(selectque, connect);
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connect.Close();
        }

        private void removedata()
        {
            connect.Open();
            string selectque = "DELETE FROM `books` WHERE book_id = '" + idrow + "'";
            comm = new MySqlCommand(selectque, connect);
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connect.Close();
        }
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            FormAddBook addBookForm = new FormAddBook();
            addBookForm.Show();
        }

        private void FormBooks_Load(object sender, EventArgs e)
        {
            view();
        }
        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            view();
            txtSearch.Clear();
        }

        private void bookGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.bookGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookGrid_CellClick);
            if (bookGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                selectedRow = int.Parse(bookGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            paneEdit.Visible = true;
            connect.Open();

            string selectque = "SELECT * FROM books where book_id ='"+selectedRow+"'";
            comm = new MySqlCommand(selectque, connect);
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);

            bookGrid.DataSource = ds.Tables[0];

            idrow = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtTitle2.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuthor2.Text = ds.Tables[0].Rows[0][2].ToString();
            txtISBN2.Text = ds.Tables[0].Rows[0][3].ToString();
            category2.Text = ds.Tables[0].Rows[0][4].ToString();
            txtQuantity2.Text = ds.Tables[0].Rows[0][5].ToString();
            txtQuantity2.Text = ds.Tables[0].Rows[0][5].ToString();

            connect.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            paneEdit.Visible = false;
            view();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            try
            {
                connect.Open();
                string query;
                if (string.IsNullOrEmpty(searchValue))
                {
                    query = "SELECT * FROM books";
                    comm = new MySqlCommand(query, connect);
                }
                else
                {
                    query = "SELECT * FROM books WHERE title LIKE @search OR author LIKE @search OR ISBN LIKE @search OR category LIKE @search";
                    comm = new MySqlCommand(query, connect);
                    comm.Parameters.AddWithValue("@search", "%" + searchValue + "%");
                }
                MySqlDataAdapter da = new MySqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);

                bookGrid.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("The data will be update. Confirm?", "Success", MessageBoxButtons.YesNo,MessageBoxIcon.Question) ==DialogResult.Yes)
            {
                update();
                view();
                paneEdit.Visible = false;
                MessageBox.Show("Book updated successfully!");
            }
            else
            {
                MessageBox.Show("Book not updated!");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want this book to be deleted?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                removedata();
                view();
                paneEdit.Visible = false;
                MessageBox.Show("Book deleted successfully!");
            }
            else
            {
                MessageBox.Show("Book not deleted!");
            }
        }
    }
}

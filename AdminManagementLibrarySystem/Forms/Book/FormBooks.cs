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
        string idrow;
        public FormBooks()
        {
            InitializeComponent();
        }
        private void view()
        {
            try
            {
                Table.style(bookGrid);
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

        private void removedata()
        {
            idrow = bookGrid.SelectedRows[0].Cells[0].Value.ToString();
            connect.Open();
            string selectque = "DELETE FROM `books` WHERE id = '" + idrow + "'";
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            String id = bookGrid.SelectedRows[0].Cells[0].Value.ToString();
            String title = bookGrid.SelectedRows[0].Cells[1].Value.ToString();
            String author = bookGrid.SelectedRows[0].Cells[2].Value.ToString();
            String ISBN = bookGrid.SelectedRows[0].Cells[3].Value.ToString();
            String category = bookGrid.SelectedRows[0].Cells[4].Value.ToString();
            String quantity = bookGrid.SelectedRows[0].Cells[5].Value.ToString();
            FormEditBook FEB = new FormEditBook(id, title, author, ISBN, category, quantity);
            FEB.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want this book to be deleted?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                removedata();
                view();
                MessageBox.Show("Book deleted successfully!");
            }
            else
            {
                MessageBox.Show("Book not deleted!");
            }
        }
    }
}

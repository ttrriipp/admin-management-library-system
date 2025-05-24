using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AdminManagementLibrarySystem
{
    public partial class FormEditBook : Form
    {
        MySqlConnection connect = new MySqlConnection(Config.connString);
        MySqlCommand comm;
        private string id;
        private string title;
        private string author;
        private string ISBN;
        private string category;
        private string copies;

        public FormEditBook(String id, String title, String author, String ISBN, String category, String copies)
        {
            InitializeComponent();
            this.id = id;
            this.title = title;
            this.author = author;
            this.ISBN = ISBN;
            this.category = category;
            this.copies = copies;
        }

        private void clear()
        {
            this.txtTitle.Clear();
            this.txtAuthor.Clear();
            this.txtISBN.Clear();
            this.valCategory.SelectedIndex = -1;
            this.txtQuantity.Clear();   
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The data will be update. Confirm?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                update();
                MessageBox.Show("Book updated successfully!");

            }
            else
            {
                MessageBox.Show("Book not updated!");
            }
        }
        private void update()
        {
            try
            {
                connect.Open();
                string selectque = "UPDATE `books` SET `title`=@title, `author`=@author, `ISBN`=@isbn, `category`=@category, `quantity`=@quantity WHERE id=@id";
                comm = new MySqlCommand(selectque, connect);
                comm.Parameters.AddWithValue("@title", this.txtTitle.Text);
                comm.Parameters.AddWithValue("@author", this.txtAuthor.Text);
                comm.Parameters.AddWithValue("@isbn", this.txtISBN.Text);
                comm.Parameters.AddWithValue("@category", this.valCategory.Text);
                comm.Parameters.AddWithValue("@quantity", this.txtQuantity.Text);
                comm.Parameters.AddWithValue("@id", this.id);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }


        private void FormEditBook_Load(object sender, EventArgs e)
        {
            this.txtTitle.Text = this.title;
            this.txtAuthor.Text = this.author;
            this.txtISBN.Text = this.ISBN;
            this.valCategory.Text = this.category;
            this.txtQuantity.Text = this.copies;
        }
    }
}

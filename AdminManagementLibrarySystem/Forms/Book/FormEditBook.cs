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
            connect.Open();
            string selectque = "UPDATE `books` SET `title`='" + this.title + "',`author`='" + this.author + "',`ISBN`='" + this.ISBN + "',`category`='" + this.category + "',`quantity`='" + this.copies + "' where id = '" + this.id + "'";
            comm = new MySqlCommand(selectque, connect);
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connect.Close();
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

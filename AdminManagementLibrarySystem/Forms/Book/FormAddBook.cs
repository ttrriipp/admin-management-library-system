﻿using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AdminManagementLibrarySystem
{
    public partial class FormAddBook : Form
    {
        MySqlConnection connect = new MySqlConnection(Config.connString);
        MySqlCommand comm;
        public FormAddBook()
        {
            InitializeComponent();
        }
        private void addBook()
        {
            if (string.IsNullOrEmpty(this.txtTitle.Text) || string.IsNullOrEmpty(this.txtAuthor.Text) ||
                string.IsNullOrEmpty(this.txtISBN.Text) || string.IsNullOrEmpty(this.category.Text) ||
                string.IsNullOrEmpty(this.txtQuantity.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (!int.TryParse(this.txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid number for quantity.");
                return;
            }
            try
            {
                connect.Open();
                string query = "INSERT INTO `books`(`title`, `author`, `ISBN`, `category`, `quantity`) VALUES ('"+this.txtTitle.Text+ "', '"+this.txtAuthor.Text+ "', '"+this.txtISBN.Text+"', '" + this.category.Text + "', '" + this.txtQuantity.Text + "')";
                comm = new MySqlCommand(query, connect);
                comm.ExecuteNonQuery();
                MessageBox.Show("Book added successfully!");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        private void clear()
        {
            this.txtTitle.Clear();
            this.txtAuthor.Clear();
            this.txtISBN.Clear();
            this.category.SelectedIndex = -1;
            this.txtQuantity.Clear();   
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            addBook();
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}

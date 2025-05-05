using System;
using System.Windows.Forms;
using AdminManagementLibrarySystem.Models;

namespace AdminManagementLibrarySystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin("asdad", "asjkfdhnas");
        }
    }
}

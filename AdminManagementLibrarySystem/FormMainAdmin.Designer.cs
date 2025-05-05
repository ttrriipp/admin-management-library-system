namespace AdminManagementLibrarySystem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnManageBooks = new System.Windows.Forms.Button();
            this.btnIssueReturn = new System.Windows.Forms.Button();
            this.btnCheckOutBooks = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnManageUsers);
            this.panel1.Controls.Add(this.btnCheckOutBooks);
            this.panel1.Controls.Add(this.btnIssueReturn);
            this.panel1.Controls.Add(this.btnManageBooks);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 831);
            this.panel1.TabIndex = 0;
            // 
            // btnManageBooks
            // 
            this.btnManageBooks.Location = new System.Drawing.Point(0, 255);
            this.btnManageBooks.Name = "btnManageBooks";
            this.btnManageBooks.Size = new System.Drawing.Size(365, 69);
            this.btnManageBooks.TabIndex = 0;
            this.btnManageBooks.Text = "Manage Books";
            this.btnManageBooks.UseVisualStyleBackColor = true;
            // 
            // btnIssueReturn
            // 
            this.btnIssueReturn.Location = new System.Drawing.Point(0, 319);
            this.btnIssueReturn.Name = "btnIssueReturn";
            this.btnIssueReturn.Size = new System.Drawing.Size(365, 69);
            this.btnIssueReturn.TabIndex = 1;
            this.btnIssueReturn.Text = "Issue/Return Books";
            this.btnIssueReturn.UseVisualStyleBackColor = true;
            // 
            // btnCheckOutBooks
            // 
            this.btnCheckOutBooks.Location = new System.Drawing.Point(0, 381);
            this.btnCheckOutBooks.Name = "btnCheckOutBooks";
            this.btnCheckOutBooks.Size = new System.Drawing.Size(365, 69);
            this.btnCheckOutBooks.TabIndex = 2;
            this.btnCheckOutBooks.Text = "Checked Out Books";
            this.btnCheckOutBooks.UseVisualStyleBackColor = true;
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Location = new System.Drawing.Point(0, 447);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(365, 69);
            this.btnManageUsers.TabIndex = 3;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(-3, 703);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(365, 69);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Manage Users";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 831);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnCheckOutBooks;
        private System.Windows.Forms.Button btnIssueReturn;
        private System.Windows.Forms.Button btnManageBooks;
        private System.Windows.Forms.Button btnLogout;
    }
}


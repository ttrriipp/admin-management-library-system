namespace AdminManagementLibrarySystem
{
    partial class FormDashboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTotalBooks = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblBooksIssued = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRecentBooks = new System.Windows.Forms.Button();
            this.btnRecentIssues = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.label1.Location = new System.Drawing.Point(17, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTotalBooks);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(21, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 161);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AdminManagementLibrarySystem.Properties.Resources.book_open_blank_variant_outline;
            this.pictureBox1.Location = new System.Drawing.Point(284, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.AutoSize = true;
            this.lblTotalBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.lblTotalBooks.Location = new System.Drawing.Point(16, 66);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(108, 55);
            this.lblTotalBooks.TabIndex = 1;
            this.lblTotalBooks.Text = "000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.label3.Location = new System.Drawing.Point(20, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Books";
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblTotalStudents);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(423, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 161);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AdminManagementLibrarySystem.Properties.Resources.school_outline;
            this.pictureBox2.Location = new System.Drawing.Point(284, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.lblTotalStudents.Location = new System.Drawing.Point(16, 66);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(108, 55);
            this.lblTotalStudents.TabIndex = 1;
            this.lblTotalStudents.Text = "000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.label6.Location = new System.Drawing.Point(20, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 32);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total Students";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.lblBooksIssued);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(819, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(368, 161);
            this.panel3.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::AdminManagementLibrarySystem.Properties.Resources.autorenew;
            this.pictureBox3.Location = new System.Drawing.Point(284, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 39);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // lblBooksIssued
            // 
            this.lblBooksIssued.AutoSize = true;
            this.lblBooksIssued.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooksIssued.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.lblBooksIssued.Location = new System.Drawing.Point(16, 66);
            this.lblBooksIssued.Name = "lblBooksIssued";
            this.lblBooksIssued.Size = new System.Drawing.Size(108, 55);
            this.lblBooksIssued.TabIndex = 1;
            this.lblBooksIssued.Text = "000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.label8.Location = new System.Drawing.Point(20, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 32);
            this.label8.TabIndex = 0;
            this.label8.Text = "Books Issued";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.panel4.Controls.Add(this.btnRecentBooks);
            this.panel4.Controls.Add(this.btnRecentIssues);
            this.panel4.Location = new System.Drawing.Point(21, 352);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(389, 70);
            this.panel4.TabIndex = 5;
            // 
            // btnRecentBooks
            // 
            this.btnRecentBooks.BackColor = System.Drawing.Color.Transparent;
            this.btnRecentBooks.FlatAppearance.BorderSize = 0;
            this.btnRecentBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecentBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecentBooks.ForeColor = System.Drawing.Color.White;
            this.btnRecentBooks.Location = new System.Drawing.Point(3, 4);
            this.btnRecentBooks.Name = "btnRecentBooks";
            this.btnRecentBooks.Size = new System.Drawing.Size(184, 63);
            this.btnRecentBooks.TabIndex = 0;
            this.btnRecentBooks.Text = "Recent Books";
            this.btnRecentBooks.UseVisualStyleBackColor = false;
            this.btnRecentBooks.Click += new System.EventHandler(this.btnRecentBooks_Click);
            // 
            // btnRecentIssues
            // 
            this.btnRecentIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            this.btnRecentIssues.FlatAppearance.BorderSize = 0;
            this.btnRecentIssues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecentIssues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecentIssues.ForeColor = System.Drawing.Color.White;
            this.btnRecentIssues.Location = new System.Drawing.Point(193, 4);
            this.btnRecentIssues.Name = "btnRecentIssues";
            this.btnRecentIssues.Size = new System.Drawing.Size(193, 63);
            this.btnRecentIssues.TabIndex = 0;
            this.btnRecentIssues.Text = "Recent Issues";
            this.btnRecentIssues.UseVisualStyleBackColor = false;
            this.btnRecentIssues.Click += new System.EventHandler(this.btnRecentIssues_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(21, 453);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 72;
            this.dgv.RowTemplate.Height = 31;
            this.dgv.Size = new System.Drawing.Size(1167, 426);
            this.dgv.TabIndex = 6;
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(251)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1200, 900);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashboard";
            this.Text = "FormDashboard";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Label label3;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblBooksIssued;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRecentBooks;
        private System.Windows.Forms.Button btnRecentIssues;
        private System.Windows.Forms.DataGridView dgv;
    }
}
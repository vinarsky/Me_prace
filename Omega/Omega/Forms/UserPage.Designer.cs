
namespace Omega
{
    partial class UserPage
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
            this.UserName = new System.Windows.Forms.Label();
            this.UnderLine = new System.Windows.Forms.TextBox();
            this.UserAccess = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.TelnumBox = new System.Windows.Forms.NumericUpDown();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.FirstnameBox = new System.Windows.Forms.TextBox();
            this.LastnameBox = new System.Windows.Forms.TextBox();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.CommitChanges = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TelnumBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.Location = new System.Drawing.Point(12, 9);
            this.UserName.MaximumSize = new System.Drawing.Size(280, 21);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(61, 21);
            this.UserName.TabIndex = 0;
            this.UserName.Text = "label1";
            // 
            // UnderLine
            // 
            this.UnderLine.BackColor = System.Drawing.Color.Black;
            this.UnderLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UnderLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnderLine.Location = new System.Drawing.Point(16, 33);
            this.UnderLine.Name = "UnderLine";
            this.UnderLine.Size = new System.Drawing.Size(290, 2);
            this.UnderLine.TabIndex = 5;
            // 
            // UserAccess
            // 
            this.UserAccess.AutoSize = true;
            this.UserAccess.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserAccess.Location = new System.Drawing.Point(12, 38);
            this.UserAccess.MaximumSize = new System.Drawing.Size(280, 21);
            this.UserAccess.Name = "UserAccess";
            this.UserAccess.Size = new System.Drawing.Size(64, 21);
            this.UserAccess.TabIndex = 6;
            this.UserAccess.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.CommitChanges);
            this.panel1.Location = new System.Drawing.Point(13, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 375);
            this.panel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(376, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(360, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tel. číslo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(375, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Heslo:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.PasswordBox);
            this.flowLayoutPanel2.Controls.Add(this.TelnumBox);
            this.flowLayoutPanel2.Controls.Add(this.EmailBox);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(421, 47);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(106, 183);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // PasswordBox
            // 
            this.PasswordBox.BackColor = System.Drawing.SystemColors.Control;
            this.PasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordBox.Location = new System.Drawing.Point(3, 3);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordBox.TabIndex = 0;
            // 
            // TelnumBox
            // 
            this.TelnumBox.BackColor = System.Drawing.SystemColors.Control;
            this.TelnumBox.Location = new System.Drawing.Point(3, 66);
            this.TelnumBox.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.TelnumBox.Name = "TelnumBox";
            this.TelnumBox.Size = new System.Drawing.Size(100, 20);
            this.TelnumBox.TabIndex = 15;
            // 
            // EmailBox
            // 
            this.EmailBox.BackColor = System.Drawing.SystemColors.Control;
            this.EmailBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmailBox.Location = new System.Drawing.Point(3, 129);
            this.EmailBox.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(100, 20);
            this.EmailBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(18, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Uživatelské jméno:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(70, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Příjmení:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Jméno:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.FirstnameBox);
            this.flowLayoutPanel1.Controls.Add(this.LastnameBox);
            this.flowLayoutPanel1.Controls.Add(this.UsernameBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(130, 47);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(106, 183);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // FirstnameBox
            // 
            this.FirstnameBox.BackColor = System.Drawing.SystemColors.Control;
            this.FirstnameBox.Location = new System.Drawing.Point(3, 3);
            this.FirstnameBox.Name = "FirstnameBox";
            this.FirstnameBox.Size = new System.Drawing.Size(100, 20);
            this.FirstnameBox.TabIndex = 0;
            // 
            // LastnameBox
            // 
            this.LastnameBox.BackColor = System.Drawing.SystemColors.Control;
            this.LastnameBox.Location = new System.Drawing.Point(3, 66);
            this.LastnameBox.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.LastnameBox.Name = "LastnameBox";
            this.LastnameBox.Size = new System.Drawing.Size(100, 20);
            this.LastnameBox.TabIndex = 2;
            // 
            // UsernameBox
            // 
            this.UsernameBox.BackColor = System.Drawing.SystemColors.Control;
            this.UsernameBox.Location = new System.Drawing.Point(3, 129);
            this.UsernameBox.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(100, 20);
            this.UsernameBox.TabIndex = 3;
            // 
            // CommitChanges
            // 
            this.CommitChanges.Location = new System.Drawing.Point(133, 256);
            this.CommitChanges.Name = "CommitChanges";
            this.CommitChanges.Size = new System.Drawing.Size(100, 23);
            this.CommitChanges.TabIndex = 6;
            this.CommitChanges.Text = "Provézt změny";
            this.CommitChanges.UseVisualStyleBackColor = true;
            this.CommitChanges.Click += new System.EventHandler(this.CommitChanges_Click);
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UserAccess);
            this.Controls.Add(this.UnderLine);
            this.Controls.Add(this.UserName);
            this.Name = "UserPage";
            this.Tag = "Uživatel";
            this.Load += new System.EventHandler(this.UserPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TelnumBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox UnderLine;
        private System.Windows.Forms.Label UserAccess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox FirstnameBox;
        private System.Windows.Forms.TextBox LastnameBox;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Button CommitChanges;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox EmailBox;
        public System.Windows.Forms.Label UserName;
        private System.Windows.Forms.NumericUpDown TelnumBox;
    }
}
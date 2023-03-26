
namespace Omega
{
    partial class MainPage
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
            this.NavPanel = new System.Windows.Forms.Panel();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.RoomButton = new System.Windows.Forms.Button();
            this.GuestButton = new System.Windows.Forms.Button();
            this.EmployeeButton = new System.Windows.Forms.Button();
            this.UserButton = new System.Windows.Forms.Button();
            this.NewResButton = new System.Windows.Forms.Button();
            this.OverviewButton = new System.Windows.Forms.Button();
            this.MainContent = new System.Windows.Forms.Panel();
            this.Header = new System.Windows.Forms.Label();
            this.NavPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NavPanel
            // 
            this.NavPanel.BackColor = System.Drawing.Color.White;
            this.NavPanel.Controls.Add(this.LogoutButton);
            this.NavPanel.Controls.Add(this.ExitButton);
            this.NavPanel.Controls.Add(this.RoomButton);
            this.NavPanel.Controls.Add(this.GuestButton);
            this.NavPanel.Controls.Add(this.EmployeeButton);
            this.NavPanel.Controls.Add(this.UserButton);
            this.NavPanel.Controls.Add(this.NewResButton);
            this.NavPanel.Controls.Add(this.OverviewButton);
            this.NavPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavPanel.Location = new System.Drawing.Point(0, 0);
            this.NavPanel.Name = "NavPanel";
            this.NavPanel.Size = new System.Drawing.Size(231, 561);
            this.NavPanel.TabIndex = 0;
            // 
            // LogoutButton
            // 
            this.LogoutButton.BackColor = System.Drawing.Color.White;
            this.LogoutButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogoutButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.LogoutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.Location = new System.Drawing.Point(0, 483);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(231, 68);
            this.LogoutButton.TabIndex = 11;
            this.LogoutButton.Text = "Odhlásit";
            this.LogoutButton.UseVisualStyleBackColor = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.White;
            this.ExitButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(0, 415);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(231, 68);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Vypnout";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // RoomButton
            // 
            this.RoomButton.BackColor = System.Drawing.Color.White;
            this.RoomButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RoomButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RoomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RoomButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomButton.Location = new System.Drawing.Point(0, 344);
            this.RoomButton.Name = "RoomButton";
            this.RoomButton.Size = new System.Drawing.Size(231, 71);
            this.RoomButton.TabIndex = 4;
            this.RoomButton.Text = "Pokoje";
            this.RoomButton.UseVisualStyleBackColor = false;
            this.RoomButton.Click += new System.EventHandler(this.RoomButton_Click);
            // 
            // GuestButton
            // 
            this.GuestButton.BackColor = System.Drawing.Color.White;
            this.GuestButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.GuestButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.GuestButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GuestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuestButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuestButton.Location = new System.Drawing.Point(0, 276);
            this.GuestButton.Name = "GuestButton";
            this.GuestButton.Size = new System.Drawing.Size(231, 68);
            this.GuestButton.TabIndex = 3;
            this.GuestButton.Text = "Hosté";
            this.GuestButton.UseVisualStyleBackColor = false;
            this.GuestButton.Click += new System.EventHandler(this.GuestButton_Click);
            // 
            // EmployeeButton
            // 
            this.EmployeeButton.BackColor = System.Drawing.Color.White;
            this.EmployeeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.EmployeeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.EmployeeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.EmployeeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmployeeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeButton.Location = new System.Drawing.Point(0, 206);
            this.EmployeeButton.Name = "EmployeeButton";
            this.EmployeeButton.Size = new System.Drawing.Size(231, 70);
            this.EmployeeButton.TabIndex = 8;
            this.EmployeeButton.Text = "Zaměstnanci";
            this.EmployeeButton.UseVisualStyleBackColor = false;
            this.EmployeeButton.Click += new System.EventHandler(this.EmployeeButton_Click);
            // 
            // UserButton
            // 
            this.UserButton.BackColor = System.Drawing.Color.White;
            this.UserButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.UserButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserButton.Location = new System.Drawing.Point(0, 136);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(231, 70);
            this.UserButton.TabIndex = 6;
            this.UserButton.Text = "Uživatel";
            this.UserButton.UseVisualStyleBackColor = false;
            this.UserButton.Click += new System.EventHandler(this.UserButton_Click);
            // 
            // NewResButton
            // 
            this.NewResButton.BackColor = System.Drawing.Color.White;
            this.NewResButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewResButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.NewResButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NewResButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewResButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewResButton.Location = new System.Drawing.Point(0, 68);
            this.NewResButton.Name = "NewResButton";
            this.NewResButton.Size = new System.Drawing.Size(231, 68);
            this.NewResButton.TabIndex = 5;
            this.NewResButton.Text = "Nová rezervace";
            this.NewResButton.UseVisualStyleBackColor = false;
            this.NewResButton.Click += new System.EventHandler(this.NewResButton_Click);
            // 
            // OverviewButton
            // 
            this.OverviewButton.BackColor = System.Drawing.Color.White;
            this.OverviewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OverviewButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OverviewButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OverviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OverviewButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverviewButton.Location = new System.Drawing.Point(0, 0);
            this.OverviewButton.Name = "OverviewButton";
            this.OverviewButton.Size = new System.Drawing.Size(231, 68);
            this.OverviewButton.TabIndex = 2;
            this.OverviewButton.Text = "Přehled";
            this.OverviewButton.UseVisualStyleBackColor = false;
            this.OverviewButton.Click += new System.EventHandler(this.OverviewButton_Click);
            // 
            // MainContent
            // 
            this.MainContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainContent.BackColor = System.Drawing.SystemColors.Control;
            this.MainContent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainContent.Location = new System.Drawing.Point(231, 100);
            this.MainContent.Name = "MainContent";
            this.MainContent.Size = new System.Drawing.Size(722, 461);
            this.MainContent.TabIndex = 1;
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.WindowText;
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.White;
            this.Header.Location = new System.Drawing.Point(231, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(722, 100);
            this.Header.TabIndex = 2;
            this.Header.Text = "Head";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 561);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.MainContent);
            this.Controls.Add(this.NavPanel);
            this.MaximumSize = new System.Drawing.Size(2269, 1056);
            this.MinimumSize = new System.Drawing.Size(969, 590);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.NavPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel NavPanel;
        private System.Windows.Forms.Panel MainContent;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Button UserButton;
        private System.Windows.Forms.Button NewResButton;
        private System.Windows.Forms.Button RoomButton;
        private System.Windows.Forms.Button GuestButton;
        private System.Windows.Forms.Button OverviewButton;
        private System.Windows.Forms.Button EmployeeButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button LogoutButton;
    }
}
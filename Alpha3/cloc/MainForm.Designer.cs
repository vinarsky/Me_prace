
namespace Alpha3
{
    partial class MainForm
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
            this.Content = new System.Windows.Forms.Panel();
            this.CustomerButton = new System.Windows.Forms.Button();
            this.ProductsButton = new System.Windows.Forms.Button();
            this.EmplyeeButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.Navigation = new System.Windows.Forms.FlowLayoutPanel();
            this.OrderButton = new System.Windows.Forms.Button();
            this.Storesbutton = new System.Windows.Forms.Button();
            this.Navigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Content.AutoSize = true;
            this.Content.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Content.Location = new System.Drawing.Point(154, 12);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(664, 403);
            this.Content.TabIndex = 1;
            // 
            // CustomerButton
            // 
            this.CustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerButton.AutoSize = true;
            this.CustomerButton.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerButton.Location = new System.Drawing.Point(3, 115);
            this.CustomerButton.Name = "CustomerButton";
            this.CustomerButton.Size = new System.Drawing.Size(130, 50);
            this.CustomerButton.TabIndex = 2;
            this.CustomerButton.Text = "Zákazníci";
            this.CustomerButton.UseVisualStyleBackColor = true;
            this.CustomerButton.Click += new System.EventHandler(this.CustomerMenu_Click);
            // 
            // ProductsButton
            // 
            this.ProductsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductsButton.AutoSize = true;
            this.ProductsButton.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductsButton.Location = new System.Drawing.Point(3, 59);
            this.ProductsButton.Name = "ProductsButton";
            this.ProductsButton.Size = new System.Drawing.Size(130, 50);
            this.ProductsButton.TabIndex = 3;
            this.ProductsButton.Text = "Produkty";
            this.ProductsButton.UseVisualStyleBackColor = true;
            this.ProductsButton.Click += new System.EventHandler(this.ProductsButton_Click);
            // 
            // EmplyeeButton
            // 
            this.EmplyeeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmplyeeButton.AutoSize = true;
            this.EmplyeeButton.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmplyeeButton.Location = new System.Drawing.Point(3, 3);
            this.EmplyeeButton.Name = "EmplyeeButton";
            this.EmplyeeButton.Size = new System.Drawing.Size(130, 50);
            this.EmplyeeButton.TabIndex = 4;
            this.EmplyeeButton.Text = "Zaměstnanci";
            this.EmplyeeButton.UseVisualStyleBackColor = true;
            this.EmplyeeButton.Click += new System.EventHandler(this.EmplyeeButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportButton.AutoSize = true;
            this.ImportButton.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportButton.Location = new System.Drawing.Point(3, 227);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(130, 50);
            this.ImportButton.TabIndex = 5;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.AutoSize = true;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(3, 339);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(130, 50);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Navigation
            // 
            this.Navigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Navigation.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Navigation.Controls.Add(this.EmplyeeButton);
            this.Navigation.Controls.Add(this.ProductsButton);
            this.Navigation.Controls.Add(this.CustomerButton);
            this.Navigation.Controls.Add(this.OrderButton);
            this.Navigation.Controls.Add(this.ImportButton);
            this.Navigation.Controls.Add(this.Storesbutton);
            this.Navigation.Controls.Add(this.ExitButton);
            this.Navigation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Navigation.Location = new System.Drawing.Point(12, 12);
            this.Navigation.Name = "Navigation";
            this.Navigation.Size = new System.Drawing.Size(136, 403);
            this.Navigation.TabIndex = 7;
            // 
            // OrderButton
            // 
            this.OrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrderButton.AutoSize = true;
            this.OrderButton.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderButton.Location = new System.Drawing.Point(3, 171);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(130, 50);
            this.OrderButton.TabIndex = 7;
            this.OrderButton.Text = "Objednávky";
            this.OrderButton.UseVisualStyleBackColor = true;
            this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click_1);
            // 
            // Storesbutton
            // 
            this.Storesbutton.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold);
            this.Storesbutton.Location = new System.Drawing.Point(3, 283);
            this.Storesbutton.Name = "Storesbutton";
            this.Storesbutton.Size = new System.Drawing.Size(130, 50);
            this.Storesbutton.TabIndex = 8;
            this.Storesbutton.Text = "Pobočky";
            this.Storesbutton.UseVisualStyleBackColor = true;
            this.Storesbutton.Click += new System.EventHandler(this.Storesbutton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 427);
            this.Controls.Add(this.Navigation);
            this.Controls.Add(this.Content);
            this.MinimumSize = new System.Drawing.Size(846, 466);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Navigation.ResumeLayout(false);
            this.Navigation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.Button CustomerButton;
        private System.Windows.Forms.Button ProductsButton;
        private System.Windows.Forms.Button EmplyeeButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.FlowLayoutPanel Navigation;
        private System.Windows.Forms.Button OrderButton;
        private System.Windows.Forms.Button Storesbutton;
    }
}
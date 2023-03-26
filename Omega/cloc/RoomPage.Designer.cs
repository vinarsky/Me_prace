
namespace Omega
{
    partial class RoomPage
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RemoveFiltr = new System.Windows.Forms.Button();
            this.AddFilter = new System.Windows.Forms.Button();
            this.ApplieFilter = new System.Windows.Forms.CheckBox();
            this.AvailableFiltersList = new System.Windows.Forms.ListBox();
            this.AppliedFiltersList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 167);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(800, 283);
            this.dataGridView.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AppliedFiltersList);
            this.panel1.Controls.Add(this.RemoveFiltr);
            this.panel1.Controls.Add(this.AddFilter);
            this.panel1.Controls.Add(this.ApplieFilter);
            this.panel1.Controls.Add(this.AvailableFiltersList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 161);
            this.panel1.TabIndex = 2;
            // 
            // RemoveFiltr
            // 
            this.RemoveFiltr.Location = new System.Drawing.Point(130, 71);
            this.RemoveFiltr.Name = "RemoveFiltr";
            this.RemoveFiltr.Size = new System.Drawing.Size(75, 23);
            this.RemoveFiltr.TabIndex = 4;
            this.RemoveFiltr.Text = "Odebrat filtr";
            this.RemoveFiltr.UseVisualStyleBackColor = true;
            this.RemoveFiltr.Click += new System.EventHandler(this.RemoveFiltr_Click);
            // 
            // AddFilter
            // 
            this.AddFilter.Location = new System.Drawing.Point(130, 24);
            this.AddFilter.Name = "AddFilter";
            this.AddFilter.Size = new System.Drawing.Size(75, 23);
            this.AddFilter.TabIndex = 3;
            this.AddFilter.Text = "Přidat filtr";
            this.AddFilter.UseVisualStyleBackColor = true;
            this.AddFilter.Click += new System.EventHandler(this.AddFilter_Click);
            // 
            // ApplieFilter
            // 
            this.ApplieFilter.AutoSize = true;
            this.ApplieFilter.Location = new System.Drawing.Point(17, 130);
            this.ApplieFilter.Name = "ApplieFilter";
            this.ApplieFilter.Size = new System.Drawing.Size(92, 17);
            this.ApplieFilter.TabIndex = 1;
            this.ApplieFilter.Text = "Aplikovat filter";
            this.ApplieFilter.UseVisualStyleBackColor = true;
            this.ApplieFilter.CheckedChanged += new System.EventHandler(this.ApplieFilter_CheckedChanged);
            // 
            // AvailableFiltersList
            // 
            this.AvailableFiltersList.FormattingEnabled = true;
            this.AvailableFiltersList.Location = new System.Drawing.Point(12, 12);
            this.AvailableFiltersList.Name = "AvailableFiltersList";
            this.AvailableFiltersList.Size = new System.Drawing.Size(85, 95);
            this.AvailableFiltersList.TabIndex = 0;
            // 
            // AppliedFiltersList
            // 
            this.AppliedFiltersList.FormattingEnabled = true;
            this.AppliedFiltersList.Location = new System.Drawing.Point(238, 12);
            this.AppliedFiltersList.Name = "AppliedFiltersList";
            this.AppliedFiltersList.Size = new System.Drawing.Size(85, 95);
            this.AppliedFiltersList.TabIndex = 5;
            // 
            // RoomPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView);
            this.Name = "RoomPage";
            this.Tag = "Pokoje";
            this.Text = "RoomPage";
            this.Load += new System.EventHandler(this.RoomPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox AvailableFiltersList;
        private System.Windows.Forms.CheckBox ApplieFilter;
        private System.Windows.Forms.Button RemoveFiltr;
        private System.Windows.Forms.Button AddFilter;
        private System.Windows.Forms.ListBox AppliedFiltersList;
    }
}
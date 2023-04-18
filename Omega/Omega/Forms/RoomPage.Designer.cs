
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
            this.label6 = new System.Windows.Forms.Label();
            this.ChangeRoomState = new System.Windows.Forms.Button();
            this.StatusList = new System.Windows.Forms.ListBox();
            this.FloorcheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Floor = new System.Windows.Forms.NumericUpDown();
            this.ApplieFilter = new System.Windows.Forms.Button();
            this.PricecheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MinCena = new System.Windows.Forms.NumericUpDown();
            this.MaxCena = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AppliedFiltersList = new System.Windows.Forms.ListBox();
            this.RemoveFiltr = new System.Windows.Forms.Button();
            this.AddFilter = new System.Windows.Forms.Button();
            this.AvailableFiltersList = new System.Windows.Forms.ListBox();
            this.BedsdataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Floor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinCena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxCena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BedsdataGridView)).BeginInit();
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
            this.dataGridView.Location = new System.Drawing.Point(222, 216);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(578, 234);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ChangeRoomState);
            this.panel1.Controls.Add(this.StatusList);
            this.panel1.Controls.Add(this.FloorcheckBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Floor);
            this.panel1.Controls.Add(this.ApplieFilter);
            this.panel1.Controls.Add(this.PricecheckBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.MinCena);
            this.panel1.Controls.Add(this.MaxCena);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.AppliedFiltersList);
            this.panel1.Controls.Add(this.RemoveFiltr);
            this.panel1.Controls.Add(this.AddFilter);
            this.panel1.Controls.Add(this.AvailableFiltersList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 210);
            this.panel1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Stav pokoje";
            // 
            // ChangeRoomState
            // 
            this.ChangeRoomState.Location = new System.Drawing.Point(111, 174);
            this.ChangeRoomState.Name = "ChangeRoomState";
            this.ChangeRoomState.Size = new System.Drawing.Size(105, 23);
            this.ChangeRoomState.TabIndex = 19;
            this.ChangeRoomState.Text = "Změnit stav pokoje";
            this.ChangeRoomState.UseVisualStyleBackColor = true;
            this.ChangeRoomState.Click += new System.EventHandler(this.ChangeRoomState_Click);
            // 
            // StatusList
            // 
            this.StatusList.FormattingEnabled = true;
            this.StatusList.Location = new System.Drawing.Point(12, 128);
            this.StatusList.Name = "StatusList";
            this.StatusList.Size = new System.Drawing.Size(85, 69);
            this.StatusList.TabIndex = 18;
            // 
            // FloorcheckBox
            // 
            this.FloorcheckBox.AutoSize = true;
            this.FloorcheckBox.Location = new System.Drawing.Point(553, 54);
            this.FloorcheckBox.Name = "FloorcheckBox";
            this.FloorcheckBox.Size = new System.Drawing.Size(92, 17);
            this.FloorcheckBox.TabIndex = 16;
            this.FloorcheckBox.Text = "Aplikovat filter";
            this.FloorcheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(550, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Podlaží:";
            // 
            // Floor
            // 
            this.Floor.Location = new System.Drawing.Point(605, 25);
            this.Floor.Name = "Floor";
            this.Floor.Size = new System.Drawing.Size(120, 20);
            this.Floor.TabIndex = 14;
            // 
            // ApplieFilter
            // 
            this.ApplieFilter.Location = new System.Drawing.Point(120, 85);
            this.ApplieFilter.Name = "ApplieFilter";
            this.ApplieFilter.Size = new System.Drawing.Size(75, 23);
            this.ApplieFilter.TabIndex = 13;
            this.ApplieFilter.Text = "Aplikovat filtr";
            this.ApplieFilter.UseVisualStyleBackColor = true;
            this.ApplieFilter.Click += new System.EventHandler(this.ApplieFilter_Click);
            // 
            // PricecheckBox
            // 
            this.PricecheckBox.AutoSize = true;
            this.PricecheckBox.Location = new System.Drawing.Point(338, 78);
            this.PricecheckBox.Name = "PricecheckBox";
            this.PricecheckBox.Size = new System.Drawing.Size(92, 17);
            this.PricecheckBox.TabIndex = 12;
            this.PricecheckBox.Text = "Aplikovat filter";
            this.PricecheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(337, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Min cena:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(335, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Max cena:";
            // 
            // MinCena
            // 
            this.MinCena.Location = new System.Drawing.Point(398, 52);
            this.MinCena.Name = "MinCena";
            this.MinCena.Size = new System.Drawing.Size(120, 20);
            this.MinCena.TabIndex = 9;
            // 
            // MaxCena
            // 
            this.MaxCena.Location = new System.Drawing.Point(398, 25);
            this.MaxCena.Name = "MaxCena";
            this.MaxCena.Size = new System.Drawing.Size(120, 20);
            this.MaxCena.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Aplikované filtry";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Možné filtry";
            // 
            // AppliedFiltersList
            // 
            this.AppliedFiltersList.FormattingEnabled = true;
            this.AppliedFiltersList.Location = new System.Drawing.Point(220, 26);
            this.AppliedFiltersList.Name = "AppliedFiltersList";
            this.AppliedFiltersList.Size = new System.Drawing.Size(85, 82);
            this.AppliedFiltersList.TabIndex = 5;
            // 
            // RemoveFiltr
            // 
            this.RemoveFiltr.Location = new System.Drawing.Point(120, 55);
            this.RemoveFiltr.Name = "RemoveFiltr";
            this.RemoveFiltr.Size = new System.Drawing.Size(75, 23);
            this.RemoveFiltr.TabIndex = 4;
            this.RemoveFiltr.Text = "Odebrat filtr";
            this.RemoveFiltr.UseVisualStyleBackColor = true;
            this.RemoveFiltr.Click += new System.EventHandler(this.RemoveFiltr_Click);
            // 
            // AddFilter
            // 
            this.AddFilter.Location = new System.Drawing.Point(120, 26);
            this.AddFilter.Name = "AddFilter";
            this.AddFilter.Size = new System.Drawing.Size(75, 23);
            this.AddFilter.TabIndex = 3;
            this.AddFilter.Text = "Přidat filtr";
            this.AddFilter.UseVisualStyleBackColor = true;
            this.AddFilter.Click += new System.EventHandler(this.AddFilter_Click);
            // 
            // AvailableFiltersList
            // 
            this.AvailableFiltersList.FormattingEnabled = true;
            this.AvailableFiltersList.Location = new System.Drawing.Point(12, 25);
            this.AvailableFiltersList.Name = "AvailableFiltersList";
            this.AvailableFiltersList.Size = new System.Drawing.Size(85, 82);
            this.AvailableFiltersList.TabIndex = 0;
            // 
            // BedsdataGridView
            // 
            this.BedsdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BedsdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BedsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BedsdataGridView.Location = new System.Drawing.Point(0, 216);
            this.BedsdataGridView.Name = "BedsdataGridView";
            this.BedsdataGridView.ReadOnly = true;
            this.BedsdataGridView.Size = new System.Drawing.Size(216, 234);
            this.BedsdataGridView.TabIndex = 17;
            // 
            // RoomPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.BedsdataGridView);
            this.Name = "RoomPage";
            this.Tag = "Pokoje";
            this.Text = "RoomPage";
            this.Load += new System.EventHandler(this.RoomPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Floor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinCena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxCena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BedsdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox AvailableFiltersList;
        private System.Windows.Forms.Button RemoveFiltr;
        private System.Windows.Forms.Button AddFilter;
        private System.Windows.Forms.ListBox AppliedFiltersList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MinCena;
        private System.Windows.Forms.NumericUpDown MaxCena;
        private System.Windows.Forms.CheckBox PricecheckBox;
        private System.Windows.Forms.Button ApplieFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Floor;
        private System.Windows.Forms.CheckBox FloorcheckBox;
        private System.Windows.Forms.DataGridView BedsdataGridView;
        private System.Windows.Forms.ListBox StatusList;
        private System.Windows.Forms.Button ChangeRoomState;
        private System.Windows.Forms.Label label6;
    }
}
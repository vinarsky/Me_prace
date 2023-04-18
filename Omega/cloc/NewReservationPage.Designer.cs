
namespace Omega
{
    partial class NewReservationForm
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
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AvailableRooms = new System.Windows.Forms.ListBox();
            this.PeopleInRes = new System.Windows.Forms.DataGridView();
            this.SearchForPeople = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RemoveFromRes = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CreateRes = new System.Windows.Forms.Button();
            this.AddPersonToRes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PeopleInRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchForPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Location = new System.Drawing.Point(22, 38);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimeStart.TabIndex = 0;
            this.dateTimeStart.ValueChanged += new System.EventHandler(this.dateTimeStart_ValueChanged);
            this.dateTimeStart.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimeStart_Validating);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(342, 38);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimeEnd.TabIndex = 1;
            this.dateTimeEnd.ValueChanged += new System.EventHandler(this.dateTimeEnd_ValueChanged);
            this.dateTimeEnd.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimeEnd_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Začátek";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(338, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Konec";
            // 
            // AvailableRooms
            // 
            this.AvailableRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AvailableRooms.FormattingEnabled = true;
            this.AvailableRooms.Location = new System.Drawing.Point(556, 93);
            this.AvailableRooms.Name = "AvailableRooms";
            this.AvailableRooms.Size = new System.Drawing.Size(135, 147);
            this.AvailableRooms.TabIndex = 4;
            this.AvailableRooms.SelectedIndexChanged += new System.EventHandler(this.AvailableRooms_SelectedIndexChanged);
            // 
            // PeopleInRes
            // 
            this.PeopleInRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PeopleInRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PeopleInRes.Location = new System.Drawing.Point(23, 91);
            this.PeopleInRes.Name = "PeopleInRes";
            this.PeopleInRes.Size = new System.Drawing.Size(498, 150);
            this.PeopleInRes.TabIndex = 5;
            // 
            // SearchForPeople
            // 
            this.SearchForPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchForPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchForPeople.Location = new System.Drawing.Point(22, 288);
            this.SearchForPeople.Name = "SearchForPeople";
            this.SearchForPeople.Size = new System.Drawing.Size(499, 150);
            this.SearchForPeople.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lidé v rezervaci";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(552, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pokoje";
            // 
            // RemoveFromRes
            // 
            this.RemoveFromRes.Location = new System.Drawing.Point(147, 67);
            this.RemoveFromRes.Name = "RemoveFromRes";
            this.RemoveFromRes.Size = new System.Drawing.Size(75, 23);
            this.RemoveFromRes.TabIndex = 9;
            this.RemoveFromRes.Text = "Odebrat";
            this.RemoveFromRes.UseVisualStyleBackColor = true;
            this.RemoveFromRes.Click += new System.EventHandler(this.RemoveFromRes_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Vyhledávání lídí podle příjmení ";
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(234, 242);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(152, 20);
            this.SearchBar.TabIndex = 11;
            this.SearchBar.TextChanged += new System.EventHandler(this.SearchBar_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(552, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cena:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(601, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 19);
            this.label7.TabIndex = 13;
            // 
            // CreateRes
            // 
            this.CreateRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateRes.Location = new System.Drawing.Point(556, 315);
            this.CreateRes.Name = "CreateRes";
            this.CreateRes.Size = new System.Drawing.Size(120, 23);
            this.CreateRes.TabIndex = 14;
            this.CreateRes.Text = "Vytvořit rezervaci";
            this.CreateRes.UseVisualStyleBackColor = true;
            this.CreateRes.Click += new System.EventHandler(this.CreateRes_Click);
            // 
            // AddPersonToRes
            // 
            this.AddPersonToRes.Location = new System.Drawing.Point(23, 264);
            this.AddPersonToRes.Name = "AddPersonToRes";
            this.AddPersonToRes.Size = new System.Drawing.Size(75, 23);
            this.AddPersonToRes.TabIndex = 15;
            this.AddPersonToRes.Text = "Přidat";
            this.AddPersonToRes.UseVisualStyleBackColor = true;
            this.AddPersonToRes.Click += new System.EventHandler(this.AddPersonToRes_Click);
            // 
            // NewReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddPersonToRes);
            this.Controls.Add(this.CreateRes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RemoveFromRes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SearchForPeople);
            this.Controls.Add(this.PeopleInRes);
            this.Controls.Add(this.AvailableRooms);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.dateTimeStart);
            this.Name = "NewReservationForm";
            this.Tag = "Nová rezervace";
            this.Text = "NewReservationForm";
            this.Load += new System.EventHandler(this.NewReservationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PeopleInRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchForPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox AvailableRooms;
        private System.Windows.Forms.DataGridView PeopleInRes;
        private System.Windows.Forms.DataGridView SearchForPeople;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RemoveFromRes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button CreateRes;
        private System.Windows.Forms.Button AddPersonToRes;
    }
}
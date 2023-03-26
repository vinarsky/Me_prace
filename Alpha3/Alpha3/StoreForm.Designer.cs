
namespace Alpha3
{
    partial class StoreForm
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
            this.Pobočky = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Warhouse = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ToWhichStore = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AmountToTransfer = new System.Windows.Forms.NumericUpDown();
            this.TransferButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warhouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToWhichStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountToTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // Pobočky
            // 
            this.Pobočky.AutoSize = true;
            this.Pobočky.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Bold);
            this.Pobočky.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pobočky.Location = new System.Drawing.Point(12, 9);
            this.Pobočky.Name = "Pobočky";
            this.Pobočky.Size = new System.Drawing.Size(68, 20);
            this.Pobočky.TabIndex = 6;
            this.Pobočky.Text = "Pobočky";
            this.Pobočky.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(264, 87);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(537, 362);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // Warhouse
            // 
            this.Warhouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Warhouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Warhouse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Warhouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Warhouse.Location = new System.Drawing.Point(0, 87);
            this.Warhouse.Name = "Warhouse";
            this.Warhouse.Size = new System.Drawing.Size(258, 362);
            this.Warhouse.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sklad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Pobočky";
            // 
            // ToWhichStore
            // 
            this.ToWhichStore.Location = new System.Drawing.Point(462, 38);
            this.ToWhichStore.Name = "ToWhichStore";
            this.ToWhichStore.Size = new System.Drawing.Size(120, 20);
            this.ToWhichStore.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "ID pobočky, kam se má item přesunout:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Počet pro přesun:";
            // 
            // AmountToTransfer
            // 
            this.AmountToTransfer.Location = new System.Drawing.Point(122, 38);
            this.AmountToTransfer.Name = "AmountToTransfer";
            this.AmountToTransfer.Size = new System.Drawing.Size(120, 20);
            this.AmountToTransfer.TabIndex = 14;
            // 
            // TransferButton
            // 
            this.TransferButton.Location = new System.Drawing.Point(645, 34);
            this.TransferButton.Name = "TransferButton";
            this.TransferButton.Size = new System.Drawing.Size(75, 23);
            this.TransferButton.TabIndex = 15;
            this.TransferButton.Text = "Přesunout";
            this.TransferButton.UseVisualStyleBackColor = true;
            this.TransferButton.Click += new System.EventHandler(this.TransferButton_Click);
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TransferButton);
            this.Controls.Add(this.AmountToTransfer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ToWhichStore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Warhouse);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Pobočky);
            this.Name = "StoreForm";
            this.Text = "StoreForm";
            this.Load += new System.EventHandler(this.StoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warhouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToWhichStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountToTransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Pobočky;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridView Warhouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ToWhichStore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown AmountToTransfer;
        private System.Windows.Forms.Button TransferButton;
    }
}
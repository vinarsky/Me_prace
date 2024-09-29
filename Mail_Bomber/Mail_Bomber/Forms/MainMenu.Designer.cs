namespace Mail_Bomber
{
    partial class MainMenu
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
            this.SimEnd = new System.Windows.Forms.Button();
            this.SimPause = new System.Windows.Forms.Button();
            this.SimStart = new System.Windows.Forms.Button();
            this.SimulationContolButtons = new System.Windows.Forms.Panel();
            this.SimResume = new System.Windows.Forms.Button();
            this.ChangesToSend = new System.Windows.Forms.Panel();
            this.ChangesListBox = new System.Windows.Forms.CheckedListBox();
            this.ChangesToSendLabel = new System.Windows.Forms.Label();
            this.Mails = new System.Windows.Forms.Panel();
            this.MailsThatWereSend = new System.Windows.Forms.FlowLayoutPanel();
            this.RunsOrNot_Indecator = new System.Windows.Forms.Label();
            this.SentMailsLabel = new System.Windows.Forms.Label();
            this.AppSettings = new System.Windows.Forms.Panel();
            this.webIP_TextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeIntensity_UpDown = new System.Windows.Forms.NumericUpDown();
            this.Interval_TextBox = new System.Windows.Forms.TextBox();
            this.Password_TextBox = new System.Windows.Forms.TextBox();
            this.SmtpPort_TextBox = new System.Windows.Forms.TextBox();
            this.SmtpServer_TextBox = new System.Windows.Forms.TextBox();
            this.SendMail_TextBox = new System.Windows.Forms.TextBox();
            this.RecieverMail_TextBox = new System.Windows.Forms.TextBox();
            this.SaveSettings = new System.Windows.Forms.Button();
            this.AppSettingsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExportOrderCheckBox = new System.Windows.Forms.CheckBox();
            this.ImportOrderCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SimulationContolButtons.SuspendLayout();
            this.ChangesToSend.SuspendLayout();
            this.Mails.SuspendLayout();
            this.AppSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeIntensity_UpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SimEnd
            // 
            this.SimEnd.Location = new System.Drawing.Point(246, 3);
            this.SimEnd.Name = "SimEnd";
            this.SimEnd.Size = new System.Drawing.Size(75, 23);
            this.SimEnd.TabIndex = 1;
            this.SimEnd.Text = "Konec";
            this.SimEnd.UseVisualStyleBackColor = true;
            this.SimEnd.Click += new System.EventHandler(this.SimEnd_Click);
            // 
            // SimPause
            // 
            this.SimPause.Location = new System.Drawing.Point(84, 3);
            this.SimPause.Name = "SimPause";
            this.SimPause.Size = new System.Drawing.Size(75, 23);
            this.SimPause.TabIndex = 2;
            this.SimPause.Text = "Pozastavit";
            this.SimPause.UseVisualStyleBackColor = true;
            this.SimPause.Click += new System.EventHandler(this.SimPause_Click);
            // 
            // SimStart
            // 
            this.SimStart.Location = new System.Drawing.Point(3, 3);
            this.SimStart.Name = "SimStart";
            this.SimStart.Size = new System.Drawing.Size(75, 23);
            this.SimStart.TabIndex = 3;
            this.SimStart.Text = "Start";
            this.SimStart.UseVisualStyleBackColor = true;
            this.SimStart.Click += new System.EventHandler(this.SimStart_Click);
            // 
            // SimulationContolButtons
            // 
            this.SimulationContolButtons.Controls.Add(this.SimResume);
            this.SimulationContolButtons.Controls.Add(this.SimStart);
            this.SimulationContolButtons.Controls.Add(this.SimEnd);
            this.SimulationContolButtons.Controls.Add(this.SimPause);
            this.SimulationContolButtons.Location = new System.Drawing.Point(142, 12);
            this.SimulationContolButtons.Name = "SimulationContolButtons";
            this.SimulationContolButtons.Size = new System.Drawing.Size(326, 30);
            this.SimulationContolButtons.TabIndex = 4;
            // 
            // SimResume
            // 
            this.SimResume.Location = new System.Drawing.Point(165, 4);
            this.SimResume.Name = "SimResume";
            this.SimResume.Size = new System.Drawing.Size(75, 23);
            this.SimResume.TabIndex = 4;
            this.SimResume.Text = "Pokračovat";
            this.SimResume.UseVisualStyleBackColor = true;
            this.SimResume.Click += new System.EventHandler(this.SimResume_Click);
            // 
            // ChangesToSend
            // 
            this.ChangesToSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ChangesToSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChangesToSend.Controls.Add(this.ChangesListBox);
            this.ChangesToSend.Controls.Add(this.ChangesToSendLabel);
            this.ChangesToSend.Location = new System.Drawing.Point(12, 141);
            this.ChangesToSend.Name = "ChangesToSend";
            this.ChangesToSend.Size = new System.Drawing.Size(200, 297);
            this.ChangesToSend.TabIndex = 5;
            // 
            // ChangesListBox
            // 
            this.ChangesListBox.BackColor = System.Drawing.Color.White;
            this.ChangesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChangesListBox.CheckOnClick = true;
            this.ChangesListBox.FormattingEnabled = true;
            this.ChangesListBox.Location = new System.Drawing.Point(15, 25);
            this.ChangesListBox.Name = "ChangesListBox";
            this.ChangesListBox.Size = new System.Drawing.Size(168, 255);
            this.ChangesListBox.TabIndex = 2;
            // 
            // ChangesToSendLabel
            // 
            this.ChangesToSendLabel.AutoSize = true;
            this.ChangesToSendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangesToSendLabel.Location = new System.Drawing.Point(3, 0);
            this.ChangesToSendLabel.Name = "ChangesToSendLabel";
            this.ChangesToSendLabel.Size = new System.Drawing.Size(195, 13);
            this.ChangesToSendLabel.TabIndex = 1;
            this.ChangesToSendLabel.Text = "Jaké věci posílat k objednávkám";
            this.ChangesToSendLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mails
            // 
            this.Mails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Mails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mails.Controls.Add(this.MailsThatWereSend);
            this.Mails.Controls.Add(this.RunsOrNot_Indecator);
            this.Mails.Controls.Add(this.SentMailsLabel);
            this.Mails.Location = new System.Drawing.Point(481, 12);
            this.Mails.Name = "Mails";
            this.Mails.Size = new System.Drawing.Size(307, 426);
            this.Mails.TabIndex = 6;
            // 
            // MailsThatWereSend
            // 
            this.MailsThatWereSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MailsThatWereSend.AutoScroll = true;
            this.MailsThatWereSend.Location = new System.Drawing.Point(3, 41);
            this.MailsThatWereSend.Name = "MailsThatWereSend";
            this.MailsThatWereSend.Size = new System.Drawing.Size(299, 380);
            this.MailsThatWereSend.TabIndex = 3;
            // 
            // RunsOrNot_Indecator
            // 
            this.RunsOrNot_Indecator.AutoSize = true;
            this.RunsOrNot_Indecator.BackColor = System.Drawing.Color.White;
            this.RunsOrNot_Indecator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunsOrNot_Indecator.ForeColor = System.Drawing.Color.Black;
            this.RunsOrNot_Indecator.Location = new System.Drawing.Point(201, 3);
            this.RunsOrNot_Indecator.Name = "RunsOrNot_Indecator";
            this.RunsOrNot_Indecator.Size = new System.Drawing.Size(86, 13);
            this.RunsOrNot_Indecator.TabIndex = 2;
            this.RunsOrNot_Indecator.Text = "Simulace nebeží";
            // 
            // SentMailsLabel
            // 
            this.SentMailsLabel.AutoSize = true;
            this.SentMailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SentMailsLabel.Location = new System.Drawing.Point(3, 3);
            this.SentMailsLabel.Name = "SentMailsLabel";
            this.SentMailsLabel.Size = new System.Drawing.Size(129, 13);
            this.SentMailsLabel.TabIndex = 1;
            this.SentMailsLabel.Text = "Vygenerované zprávy";
            // 
            // AppSettings
            // 
            this.AppSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AppSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppSettings.Controls.Add(this.webIP_TextBox);
            this.AppSettings.Controls.Add(this.label10);
            this.AppSettings.Controls.Add(this.label9);
            this.AppSettings.Controls.Add(this.label8);
            this.AppSettings.Controls.Add(this.label7);
            this.AppSettings.Controls.Add(this.label6);
            this.AppSettings.Controls.Add(this.label5);
            this.AppSettings.Controls.Add(this.label4);
            this.AppSettings.Controls.Add(this.label3);
            this.AppSettings.Controls.Add(this.ChangeIntensity_UpDown);
            this.AppSettings.Controls.Add(this.Interval_TextBox);
            this.AppSettings.Controls.Add(this.Password_TextBox);
            this.AppSettings.Controls.Add(this.SmtpPort_TextBox);
            this.AppSettings.Controls.Add(this.SmtpServer_TextBox);
            this.AppSettings.Controls.Add(this.SendMail_TextBox);
            this.AppSettings.Controls.Add(this.RecieverMail_TextBox);
            this.AppSettings.Controls.Add(this.SaveSettings);
            this.AppSettings.Controls.Add(this.AppSettingsLabel);
            this.AppSettings.Location = new System.Drawing.Point(225, 49);
            this.AppSettings.Name = "AppSettings";
            this.AppSettings.Size = new System.Drawing.Size(243, 389);
            this.AppSettings.TabIndex = 7;
            // 
            // webIP_TextBox
            // 
            this.webIP_TextBox.BackColor = System.Drawing.Color.Snow;
            this.webIP_TextBox.Location = new System.Drawing.Point(7, 115);
            this.webIP_TextBox.Name = "webIP_TextBox";
            this.webIP_TextBox.Size = new System.Drawing.Size(230, 20);
            this.webIP_TextBox.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Web IP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Intenzita změn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Interval";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Heslo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Smtp port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Smtp sever";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Odesílatel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Příjemce";
            // 
            // ChangeIntensity_UpDown
            // 
            this.ChangeIntensity_UpDown.Location = new System.Drawing.Point(109, 300);
            this.ChangeIntensity_UpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ChangeIntensity_UpDown.Name = "ChangeIntensity_UpDown";
            this.ChangeIntensity_UpDown.Size = new System.Drawing.Size(127, 20);
            this.ChangeIntensity_UpDown.TabIndex = 9;
            this.ChangeIntensity_UpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Interval_TextBox
            // 
            this.Interval_TextBox.BackColor = System.Drawing.Color.Snow;
            this.Interval_TextBox.Location = new System.Drawing.Point(7, 274);
            this.Interval_TextBox.Name = "Interval_TextBox";
            this.Interval_TextBox.Size = new System.Drawing.Size(230, 20);
            this.Interval_TextBox.TabIndex = 8;
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.BackColor = System.Drawing.Color.Snow;
            this.Password_TextBox.Location = new System.Drawing.Point(7, 235);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Size = new System.Drawing.Size(230, 20);
            this.Password_TextBox.TabIndex = 7;
            // 
            // SmtpPort_TextBox
            // 
            this.SmtpPort_TextBox.BackColor = System.Drawing.Color.Snow;
            this.SmtpPort_TextBox.Location = new System.Drawing.Point(7, 197);
            this.SmtpPort_TextBox.Name = "SmtpPort_TextBox";
            this.SmtpPort_TextBox.Size = new System.Drawing.Size(230, 20);
            this.SmtpPort_TextBox.TabIndex = 6;
            // 
            // SmtpServer_TextBox
            // 
            this.SmtpServer_TextBox.BackColor = System.Drawing.Color.Snow;
            this.SmtpServer_TextBox.Location = new System.Drawing.Point(7, 158);
            this.SmtpServer_TextBox.Name = "SmtpServer_TextBox";
            this.SmtpServer_TextBox.Size = new System.Drawing.Size(230, 20);
            this.SmtpServer_TextBox.TabIndex = 5;
            // 
            // SendMail_TextBox
            // 
            this.SendMail_TextBox.BackColor = System.Drawing.Color.Snow;
            this.SendMail_TextBox.Location = new System.Drawing.Point(7, 76);
            this.SendMail_TextBox.Name = "SendMail_TextBox";
            this.SendMail_TextBox.Size = new System.Drawing.Size(230, 20);
            this.SendMail_TextBox.TabIndex = 4;
            // 
            // RecieverMail_TextBox
            // 
            this.RecieverMail_TextBox.BackColor = System.Drawing.Color.Snow;
            this.RecieverMail_TextBox.Location = new System.Drawing.Point(7, 37);
            this.RecieverMail_TextBox.Name = "RecieverMail_TextBox";
            this.RecieverMail_TextBox.Size = new System.Drawing.Size(230, 20);
            this.RecieverMail_TextBox.TabIndex = 3;
            // 
            // SaveSettings
            // 
            this.SaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveSettings.Location = new System.Drawing.Point(3, 361);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(234, 23);
            this.SaveSettings.TabIndex = 2;
            this.SaveSettings.Text = "Uložit";
            this.SaveSettings.UseVisualStyleBackColor = true;
            this.SaveSettings.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // AppSettingsLabel
            // 
            this.AppSettingsLabel.AutoSize = true;
            this.AppSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppSettingsLabel.Location = new System.Drawing.Point(4, 4);
            this.AppSettingsLabel.Name = "AppSettingsLabel";
            this.AppSettingsLabel.Size = new System.Drawing.Size(66, 13);
            this.AppSettingsLabel.TabIndex = 0;
            this.AppSettingsLabel.Text = "Nastevení";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "MailBomber";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ExportOrderCheckBox);
            this.panel1.Controls.Add(this.ImportOrderCheckBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 86);
            this.panel1.TabIndex = 9;
            // 
            // ExportOrderCheckBox
            // 
            this.ExportOrderCheckBox.AutoSize = true;
            this.ExportOrderCheckBox.Location = new System.Drawing.Point(15, 54);
            this.ExportOrderCheckBox.Name = "ExportOrderCheckBox";
            this.ExportOrderCheckBox.Size = new System.Drawing.Size(124, 17);
            this.ExportOrderCheckBox.TabIndex = 4;
            this.ExportOrderCheckBox.Text = "Exportní objednávky";
            this.ExportOrderCheckBox.UseVisualStyleBackColor = true;
            // 
            // ImportOrderCheckBox
            // 
            this.ImportOrderCheckBox.AutoSize = true;
            this.ImportOrderCheckBox.Location = new System.Drawing.Point(15, 31);
            this.ImportOrderCheckBox.Name = "ImportOrderCheckBox";
            this.ImportOrderCheckBox.Size = new System.Drawing.Size(123, 17);
            this.ImportOrderCheckBox.TabIndex = 3;
            this.ImportOrderCheckBox.Text = "Importní objednávky";
            this.ImportOrderCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jaký typ objednávek posílat";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AppSettings);
            this.Controls.Add(this.Mails);
            this.Controls.Add(this.ChangesToSend);
            this.Controls.Add(this.SimulationContolButtons);
            this.MaximumSize = new System.Drawing.Size(816, 1000);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainMenu";
            this.Text = "MailBomber";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.SimulationContolButtons.ResumeLayout(false);
            this.ChangesToSend.ResumeLayout(false);
            this.ChangesToSend.PerformLayout();
            this.Mails.ResumeLayout(false);
            this.Mails.PerformLayout();
            this.AppSettings.ResumeLayout(false);
            this.AppSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeIntensity_UpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SimEnd;
        private System.Windows.Forms.Button SimPause;
        private System.Windows.Forms.Button SimStart;
        private System.Windows.Forms.Panel SimulationContolButtons;
        private System.Windows.Forms.Panel ChangesToSend;
        private System.Windows.Forms.Panel Mails;
        private System.Windows.Forms.Label ChangesToSendLabel;
        private System.Windows.Forms.Label SentMailsLabel;
        private System.Windows.Forms.Panel AppSettings;
        private System.Windows.Forms.Label AppSettingsLabel;
        private System.Windows.Forms.Button SimResume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RunsOrNot_Indecator;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox ChangesListBox;
        private System.Windows.Forms.Button SaveSettings;
        private System.Windows.Forms.TextBox Password_TextBox;
        private System.Windows.Forms.TextBox SmtpPort_TextBox;
        private System.Windows.Forms.TextBox SmtpServer_TextBox;
        private System.Windows.Forms.TextBox SendMail_TextBox;
        private System.Windows.Forms.TextBox RecieverMail_TextBox;
        private System.Windows.Forms.TextBox Interval_TextBox;
        private System.Windows.Forms.NumericUpDown ChangeIntensity_UpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox ExportOrderCheckBox;
        public System.Windows.Forms.CheckBox ImportOrderCheckBox;
        private System.Windows.Forms.FlowLayoutPanel MailsThatWereSend;
        private System.Windows.Forms.TextBox webIP_TextBox;
        private System.Windows.Forms.Label label10;
    }
}


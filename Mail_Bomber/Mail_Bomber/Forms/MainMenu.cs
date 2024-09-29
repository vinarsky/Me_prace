using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Mail_Bomber
{
    internal partial class MainMenu : Form
    {
        CustomerSimulation Simulation;
        Thread T;

        List<SmallInfoPanel> InfoPanelList = new List<SmallInfoPanel>();

        public MainMenu()
        {
            InitializeComponent();
            Simulation = new CustomerSimulation(this);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            LoadChangesToCheckBoxList();
            LoadDefaultSettings();
            Simulation.SimulationCompleted += OnSimulationCompleted;         
            Simulation.MailSend += AddMailPanel;
            Simulation.MailSender.MailConfirmation += OnMailConfirmation;
            MailsThatWereSend.FlowDirection = FlowDirection.TopDown;
            MailsThatWereSend.WrapContents = false;
        }

        void LoadChangesToCheckBoxList()
        {
            string[] folders = Directory.GetDirectories("../../Mails/Other");
            foreach (string folder in folders)
            {
                string folderName = Path.GetFileName(folder);
                ChangesListBox.Items.Add(folderName, false);
            }
        }


        /// <summary>
        /// On start-up loads app settings in to textboxes in setting panel
        /// </summary>
        void LoadDefaultSettings()
        {
            try
            {
                webIP_TextBox.Text = ReadAppConf.ReadSettings("webIP");
                SmtpServer_TextBox.Text = ReadAppConf.ReadSettings("smtpServer");
                SmtpPort_TextBox.Text = ReadAppConf.ReadSettings("smtpPort");
                SendMail_TextBox.Text = ReadAppConf.ReadSettings("smtpUser");
                Password_TextBox.Text = ReadAppConf.ReadSettings("smtpPass");
                SendMail_TextBox.Text = ReadAppConf.ReadSettings("SenderMail");
                RecieverMail_TextBox.Text = ReadAppConf.ReadSettings("RecieverMail");
                Interval_TextBox.Text = ReadAppConf.ReadSettings("Interval");
                ChangeIntensity_UpDown.Text = ReadAppConf.ReadSettings("ChangesIntensity");
            }
            catch (Exception ex)
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBox.Show($"Error loading settings: {ex.Message}", "Error", button, icon);
            }
        }


        /// <summary>
        /// Event aquers when saveing new data. Settings.xml is over written by new data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument xmlDocument = new XDocument(
                new XElement("configuration",
                    new XElement("appSettings",
                        new XElement("add", new XAttribute("key", "webIP"), new XAttribute("value",webIP_TextBox.Text)),
                        new XElement("add", new XAttribute("key", "smtpServer"), new XAttribute("value", SmtpServer_TextBox.Text)),
                        new XElement("add", new XAttribute("key", "smtpPort"), new XAttribute("value", SmtpPort_TextBox.Text)),
                        new XElement("add", new XAttribute("key", "smtpUser"), new XAttribute("value", SendMail_TextBox.Text)),
                        new XElement("add", new XAttribute("key", "smtpPass"), new XAttribute("value", Password_TextBox.Text)),
                        new XElement("add", new XAttribute("key", "SenderMail"), new XAttribute("value", SendMail_TextBox.Text)),
                        new XElement("add", new XAttribute("key", "RecieverMail"), new XAttribute("value", RecieverMail_TextBox.Text)),
                        new XElement("add", new XAttribute("key", "Interval"), new XAttribute("value", Interval_TextBox.Text)),
                        new XElement("add", new XAttribute("key", "ChangesIntensity"), new XAttribute("value", ChangeIntensity_UpDown.Text))
                        )
                    )
                );
                string filePath = @"..\..\Configs\Settings.xml";
                xmlDocument.Save(filePath);

                MessageBoxIcon icon = MessageBoxIcon.Information;
                MessageBoxButtons button = MessageBoxButtons.OK;
                Simulation.MailSender.FillOutData();
                MessageBox.Show("Úspěšně uloženo.", "Uložno", button, icon);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading settings: {ex.Message}");
            }
        }

        public void AddMailPanel(Order o, Change c)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Simulation.SmallInfoPanel = new SmallInfoPanel(o.Reference, "nová objednávka");
                InfoPanelList.Add( Simulation.SmallInfoPanel );
                MailsThatWereSend.Controls.Add(Simulation.SmallInfoPanel);
            });
        }

        public void OnMailConfirmation(string confirm, SmallInfoPanel panel)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Label lblConformation = new Label();
                lblConformation.Parent = panel;
                lblConformation.Text = $"{confirm}";
                lblConformation.AutoSize = true;
                lblConformation.Location = new Point(210, 10);
                lblConformation.BringToFront();                
            });
        }

        private void AddSeparatorLine()
        {
            Panel separator = new Panel();
            separator.Height = 2; // Thickness of the line
            separator.Dock = DockStyle.Top;
            separator.BackColor = System.Drawing.Color.Black;
            separator.Margin = new Padding(10, 0, 10, 0); // Adds padding on the sides
            MailsThatWereSend.Controls.Add(separator);
        }


        public void WhatDirectionCanBeSend()
        {

        }


        private void SimStart_Click(object sender, EventArgs e)
        {
            if (!ImportOrderCheckBox.Checked && !ExportOrderCheckBox.Checked) 
            { 
                MessageBox.Show("Není vybraný ani jeden typ objednávky.");
                return;
            }

            if (Simulation.Ongoing) { return; }
                
            T = new Thread(() =>
            {
                Simulation.StartSimulation();
            });

            T.Start();

            MessageBox.Show("Simulace začala.");
            ImportOrderCheckBox.Enabled = false;
            ExportOrderCheckBox.Enabled = false;
            ChangesListBox.Enabled = false;
            AppSettings.Enabled = false;
        }


        private void SimEnd_Click(object sender, EventArgs e)
        {
            if (T == null) { return; }
            Simulation.Ongoing = false;
            Simulation.IsPaused = false;
            T.Abort();
            Simulation.Orders.Clear();
            MessageBox.Show("Simulace ukončena 1");
            ImportOrderCheckBox.Enabled = true;
            ExportOrderCheckBox.Enabled = true;
            ChangesListBox.Enabled = true;
            AppSettings.Enabled = true;
            T = null;
            AddSeparatorLine();
        }

        private void OnSimulationCompleted()
        {
            // Use Invoke to ensure this code runs on the UI thread
            this.Invoke((MethodInvoker)delegate
            {
                Simulation.Orders.Clear();
                Simulation.Ongoing = false;
                Simulation.IsPaused = false;
                T = null;
                ImportOrderCheckBox.Enabled = true;
                ExportOrderCheckBox.Enabled = true;
                ChangesListBox.Enabled = true;
                AppSettings.Enabled = true;
                AddSeparatorLine();
            });
        }


        private void SimPause_Click(object sender, EventArgs e)
        {
            if (Simulation.Ongoing && !Simulation.IsPaused)
            {
                Simulation.IsPaused = true;
                MessageBox.Show("Simulace pozastavena.");
                SimStart.Enabled = false;
                SimEnd.Enabled = false;
            }
        }


        private void SimResume_Click(object sender, EventArgs e)
        {
            if (Simulation.Ongoing && Simulation.IsPaused)
            {
                Simulation.IsPaused = false;
                MessageBox.Show("Simulace obvnovena.");
                SimStart.Enabled = true;
                SimEnd.Enabled = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Mail_Bomber
{
    internal class MailSender
    {
        private string recieverMail;
        private string senderMail;

        private string smtpServer;
        private string smtpPort;

        private string smtpUserName;
        private string smtpPassword;

        readonly string url = ReadAppConf.ReadSettings("webIP");
        private readonly HttpClient client;

        private SmallInfoPanel SmallInfoPanel;
        public event Action<string, SmallInfoPanel> MailConfirmation;

        protected virtual void OnMailConfirmation(string confirm, SmallInfoPanel panel)
        {
            MailConfirmation?.Invoke(confirm, panel);
        }

        private string RecieverMail
        {
            set
            {
                try
                {
                    var mailAddress = new MailAddress(value);
                    recieverMail = mailAddress.ToString();
                }
                catch (FormatException)
                {
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    MessageBox.Show($"Error while sending e-mail: Reciever e-mail doesnt meet the requirements", "Error", button, icon);
                }
            }
        }
        private string SenderMail
        {
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                    senderMail = value;
                else
                {
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    MessageBox.Show($"Error while sending e-mail: Sender e-mail doesnt meet the requirements", "Error", button, icon);
                }
            }
        }

        public MailSender()
        {
            client = new HttpClient();
            FillOutData();
        }

        public void FillOutData()
        {
            RecieverMail = ReadAppConf.ReadSettings("RecieverMail");
            SenderMail = ReadAppConf.ReadSettings("SenderMail");
            smtpServer = ReadAppConf.ReadSettings("smtpServer");
            smtpPort = ReadAppConf.ReadSettings("smtpPort");
            smtpUserName = ReadAppConf.ReadSettings("smtpUser");
            smtpPassword = ReadAppConf.ReadSettings("smtpPass");
        }

        /// <summary>
        /// Sends a post request to a web server that passes this data to a python script that will use the data to send mail.
        /// Send only test mail.
        /// </summary>
        public async Task SendTestEmail()
        {
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(smtpServer), "smtp_server");
                form.Add(new StringContent(smtpPort), "smtp_port");
                form.Add(new StringContent(senderMail), "smtp_user");
                form.Add(new StringContent(smtpPassword), "smtp_pass");
                form.Add(new StringContent(recieverMail), "rec_mail");
                form.Add(new StringContent("Tento mail značí že už nebudou poslány žádné nové maily. Pro nové maily je třeba simulaci restartovat"), "body");
                form.Add(new StringContent("Konec simulace"), "subject");

                // Add the file
                var fileContent = new ByteArrayContent(File.ReadAllBytes(@"../../Mails/Test.txt"));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                form.Add(fileContent, "attachment", Path.GetFileName(@"../../Mails/Test.txt"));

                HttpResponseMessage response = await client.PostAsync(url, form);
                // Check the response
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString(), "Error");
                }
            }
        }

        /// <summary>
        /// Sends a post request to a web server that passes this data to a python script that will use the data to send mail.
        /// Send new order with attachment
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public async Task SendOrderPDFfile(Order o, SmallInfoPanel SmallInfoPanel)
        {
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(smtpServer), "smtp_server");
                form.Add(new StringContent(smtpPort), "smtp_port");
                form.Add(new StringContent(senderMail), "smtp_user");
                form.Add(new StringContent(smtpPassword), "smtp_pass");
                form.Add(new StringContent(recieverMail), "rec_mail");
                form.Add(new StringContent("Prosím zadat novou objednávku v příloze."), "body");
                form.Add(new StringContent("Nová objednávka"), "subject");

                // Add the file
                ByteArrayContent fileContent = new ByteArrayContent(File.ReadAllBytes(@"../../Mails/Objednavky/" + o.PdfFile));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                form.Add(fileContent, "attachment", Path.GetFileName(@"../../Mails/Objednavky/" + o.PdfFile));

                // Send the POST request
                HttpResponseMessage response;
                string result = "";
                try
                {
                    response = await client.PostAsync(url, form);
                    result = await response.Content.ReadAsStringAsync();
                    if (result.Contains("Email sent successfully!"))
                    {
                        result = "Email odeslán!";
                    }
                    else
                    {
                        result = "Připojeno k servru, ale mail asi nebyl odeslán!";
                    }
                }
                catch (Exception ex) { result = "Nezdařilo se připojit k servru!"; }
                OnMailConfirmation(result, SmallInfoPanel);
            }         
        }
        /// <summary>
        /// Sends a change to an order to a mail in app.config. Not implemented!!
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public async Task SendOrderChange(Order o, Change c)
        {
            string url = "http://35.204.7.129/"; // Replace with your server's IP or domain

            using (var client = new HttpClient())
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent("smtp.seznam.cz"), "smtp_server");
                form.Add(new StringContent("587"), "smtp_port");
                form.Add(new StringContent("Mail_Bomber@seznam.cz"), "smtp_user");
                form.Add(new StringContent("Bomber202"), "smtp_pass");
                form.Add(new StringContent("radek.vinarsky@post.cz"), "rec_mail");
                form.Add(new StringContent("TEST"), "body");
                form.Add(new StringContent(o.Reference), "subject");

                //Send the POST request
                HttpResponseMessage response = await client.PostAsync(url, form);

                // Check the response
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response from server: ");
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Error sending request: " + response.StatusCode);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Mail_Bomber
{
    internal class SmallInfoPanel : Panel
    {
        public int ID;
        private Label lblSubject;
        private Label lblAttachment;
        private Button btnViewAttachment;
        private Label lblConformation;


        public SmallInfoPanel(string subject, string attachment)
        {
            // Initialize the panel size and border
            this.Size = new System.Drawing.Size(299, 100);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(0,2,0,2);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AutoScroll = true;

            // Initialize and set up the subject label
            lblSubject = new Label();
            lblSubject.Text = $"Subject: {subject}";
            lblSubject.AutoSize = true;
            lblSubject.Location = new System.Drawing.Point(10, 10);
            this.Controls.Add(lblSubject);

            // Initialize and set up the attachment label
            lblAttachment = new Label();
            lblAttachment.Text = $"Attachment: {attachment}";
            lblAttachment.AutoSize = true;
            lblAttachment.Location = new System.Drawing.Point(10, 30);
            this.Controls.Add(lblAttachment);

            // Initialize and set up the button to view the attachment
            btnViewAttachment = new Button();
            btnViewAttachment.Text = "View";
            btnViewAttachment.Location = new System.Drawing.Point(10, 50);
            btnViewAttachment.Click += (sender, e) => ViewAttachment(attachment);
            this.Controls.Add(btnViewAttachment);

            this.Refresh();
        }

        private void ViewAttachment(string attachmentPath)
        {
            // Code to view the attachment, e.g., open the file
            MessageBox.Show($"Viewing attachment: {attachmentPath}");
        }

        public override string ToString()
        {
            return "TEST return infopanel";
        }
    }
}

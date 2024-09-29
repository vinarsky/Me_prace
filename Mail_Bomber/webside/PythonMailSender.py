import sys
import smtplib
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart
from email.mime.base import MIMEBase
from email import encoders
import os

def send_email(smtp_server, smtp_port, username, password, recipient_email, subject, body, attachment_path):
	try:
		# Set up the server
		server = smtplib.SMTP(smtp_server, smtp_port)
		server.starttls()
		# Secure the connection
		server.login(username, password)

		msg = MIMEMultipart()
		msg['From'] = username
		msg['To'] = recipient_email
		msg['Subject'] = subject

		# Attach the body with the msg instance
		msg.attach(MIMEText(body, 'plain'))

		# Open the file to be sent
		filename = os.path.basename(attachment_path)
		with open(attachment_path, "rb") as attachment:
			# Instance of MIMEBase and named as part
			part = MIMEBase('application', 'octet-stream')
			# Change the payload into encoded form
			part.set_payload(attachment.read())
			# Encode into base64
			encoders.encode_base64(part)
			part.add_header(
				'Content-Disposition',
				f'attachment; filename= {filename}',
			)
			# Attach the instance 'part' to instance 'msg'
			msg.attach(part)

        	# Send the email
		server.sendmail(username, recipient_email, msg.as_string())

	        # Terminate the SMTP session and close the connection
		server.quit()

		return "Email sent successfully!"
	except Exception as e:
		return f"Failed to send email: {str(e)}"

if __name__ == "__main__":
    smtp_server = sys.argv[1]
    smtp_port = int(sys.argv[2])
    username = sys.argv[3]
    password = sys.argv[4]
    recipient_email = sys.argv[5]
    subject = sys.argv[6]
    body = sys.argv[7]
    attachment_path = sys.argv[8]

    result = send_email(smtp_server, smtp_port, username, password, recipient_email, subject, body, attachment_path)
    print(result)

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Send Email with Attachments</title>
</head>


<body>
<?php
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        $smtp_server = escapeshellarg($_POST['smtp_server']);
        $smtp_port = escapeshellarg($_POST['smtp_port']);
        $smtp_user = escapeshellarg($_POST['smtp_user']);
        $smtp_pass = escapeshellarg($_POST['smtp_pass']);
        $rec_mail = escapeshellarg($_POST['rec_mail']);
        $subject = escapeshellarg($_POST['subject']);
        $body = escapeshellarg($_POST['body']);

	$upload_dir = '/var/www/html/uploads/';
        $path = '';
        if (isset($_FILES['attachment']) && $_FILES['attachment']['error'] == UPLOAD_ERR_OK) {
            $path = $upload_dir . basename($_FILES['attachment']['name']);
            if (!move_uploaded_file($_FILES['attachment']['tmp_name'], $path)) {
                echo "Failed to upload file.";
                exit;
            }
            $path = escapeshellarg($path);
        } else {
            echo "No attachment provided or file upload error.";
            exit;
        }

	$Command = "python3 /var/www/html/scripts/PythonMailSender.py $smtp_server $smtp_port $smtp_user $smtp_pass $rec_mail $subject $body $path";
$output = shell_exec($Command);
	echo $Command;
	echo $output;
}
echo "Šimon smrdí";

?>
</body>
</html>

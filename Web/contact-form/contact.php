<?php



// -------------------------------------------
// --- ENTER YOUR NAME & EMAIL ADDRESS HERE
// 
//     FOR EXAMPLE: $sendTo = 'David Parrelli <david@example.com>';
//
// -------------------------------------------


$from = 'Contact form <your_email@example.com>';
$sendTo = 'Your name <your_email@example.com>';


// -------------------------------------------





// You can also configure these values if you know what you are doing

$subject = 'New message from your website contact form';
$fields = array('name' => 'Name', 'surname' => 'Surname', 'phone' => 'Phone', 'email' => 'Email', 'message' => 'Message'); // array variable name => Text to appear in the email
$okMessage = 'Your message has been successfully submitted.';
$errorMessage = 'There was an error while submitting the form. Please try again.';

// let's do the sending

try
{
    $emailText = "You have a new message from your website contact form\n=============================\n";

    foreach ($_POST as $key => $value) {

        if (isset($fields[$key])) {
            $emailText .= "$fields[$key]: $value\n";
        }
    }

    $headers = array('Content-Type: text/plain; charset=iso 8859-1;',
        'MIME-Version: 1.0',
        'From: ' . $from,
        'Reply-To: ' . $from,
        'Return-Path: ' . $from,
    );
    
    mail($sendTo, $subject, $emailText, implode("\r\n", $headers));

    $responseArray = array('type' => 'success', 'message' => $okMessage);
}
catch (\Exception $e)
{
    $responseArray = array('type' => 'danger', 'message' => $errorMessage);
}

if (!empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest') {
    $encoded = json_encode($responseArray);

    header('Content-Type: application/json');

    echo $encoded;
}
else {
    echo $responseArray['message'];
}
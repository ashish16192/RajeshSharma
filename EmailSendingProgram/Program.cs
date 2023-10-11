using System;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main()
    {
        // Sender's email address and credentials
        string senderEmail = "garg16192@gmail.com";
        string senderPassword = "Ashi@1234";

        // Recipient's email address
        string recipientEmail = "harshkumar@sourcemash.com";

        // Create a new MailMessage
        MailMessage mail = new MailMessage(senderEmail, recipientEmail);

        // Set the subject and body of the email
        mail.Subject = "Hello, this is a test email";
        mail.Body = "This is the email body.";

        // Create a new SmtpClient (for sending the email)
        SmtpClient smtpClient = new SmtpClient("smtp.outlook.com");

        // Set the SMTP client's credentials (sender's email and password)
        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

        // Specify the SMTP server's port (usually 587 for TLS/SSL)
        smtpClient.Port = 587;

        // Enable SSL/TLS (true for most email providers)
        smtpClient.EnableSsl = true;

        try
        {
            // Send the email
            smtpClient.Send(mail);
            Console.WriteLine("Email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Email sending failed: " + ex.Message);
        }
        finally
        {
            // Dispose of the SmtpClient and MailMessage objects
            smtpClient.Dispose();
            mail.Dispose();
        }
    }
}

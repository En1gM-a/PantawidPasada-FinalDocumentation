using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace PantawidPasada
{
    public class EmailService
    {
        private string smtpHost = "smtp.gmail.com";
        private int smtpPort = 587;

        // ⚠️ Use an App Password (NOT your real Gmail password)
        private string senderEmail = "pantawidpasada05@gmail.com";
        private string senderPassword = "ppkb qjzs kqgh gdrm";

        public void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient(smtpHost, smtpPort);
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Email failed: " + ex.Message);
            }
        }
    }
}
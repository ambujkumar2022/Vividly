using Microsoft.AspNetCore.Cors;
using System.Net;
using System.Net.Mail;

namespace Vividly
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "tutorialseu_dev@outlook.com";
            var pass = "test123456!";

            var client = new SmtpClient("spmtp_mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pass)
            };

            return client.SendMailAsync(
                  new MailMessage(from: mail,
                                   to: mail,
                                   subject,
                                   message));
        }
    }
}
 
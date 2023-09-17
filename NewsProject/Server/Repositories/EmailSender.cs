using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace NewsProject.Server.Repositories
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailSender = "";
            var password = "";
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailSender);
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = $"<html><body>{htmlMessage}</html></body>";
            mailMessage.IsBodyHtml = true;
            using(SmtpClient _smtpClient = new SmtpClient())
            {
                _smtpClient.EnableSsl = true;
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential(emailSender, password);
                _smtpClient.Host = "smtp.gmail.com";
                _smtpClient.Port = 587;
                _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                _smtpClient.Send(mailMessage);
            }
        }
    }
}

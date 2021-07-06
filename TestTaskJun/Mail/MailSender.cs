using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TestTaskJun.Models
{
    public class MailSender //вынести из функции и сделать не статиком и вынести в реквестхендлер
    {
        private const string Email = "artem15mulo@gmail.com";
        private const string Password = "";
        private const string Host = "smtp.gmail.com";
        private const int Port = 587;
        private static MailAddress _senderAddress;
        private static SmtpClient _smtpClient;

        public MailSender()
        {
            _senderAddress = new MailAddress(Email);
         
            _smtpClient = new SmtpClient(Host, Port)
            {
                Credentials = new NetworkCredential(Email, Password),
                EnableSsl = true
            };
        }

        public async Task<string> SendEmailAsync(Mail mail)
        {
            MailAddress recipientAddress = new MailAddress(mail.Recipient);
            
            MailMessage message = new MailMessage(_senderAddress, recipientAddress)
            {
                Subject = mail.Subject, Body = mail.Body
            };
            
            
            string failedMessage = "";
            try
            {
                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                failedMessage = ex.ToString();
            }
            
            return failedMessage;
        }
    }
}
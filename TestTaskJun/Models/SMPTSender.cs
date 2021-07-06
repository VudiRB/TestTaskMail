using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TestTaskJun.Models
{
    public static class SMPTSender
    {
        private const string Email = "artem15mulo@gmail.com";
        private const string Password = "123vudIRB";
        private const string Host = "smtp.gmail.com";
        private const int Port = 587;

        public static async Task<string> SendEmailAsync(DataForSendToSMTP dataForSendToSmtp)
        {
            MailAddress senderAddress = new MailAddress(Email);
            MailAddress recipientAddress = new MailAddress(dataForSendToSmtp.Recipient);
            
            MailMessage message = new MailMessage(senderAddress, recipientAddress)
            {
                Subject = dataForSendToSmtp.Subject, Body = dataForSendToSmtp.Body
            };
            
            SmtpClient smtpClient = new SmtpClient(Host, Port)
            {
                Credentials = new NetworkCredential(Email, Password),
                EnableSsl = true
            };
            
            
            string failedMessage = "";
            try
            {
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                failedMessage = ex.ToString();
            }
            
            return failedMessage;
        }
    }
}
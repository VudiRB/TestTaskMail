using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Configuration;

namespace TestTaskJun.Mail
{
    /// <summary>
    /// This class organizes the connection to the SMTP server
    /// and sending a message to the recipient.
    /// </summary>
    public class MailSender
    {
        private static MailAddress _senderAddress;
        private static SmtpClient _smtpClient;
        
        /// <summary>
        /// Constructor of the class.
        /// When it is called, a connection to the SMTP server is created
        /// based on the data taken from the configuration file.
        /// </summary>
        public MailSender()
        {
            string email = ConfigurationManager.AppSettings.Get("Email");
            string password = ConfigurationManager.AppSettings.Get("Password");
            string host = ConfigurationManager.AppSettings.Get("Host");
            string port = ConfigurationManager.AppSettings.Get("Port");
            _senderAddress = new MailAddress(email);
         
            _smtpClient = new SmtpClient(host, int.Parse(port))
            {
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true
            };
        }
        /// <summary>
        /// Asynchronous method of sending a message.
        /// On the established connection, it sends message to the SMTP server.
        /// </summary>
        /// <param name="mail">
        /// A parameter of the Mail type.
        /// Contains information about the subject, the text and the recipient of the message.
        /// </param>
        /// <returns>
        /// Returns an empty message if the sending was successful and an error message otherwise.
        /// </returns>
        public async Task<string> SendEmailAsync(Mail mail)
        {
            string failedMessage = "";
            try
            {
                MailAddress recipientAddress = new MailAddress(mail.Recipient); 
                MailMessage message = new MailMessage(_senderAddress, recipientAddress) 
                {
                   Subject = mail.Subject, Body = mail.Body
                };
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
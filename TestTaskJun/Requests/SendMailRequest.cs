using System;
using TestTaskJun.Mail;
using TestTaskJun.Models;

namespace TestTaskJun.Requests
{
    public class SendMailRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string[] Recipients { get; set; }
        
        private readonly MailSender _mailSender = new MailSender();

        private bool _isHandled;
        public async void Handle()
        {
            if (_isHandled) return;
            foreach (string recipient in Recipients)
            {
                Mail.Mail mail = new Mail.Mail
                {
                    Body = Body, 
                    Subject = Subject, 
                    Recipient = recipient
                };
                string failedMessage = await _mailSender.SendEmailAsync(mail);
                
                MailLog mailLog = new MailLog
                {
                    Body = mail.Body,
                    Subject = mail.Subject,
                    Recipient = mail.Recipient,
                    Date = DateTime.Now,
                    FailedMessage = failedMessage,
                    Result = failedMessage != "" ? $"{ResultState.Failed}" : $"{ResultState.Ok}"
                };
                MailLog.InsertMail(mailLog);
            }

            _isHandled = true;
        }
    }
}
using System;
using TestTaskJun.Models;

namespace TestTaskJun
{
    public static class RequestBodyHandler
    {
        private static MailSender _mailSender = new MailSender();
        public static async void EvaqluteReques(DataFromRequest dataFromRequest)
        {
            foreach (string recipient in dataFromRequest.Recipients)
            {
                Mail mail = new Mail
                {
                    Body = dataFromRequest.Body, 
                    Subject = dataFromRequest.Subject, 
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
                    Result = failedMessage != "" ? ResultState.Failed : ResultState.OK
                };
                MailLog.InsertMail(mailLog);
            }
        }
    }
}
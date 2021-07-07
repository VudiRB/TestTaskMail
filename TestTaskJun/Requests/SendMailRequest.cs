using System;
using TestTaskJun.Mail;
using TestTaskJun.Models;

namespace TestTaskJun.Requests
{
    /// <summary>
    /// This class contains a model of the data that comes in a POST request,
    /// and a method for processing this data.
    /// </summary>
    public class SendMailRequest
    {
        /// <summary>
        /// A field that contains information about the subject of the message from the request.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// A field that contains information about the body of the message from the request.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// A field that contains information about the array
        /// of recipients of the message from the request.
        /// </summary>
        public string[] Recipients { get; set; }
        
        private readonly MailSender _mailSender = new MailSender();

        private bool _isHandled;
        /// <summary>
        /// A method that checks whether this request is currently being processed
        /// and whether the request body has an array of message recipients.
        /// In case of passing the checks, a message is generated for each recipient and sent.
        /// Based on the results of sending, a record is formed for writing to the database.
        /// </summary>
        public async void Handle()
        {
            if (_isHandled || Recipients == null) return;
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
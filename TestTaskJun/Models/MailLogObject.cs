using System;

namespace TestTaskJun.Models
{
    public class MailLogObject
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipient { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
    }
}
using System;

namespace TestTaskJun.Models
{
    public static class RequestBodyHandler
    {
        public static async void EvaqluteReques(DataFromRequest dataFromRequest)
        {
            foreach (string recipient in dataFromRequest.Recipients)
            {
                DataForSendToSMTP dataForSendToSmtp = new DataForSendToSMTP
                {
                    Body = dataFromRequest.Body, 
                    Subject = dataFromRequest.Subject, 
                    Recipient = recipient
                };
                string failedMessage = await SMPTSender.SendEmailAsync(dataForSendToSmtp);
                
                MailLogObject mailLogObject = new MailLogObject
                {
                    Body = dataForSendToSmtp.Body,
                    Subject = dataForSendToSmtp.Subject,
                    Recipient = dataForSendToSmtp.Recipient,
                    Date = DateTime.Now,
                    FailedMessage = failedMessage,
                    Result = failedMessage != "" ? ResultState.Failed : ResultState.OK
                };
                DBHandler.InsertMail(mailLogObject);
            }
        }
    }
}
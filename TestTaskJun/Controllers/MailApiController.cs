using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestTaskJun.Models;
using TestTaskJun.Requests;

namespace TestTaskJun.Controllers
{
    /// <summary>
    /// This class is the only controller of this application.
    /// It processes get and post requests along the api/mail path.
    /// </summary>
    [ApiController]
    [Route(Routes.Mails)]
    public class MailApiController : ControllerBase
    {
        /// <summary>
        /// This method requests data from the database and returns it to the requester.
        /// </summary>
        /// <returns>
        /// Returns an enumerated collection of MailLog type data that ASP results in JSON
        /// </returns>
        [HttpGet]
        public IEnumerable<MailLog> Get()
        {
            IEnumerable<MailLog> mails = MailLog.GetAllMails();
            return mails;
        }
        
        /// <summary>
        /// This method sends for processing the data received in the POST request
        /// and given by the ASP to the Mail type
        /// </summary>
        /// <param name="sendMailRequest">
        /// Accepts a parameter converted to the SendMailRequest type from JSON using ASP.
        /// The request body must match the structure specified in the task.
        /// </param>
        [HttpPost]
        public void Post(SendMailRequest sendMailRequest)
        {
            sendMailRequest.Handle();
        }
    }
}
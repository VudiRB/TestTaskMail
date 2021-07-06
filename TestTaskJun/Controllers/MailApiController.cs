using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestTaskJun.Models;
using TestTaskJun.Requests;

namespace TestTaskJun.Controllers
{
    [ApiController]
    [Route(Routes.Mails)]
    public class MailApiController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MailLog> Get()
        {
            IEnumerable<MailLog> mails = MailLog.GetMails();
            return mails;
        }
        
        [HttpPost]
        public void Post(SendMailRequest sendMailRequest)
        {
            sendMailRequest.Handle();
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestTaskJun.Models;

namespace TestTaskJun.Controllers
{
    [ApiController]
    [Route("api/mails")]
    public class MailApiController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MailLog> Get()
        {
            List<MailLog> ddd = MailLog.GetMails();
            return ddd;
        }
        
        [HttpPost]
        public void Post(DataFromRequest dataFromRequest)
        {
            RequestBodyHandler.EvaqluteReques(dataFromRequest);
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestTaskJun.Models;

namespace TestTaskJun.Controllers
{
    [ApiController]
    [Route("api/mails")]
    public class MainApiController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MailLogObject> Get()
        {
            List<MailLogObject> ddd = DBHandler.GetMails();
            return ddd;
        }
        
        [HttpPost]
        public void Post(DataFromRequest dataFromRequest)
        {
            RequestBodyHandler.EvaqluteReques(dataFromRequest);
        }
    }
}
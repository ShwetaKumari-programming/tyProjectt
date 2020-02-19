using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace ElmechProject.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        
        public IHttpActionResult Get()
        {
            MailMessage mail = new MailMessage("Project.grpid23@gmail.com", "panchaljaimin22@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.Subject = "Subject";
            mail.Body = "Body";
            client.Credentials = new System.Net.NetworkCredential("Project.grpid23@gmail.com", "Disha@123");


            client.Send(mail);
            return Ok();
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

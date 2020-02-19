using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Views;
using System.Net.Mail;

namespace ElmechProject.Controllers
{
    [RoutePrefix("api/InquiryManage")]
    public class InquiryManagementController : ApiController
    {
        [Route("GetInquiry")]
        public IHttpActionResult GetInquiryInfo()
        {
            List<InquiryInfoView> details = new List<InquiryInfoView>();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.InquiryMasters.Where(t => t.Id != 0).Select(t => new InquiryInfoView()
                {
                    Id = t.Id,
                    Subject = t.Subject,
                    Details = t.Details,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    CompanyName = t.CompanyName,
                    Email = t.Email,
                    Telephone = t.Telephone,
                    State = t.State,
                    City = t.City
                }).ToList();



            };

            return Ok(details);
        }
        [Route("SendResponse")]
        public IHttpActionResult SendResponse(InquiryResponseView data)
        {
            using (ElmechContext context = new ElmechContext())
            {
                InquiryMaster obj = context.InquiryMasters.Where(t => t.Id == data.Id).FirstOrDefault();
                try
                {
                    MailMessage mail = new MailMessage("Project.grpid23@gmail.com", obj.Email);
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Host = "smtp.gmail.com";
                    mail.Subject = "Successfully Order Confirm in ElmechIndustries ";
                    mail.Body = data.Message;
                    client.Credentials = new System.Net.NetworkCredential("Project.grpid23@gmail.com", "Disha@123");
                    client.Send(mail);

                }
                catch (Exception ex)
                {
                }
                obj.State = "replied";
                context.SaveChanges();

                return Ok();
            }
        }
    }
}

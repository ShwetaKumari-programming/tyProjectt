using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
namespace ElmechProject.Controllers
{
    [Authorize]
    [RoutePrefix("api/CheckOut")]
    public class CheckOutController : ApiController
    {
        [Route("SaveOrder")]
        public IHttpActionResult PostCatalog(List<OrderItem> orderItem)
        {
            Order order = new Order();
            using (ElmechContext context = new ElmechContext())
            {
                order.UserId = User.Identity.GetUserId();
                order.Status = "Pending";
                order.CreatedDate = DateTime.Now;
                context.Orders.Add(order);
                context.SaveChanges();

                foreach (OrderItem obj in orderItem)
                {
                    obj.OrderId = order.Id;
                }

                context.OrderItems.AddRange(orderItem);
                context.SaveChanges();

            };

            return Ok(order);
        }

        [Route("UpdateOrder")]
        public IHttpActionResult PutCatalog(Order order)
        {

            using (ElmechContext context = new ElmechContext())
            {
                Order orderObj = context.Orders.Where(t => t.Id == order.Id).FirstOrDefault();
                orderObj.PaymentMethod = order.PaymentMethod;

                context.SaveChanges();

            };

            return Ok(order);
        }
        [Route("UpdateOrderConfirm")]
        public IHttpActionResult PutUpdateOrderConfirm(Order order)
        {

            using (ElmechContext context = new ElmechContext())
            {
                Order orderObj = context.Orders.Where(t => t.Id == order.Id).FirstOrDefault();
                orderObj.Confirmation = true;
                orderObj.TotalAmount = order.TotalAmount;
                context.SaveChanges();
                AspNetUser obj = context.AspNetUsers.Where(t => t.Id == orderObj.UserId).FirstOrDefault();
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
                    mail.Body = "Thank you for Ordering Product in ElmechIndustries. Your Order Id is "+ orderObj.Id;
                    client.Credentials = new System.Net.NetworkCredential("Project.grpid23@gmail.com", "Disha@123");
                    
                    client.Send(mail);

                    //string callbackUrl = Url.Link("DefaultApp", new { Controller = "Account/ConfirmEmail", userId = user.Id, code = code });
                    //await UserManager.SendEmailAsync(user.Id, "Confirm your Email", "please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                }
                catch (Exception ex)
                {
                }


                

            };

            return Ok(order);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Views;
using Data;

namespace ElmechProject.Controllers
{
    [Authorize]
    [RoutePrefix("api/Registration")]
    public class RegistrationController : ApiController
    {
        [Route("GetUser")]
        public IHttpActionResult Getuser()
        {

            string userId = User.Identity.GetUserId();

            UserInfoView userInfo = new UserInfoView();
            using (ElmechContext context = new ElmechContext())
            {
                userInfo = context.AspNetUsers.Where(t => t.Id == userId).Select(t => new UserInfoView()
                {
                    Id = t.Id,
                    Address1 = t.Address1,
                    Address2 = t.Address2,
                    City = t.City,
                    Email = t.Email,
                    Name = t.Name,
                    PhoneNumber = t.PhoneNumber
                }).FirstOrDefault();

            };

            return Ok(userInfo);
        }

        [Route("savebillingInfo")]
        public IHttpActionResult PostbillingInfo(BillingInfo billingInfo)
        {
            using (ElmechContext context = new ElmechContext())
            {
                billingInfo.Userid = User.Identity.GetUserId();
                context.BillingInfoes.Add(billingInfo);
                context.SaveChanges();
            };

            return Ok(billingInfo);
        }
    }
}

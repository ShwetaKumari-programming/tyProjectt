using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Views;

namespace ElmechProject.Controllers
{
    [RoutePrefix("api/UserManage")]
    public class UserManagementController : ApiController
    {
        [Route("GetUser")]
        public IHttpActionResult GetUserInfo()
        {
            List<UserView> details = new List<UserView>();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.AspNetUsers.Where(t => t.Id != null).Select(t => new UserView()
                {
                    Id = t.Id,
                  Name=t.Name,
                  Address1=t.Address1,
                  Address2=t.Address2,
                  City=t.City,
                  State=t.State,
                  Country=t.Country,
                  UserType=t.UserType,
                  IsDeleted=t.IsDeleted,
                  Email=t.Email,
                  EmailConfirmed=t.EmailConfirmed,
                  PasswordHash=t.PasswordHash,
                  SecurityStamp=t.SecurityStamp,
                  PhoneNumber=t.PhoneNumber,
                  PhoneNumberConfirmed=t.PhoneNumberConfirmed,
                  TwoFactorEnabled=t.TwoFactorEnabled,
                  LockoutEndDateUtc=t.LockoutEndDateUtc,
                  LockoutEnabled=t.LockoutEnabled,
                  AccessFailedCount=t.AccessFailedCount,
                  UserName=t.UserName
                }).ToList();



            };

            return Ok(details);
        }
    }
}

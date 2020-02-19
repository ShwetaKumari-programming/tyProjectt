using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Microsoft.AspNet.Identity;
using Views;

namespace ElmechProject.Controllers
{
    [Authorize]
    [RoutePrefix("api/Payment")]
    public class PaymentController : ApiController
    {

        //[Route("savePaymentInfo")]
        //public IHttpActionResult PostbillingInfo(Payment paymentinfo)
        //{


        //    using (ElmechContext context = new ElmechContext())
        //    {
               
        //        paymentinfo.UserId = User.Identity.GetUserId();
        //        context.Payments.Add(paymentinfo);
        //        context.SaveChanges();


        //    };

        //    return Ok(paymentinfo);
        //}
    }
}

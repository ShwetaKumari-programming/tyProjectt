using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElmechProject.Controllers
{
   
    [RoutePrefix("api/Inquiry")]

    public class InquiryController : ApiController
    {
        [Route("saveInquiryInfo")]
        public IHttpActionResult PostInquiryInfo(InquiryMaster InquiryInfo)
        {
            try
            {
                using (ElmechContext context = new ElmechContext())
                {
                    InquiryInfo.State = "new Inquiry";
                    context.InquiryMasters.Add(InquiryInfo);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return Ok(InquiryInfo);
        }

    }
}

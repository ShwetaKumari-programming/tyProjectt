using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Views;
using Data;

namespace ElmechProject.Controllers
{

    [RoutePrefix("api/Sinfo")]
    public class SampleController : ApiController
    {

        [Route("GetSinfo")]
        public IHttpActionResult GetSampleInfo()
        {
            //List<SampleInfoView> detail = new List<SampleInfoView>();
            List<SampleTable> detail = new List<SampleTable>();
       
            using (ElmechContext context = new ElmechContext())
            {
                detail = context.SampleTables.Where(t => t.Id != 0).ToList();


                         };

            return Ok(detail);
        }

        [Route("saveInfo")]
        public IHttpActionResult SaveInfo(SampleTable sampleinfo)
        {
            using (ElmechContext context = new ElmechContext())
            {

                //if (sampleinfo.Id > 0)
                //{
                //    SampleTable Sinfo = context.SampleTables.Where(t => t.Id == sampleinfo.Id).FirstOrDefault();
                //    Sinfo.Name = sampleinfo.Name;
                //    Sinfo.Address = sampleinfo.Address;
                //    Sinfo.Telephone = sampleinfo.Telephone;

                //}
                //else
                //{

                    context.SampleTables.Add(sampleinfo);
            //    }

               context.SaveChanges();
            };
            return Ok();
        }


        [Route("UpdateSInfo")]
        public IHttpActionResult PutSInfo(SampleTable info)
        {

            using (ElmechContext context = new ElmechContext())
            {
                SampleTable newinfo = context.SampleTables.Where(t => t.Id == info.Id).FirstOrDefault();
                newinfo.Name = info.Name;
                newinfo.Address = info.Address;
                newinfo.Telephone = info.Telephone;

                context.SaveChanges();

            };

            return Ok(info);
        }


        [Route("DeleteSInfo")]
        public IHttpActionResult DeleteSInfo(SampleTable info)
        {

            using (ElmechContext context = new ElmechContext())
            {
                var details = context.SampleTables.Where(t => t.Id == info.Id).FirstOrDefault();
                if (details != null)
                {

                    context.Entry(details).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();

                };

                return Ok(info);
            };
        }



    }

}




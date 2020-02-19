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
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        [Route("GetProduct")]
        public IHttpActionResult GetProduct()
        {
            List<CatagoryView> catagorys = new List<CatagoryView>();
            using (ElmechContext context = new ElmechContext())
            {
                catagorys = context.CatagoryMasters.Where(t => t.DelateFlag != true).Select(t => new CatagoryView()
                {
                    DelateFlag = t.DelateFlag,
                    Description = t.Description,
                    Id = t.Id,
                    Name = t.Name
                }).ToList();

                foreach(CatagoryView obj in catagorys)
                {
                    obj.products = context.ProductMasters.Where(t => t.DeleteFlag != true && t.CatagoryId == obj.Id).ToList();
                }

            };

            return Ok(catagorys);
        }

    }
}

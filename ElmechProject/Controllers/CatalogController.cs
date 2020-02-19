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
    [RoutePrefix("api/Catalog")]
    public class CatalogController : ApiController
    {
        [Route("GetCatalog")]
        public IHttpActionResult GetCatalog()
        {
            List<CatalogView> catagorys = new List<CatalogView>();
            using (ElmechContext context = new ElmechContext())
            {
                catagorys = context.CatalogMasters.Where(t => t.DeleteFlag != true).Select(t => new CatalogView()
                {
                    DelateFlag = t.DeleteFlag,
                    PDFurl = t.PDFurl,
                    Thumbnail=t.Thumbnail,
                    Id = t.Id,
                    Name = t.Name
                }).ToList();

               
            };

            return Ok(catagorys);
        }

    }
}

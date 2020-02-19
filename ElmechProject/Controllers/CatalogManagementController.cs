using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Views;

namespace ElmechProject.Controllers
{
    [RoutePrefix("api/CatalogManage")]
    public class CatalogManagementController : ApiController
    {
        private object ImageFormat;

        [Route("GetCatalog")]
        public IHttpActionResult GetInquiryInfo()
        {
            List<CatalogView> details = new List<CatalogView>();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.CatalogMasters.Where(t => t.Id != 0).Select(t => new CatalogView()
                {
                    Id = t.Id,
                    Name = t.Name,
                    PDFurl = t.PDFurl,
                    Thumbnail = t.Thumbnail,
                    DelateFlag = t.DeleteFlag

                }).ToList();



            };

            return Ok(details);
        }

        [Route("DeleteCatalog/{catalogId}")]
        public IHttpActionResult Deletecatalog(int catalogId)
        {

            using (ElmechContext context = new ElmechContext())
            {
                var details = context.CatalogMasters.Where(t => t.Id == catalogId).FirstOrDefault();
                if (details != null)
                {

                    context.Entry(details).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();

                };

                return Ok();

            };


        }


        [Route("GetCatalogById/{catalogId}")]
        public IHttpActionResult GetCatalogInfoById(int catalogId)
        {
            //int categoryId = 1;
            CatalogView details = new CatalogView();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.CatalogMasters.Where(t => t.Id == catalogId).Select(t => new CatalogView()
                {
                    Id = t.Id,
                    Name = t.Name,
                    PDFurl = t.PDFurl,
                    Thumbnail = t.Thumbnail,
                    DelateFlag = t.DeleteFlag


                }).FirstOrDefault();



            };

            return Ok(details);
        }

        [Route("saveCatalog")]
        public IHttpActionResult saveCatalog(CatalogMaster cataloginfo)
        {
            try
            {
                using (ElmechContext context = new ElmechContext())
                {
                    var epoch = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    string pdfName = epoch.ToString() + ".pdf";
                    string thumbnail = epoch.ToString() + ".jpg";

                    //cataloginfo.Thumbnail
                    //    cataloginfo.PDFurl


                    cataloginfo.Thumbnail = cataloginfo.Thumbnail.Replace("data:image/jpg;base64,", String.Empty).Replace("data:image/png;base64,", String.Empty).Replace("data:image/jpeg;base64,", String.Empty);

                    byte[] imageBytes = Convert.FromBase64String(cataloginfo.Thumbnail);
                    MemoryStream msImage = new MemoryStream(imageBytes, 0, imageBytes.Length);

                    System.IO.FileStream streamImage =
     new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Content\\catalogs\\" + thumbnail, FileMode.CreateNew);
                    System.IO.BinaryWriter writerImage =
                        new BinaryWriter(streamImage);
                    streamImage.Write(imageBytes, 0, imageBytes.Length);
                    streamImage.Close();


                    cataloginfo.PDFurl = cataloginfo.PDFurl.Replace("data:application/pdf;base64,", String.Empty);
                    byte[] pdfBytes = Convert.FromBase64String(cataloginfo.PDFurl);
                    MemoryStream msPdf = new MemoryStream(pdfBytes, 0, pdfBytes.Length);

                    System.IO.FileStream stream =
     new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Content\\catalogs\\" + pdfName, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                    writer.Write(pdfBytes, 0, pdfBytes.Length);
                    writer.Close();
                    if (cataloginfo.Id > 0)
                    {
                        CatalogMaster catalog = context.CatalogMasters.Where(t => t.Id == cataloginfo.Id && t.DeleteFlag != true).FirstOrDefault();

                        catalog.Name = cataloginfo.Name;
                        if (!string.IsNullOrEmpty(cataloginfo.Thumbnail) && !string.IsNullOrEmpty(cataloginfo.PDFurl))
                        {
                            cataloginfo.Thumbnail = thumbnail;
                            cataloginfo.PDFurl = pdfName;
                        }
                    }
                    else
                    {

                        cataloginfo.Thumbnail = thumbnail;
                        cataloginfo.PDFurl = pdfName;
                        cataloginfo.DeleteFlag = false;
                        context.CatalogMasters.Add(cataloginfo);
                    }
                    //save folder

                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {

                throw;
            }


            return Ok(cataloginfo);
        }
    }
}

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
    [RoutePrefix("api/ProductManage")]
    public class ProductManagementController : ApiController
    {
        [Route("GetProduct/{categoryId}")]
        public IHttpActionResult GetProductInfo(int categoryId)
        {
            //int categoryId = 1;
            List<ProductInfoView> details = new List<ProductInfoView>();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.ProductMasters.Where(t => t.CatagoryId == categoryId).Select(t => new ProductInfoView()
                {
                    Id = t.Id,
                    CatagoryId = t.CatagoryId,
                    Name = t.Name,
                    CurrentQuantity = t.CurrentQuantity,
                    CurrentPrice = t.CurrentPrice,

                    Description = t.Description,
                    ImageURL = t.ImageURL,
                    DeleteFlag = t.DeleteFlag


                }).ToList();



            };

            return Ok(details);
        }


        [Route("DeleteProduct/{productId}")]
        public IHttpActionResult DeleteProduct(int productId)
        {

            using (ElmechContext context = new ElmechContext())
            {
                var details = context.ProductMasters.Where(t => t.Id == productId).FirstOrDefault();
                if (details != null)
                {

                    context.Entry(details).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();

                };

                return Ok();

            };


        }

        [Route("GetProductById/{productId}")]
        public IHttpActionResult GetProductInfoById(int productId)
        {
            //int categoryId = 1;
            ProductInfoView details = new ProductInfoView();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.ProductMasters.Where(t => t.Id == productId).Select(t => new ProductInfoView()
                {
                    Id = t.Id,
                    CatagoryId = t.CatagoryId,
                    Name = t.Name,
                    CurrentQuantity = t.CurrentQuantity,
                    CurrentPrice = t.CurrentPrice,

                    Description = t.Description,
                    ImageURL = t.ImageURL,
                    DeleteFlag = t.DeleteFlag


                }).FirstOrDefault();



            };

            return Ok(details);
        }

        [Route("saveInfo")]
        public IHttpActionResult saveInfo(ProductMaster productinfo)
        {
            try
            {
                using (ElmechContext context = new ElmechContext())
                {


                    var epoch = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

                    string productimg = epoch.ToString() + ".jpg";

                    if (!string.IsNullOrEmpty(productinfo.ImageURL))
                    {
                        productinfo.ImageURL = productinfo.ImageURL.Replace("data:image/jpg;base64,", String.Empty).Replace("data:image/png;base64,", String.Empty).Replace("data:image/jpeg;base64,", String.Empty);
                        byte[] imageBytes = Convert.FromBase64String(productinfo.ImageURL);
                        MemoryStream msImage = new MemoryStream(imageBytes, 0, imageBytes.Length);

                        System.IO.FileStream streamImage =
         new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Content\\Images\\Product\\" + productimg, FileMode.CreateNew);
                        System.IO.BinaryWriter writerImage =
                            new BinaryWriter(streamImage);
                        streamImage.Write(imageBytes, 0, imageBytes.Length);
                        streamImage.Close();

                        System.IO.FileStream streamImagelarge =
       new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\Content\\Images\\Product-large\\" + productimg, FileMode.CreateNew);
                        System.IO.BinaryWriter writerImagelarge =
                            new BinaryWriter(streamImagelarge);
                        streamImagelarge.Write(imageBytes, 0, imageBytes.Length);
                        streamImagelarge.Close();

                    }

                    if (productinfo.Id > 0)
                    {
                        ProductMaster product = context.ProductMasters.Where(t => t.Id == productinfo.Id && t.DeleteFlag != true).FirstOrDefault();
                        product.CurrentPrice = productinfo.CurrentPrice;
                        product.CurrentQuantity = productinfo.CurrentQuantity;
                        product.Description = productinfo.Description;
                        product.Name = productinfo.Name;
                        if (!string.IsNullOrEmpty(productinfo.ImageURL))
                        {
                            product.ImageURL = productimg;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(productinfo.ImageURL))
                        {
                            productinfo.ImageURL = productimg;
                        }

                        productinfo.DeleteFlag = false;
                        context.ProductMasters.Add(productinfo);
                    }


                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {

                throw;
            }


            return Ok(productinfo);
        }
    }
}

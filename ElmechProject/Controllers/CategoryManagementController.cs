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
    [RoutePrefix("api/CategoryManage")]
    public class CategoryManagementController : ApiController
    {
        [Route("GetCategory")]
        public IHttpActionResult GetCategoryInfo()
        {
            List<CategoryInfoView> details = new List<CategoryInfoView>();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.CatagoryMasters.Where(t => t.Id != 0).Select(t => new CategoryInfoView()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    DelateFlag = t.DelateFlag

                }).ToList();



            };

            return Ok(details);
        }

        [Route("DeleteCategory/{categoryId}")]
        public IHttpActionResult Deletecategory(int categoryId)
        {
            
            using (ElmechContext context = new ElmechContext())
            {
                var details = context.CatagoryMasters.Where(t => t.Id == categoryId).FirstOrDefault();
                if (details != null)
                {

                    List<ProductMaster> products = new List<ProductMaster>();
                    products = context.ProductMasters.Where(t => t.CatagoryId == categoryId).ToList();
                    for (int i = 0; i < products.Count; i++) {
                        context.Entry(products[i]).State = System.Data.Entity.EntityState.Deleted;
                    }
                        
                    context.Entry(details).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();

                    //for (int i = 0; i < product.Count; i++)
                    //{
                    //    var del = context.ProductMasters.Where(t => t.CatagoryId == categoryId).FirstOrDefault();
                    //    context.Entry(del).State = System.Data.Entity.EntityState.Deleted;
                    //    context.SaveChanges();
                    //}


                };

                return Ok();

            };


        }

        [Route("GetCategoryById/{categoryId}")]
        public IHttpActionResult GetCategoryInfoById(int categoryId)
        {
            //int categoryId = 1;
            CatagoryView details = new CatagoryView();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.CatagoryMasters.Where(t => t.Id == categoryId).Select(t => new CatagoryView()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    DelateFlag = t.DelateFlag


                }).FirstOrDefault();



            };

            return Ok(details);
        }





        [Route("saveCategory")]
        public IHttpActionResult saveCategory(CatagoryMaster categoryinfo)
        {
            try
            {
                using (ElmechContext context = new ElmechContext())
                {

                    if (categoryinfo.Id > 0)
                    {
                        CatagoryMaster category = context.CatagoryMasters.Where(t => t.Id == categoryinfo.Id && t.DelateFlag != true).FirstOrDefault();
                        category.Name = categoryinfo.Name;
                        category.Description = categoryinfo.Description;

                    }
                    else {
                        categoryinfo.DelateFlag = false;
                        context.CatagoryMasters.Add(categoryinfo);
                    }
                   
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {

                throw;
            }


            return Ok(categoryinfo);
        }
    }
}

using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Views;
using Microsoft.AspNet.Identity;
namespace ElmechProject.Controllers
{
    [Authorize]
    [RoutePrefix("api/OrderManage")]
    public class OrderManagementController : ApiController
    {

        [Route("GetOrder")]
        public IHttpActionResult GetOrderInfo()
        {
            List<OrderInfoView> details = new List<OrderInfoView>();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.Orders.Where(t => t.Id != 0).Select(t => new OrderInfoView()
                {
                    Id = t.Id,
                    PaymentMethodId = t.PaymentMethod,
                    TotalAmount = t.TotalAmount,
                    Confirmation = t.Confirmation.HasValue ? "Yes" : "No",
                    //UserId = t.UserId,
                    //Status = t.Status
                }).ToList();



            };

            return Ok(details);
        }

        [Route("GetOrderProduct")]
        public IHttpActionResult GetOrderProduct()
        {
            string userId = User.Identity.GetUserId();
            List<OrderInfoView> details = new List<OrderInfoView>();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.Orders.Where(t => t.Id != 0 && t.UserId == userId && t.Confirmation == true).Select(t => new OrderInfoView()
                {
                    Id = t.Id,
                    PaymentMethodId = t.PaymentMethod,
                    PaymentMethod = t.PaymentMethod == 1 ? "Cash On Delivery" : (t.PaymentMethod == 2 ? "Net Banking" : (t.PaymentMethod == 3 ? "Credit Card" : "Debit Card")),
                    TotalAmount = t.TotalAmount,
                    Confirmation = t.Confirmation.HasValue ? "Yes" : "No",
                    StatusName = t.Status,
                    CreatedDate = t.CreatedDate
                }).ToList();
            };

            return Ok(details);
        }
        [Route("GetOrderProduct/{orderId}")]
        public IHttpActionResult GetOrderProduct(int orderId)
        {
            string userId = User.Identity.GetUserId();
            OrderDetails orderDetails = new OrderDetails();
            OrderInfoView details = new OrderInfoView();
            List<OrderItemsInfoView> items = new List<OrderItemsInfoView>();
            using (ElmechContext context = new ElmechContext())
            {
                details = context.Orders.Where(t => t.Id == orderId && t.UserId == userId && t.Confirmation == true).Select(t => new OrderInfoView()
                {
                    Id = t.Id,
                    PaymentMethodId = t.PaymentMethod,
                    PaymentMethod = t.PaymentMethod == 1 ? "Cash On Delivery" : (t.PaymentMethod == 2 ? "Net Banking" : (t.PaymentMethod == 3 ? "Credit Card" : "Debit Card")),
                    TotalAmount = t.TotalAmount,
                    Confirmation = t.Confirmation.HasValue ? "Yes" : "No",
                    StatusName = t.Status,
                    CreatedDate = t.CreatedDate
                }).FirstOrDefault();

                items = (from a in context.OrderItems
                         join
                            b in context.ProductMasters on a.ProductId equals b.Id
                         where a.OrderId == orderId
                         select new OrderItemsInfoView()
                         {
                             OrderId = a.OrderId,
                             Amount = a.Amount,
                             CurrentPrice = a.CurrentPrice,
                             ImageURL = b.ImageURL,
                             Name = b.Name,
                             OrderItemId = a.OrderItemId,
                             ProductId = a.ProductId,
                             Quantity = a.Quantity
                         }
                         ).ToList();



                orderDetails.orderInfoView = new OrderInfoView();
                orderDetails.orderInfoView = details;
                orderDetails.items = new List<OrderItemsInfoView>();
                orderDetails.items = items;
            };

            return Ok(orderDetails);
        }
    }
}

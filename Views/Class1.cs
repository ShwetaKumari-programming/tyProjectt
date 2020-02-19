using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Views
{
    public partial class CatagoryView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? DelateFlag { get; set; }

        public List<ProductMaster> products { get; set; }
    }

    public partial class CatalogView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PDFurl { get; set; }

        public string Thumbnail { get; set; }

        public bool? DelateFlag { get; set; }


    }
    public partial class UserInfoView
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


    }
    public partial class InquiryInfoView
    {
        public int Id { get; set; }

        
        public string Subject { get; set; }

       
        public string Details { get; set; }

      
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string CompanyName { get; set; }

       
        public string Email { get; set; }

       
        public string Telephone { get; set; }

       
        public string State { get; set; }

        
        public string City { get; set; }

    }
    public partial class OrderInfoView
    {
        public int Id { get; set; }

        public int? PaymentMethodId { get; set; }
        public string PaymentMethod { get; set; }

        public long? TotalAmount { get; set; }

        public string Confirmation { get; set; }
       
        public string StatusName { get; set; }
        public int? UserID { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public partial class SampleInfoView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }

    }
    public partial class OrderItemsInfoView
    {
        public long OrderItemId { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public long? CurrentPrice { get; set; }
        public long? Amount { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
    }
    public partial class OrderDetails
    {
        public OrderInfoView orderInfoView { get; set; }

        public List<OrderItemsInfoView> items{ get; set; }
        
    }
    public partial class UserView
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int UserType { get; set; }

        public bool IsDeleted { get; set; }
        
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

      
        public string UserName { get; set; }
    }
    public partial class CategoryInfoView
    {
        public int Id { get; set; }

       
        public string Name { get; set; }

        public string Description { get; set; }

        public bool? DelateFlag { get; set; }
    }
    public partial class ProductInfoView
    {
        public int Id { get; set; }

        public int CatagoryId { get; set; }

       
        public string Name { get; set; }

        public int? CurrentQuantity { get; set; }

        public int? CurrentPrice { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public bool? DeleteFlag { get; set; }
    }
    public partial class InquiryResponseView
    {
        public int Id { get; set; }
        public string Message { get; set; }
        
    }
    }

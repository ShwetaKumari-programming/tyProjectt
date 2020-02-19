namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int Id { get; set; }

        public int? PaymentMethod { get; set; }

        public long? TotalAmount { get; set; }

        public bool? Confirmation { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

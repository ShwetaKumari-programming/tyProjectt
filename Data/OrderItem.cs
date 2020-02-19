namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItem
    {
        public long OrderItemId { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public long? CurrentPrice { get; set; }
        public long? Amount { get; set; }
    }
}

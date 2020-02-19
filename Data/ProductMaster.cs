namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductMaster")]
    public partial class ProductMaster
    {
        public int Id { get; set; }

        public int CatagoryId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? CurrentQuantity { get; set; }

        public int? CurrentPrice { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public bool? DeleteFlag { get; set; }
    }
}

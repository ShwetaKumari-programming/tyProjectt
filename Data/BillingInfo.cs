namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillingInfo")]
    public partial class BillingInfo
    {
        public long Id { get; set; }

        [StringLength(128)]
        public string Userid { get; set; }

        public long? OrderId { get; set; }

        public bool? Same_as_userdetail { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        [StringLength(10)]
        public string Pincode { get; set; }
    }
}

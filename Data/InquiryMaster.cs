namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InquiryMaster")]
    public partial class InquiryMaster
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(300)]
        public string Details { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Telephone { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [StringLength(30)]
        public string City { get; set; }
    }
}

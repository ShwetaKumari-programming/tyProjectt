namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CatagoryMaster")]
    public partial class CatagoryMaster
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool? DelateFlag { get; set; }
    }
}

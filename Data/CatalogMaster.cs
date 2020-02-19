namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CatalogMaster")]
    public partial class CatalogMaster
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string PDFurl { get; set; }

        [StringLength(100)]
        public string Thumbnail { get; set; }

        public bool? DeleteFlag { get; set; }
    }
}

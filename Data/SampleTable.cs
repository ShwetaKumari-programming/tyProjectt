namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SampleTable")]
    public partial class SampleTable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }
    }
}

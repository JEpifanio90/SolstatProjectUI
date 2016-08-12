namespace SolstatProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("solstatdb.countieslocations")]
    public partial class countieslocation
    {
        public int id { get; set; }

        [StringLength(33)]
        public string city { get; set; }

        [StringLength(39)]
        public string name { get; set; }

        public decimal? lat { get; set; }

        public decimal? lng { get; set; }

        public decimal? pop { get; set; }

        [StringLength(32)]
        public string country { get; set; }

        [StringLength(3)]
        public string iso2 { get; set; }

        [StringLength(3)]
        public string iso3 { get; set; }

        [StringLength(43)]
        public string province { get; set; }
    }
}

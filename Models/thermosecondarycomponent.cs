namespace SolstatProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("solstatdb.thermosecondarycomponents")]
    public partial class thermosecondarycomponent
    {
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string components { get; set; }

        public double efficiency { get; set; }

        [Required]
        [StringLength(250)]
        public string comments { get; set; }

        public int? brandID { get; set; }

        public double price { get; set; }
    }
}

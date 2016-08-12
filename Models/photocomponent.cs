namespace SolstatProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("solstatdb.photocomponents")]
    public partial class photocomponent
    {
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string panels { get; set; }
    }
}

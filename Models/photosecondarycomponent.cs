namespace SolstatProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("solstatdb.photosecondarycomponents")]
    public partial class photosecondarycomponent
    {
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string models { get; set; }

        [Required]
        [StringLength(250)]
        public string inverter { get; set; }

        [Required]
        [StringLength(250)]
        public string regulator { get; set; }

        [Required]
        [StringLength(250)]
        public string batery { get; set; }

        [Required]
        [StringLength(250)]
        public string C_bidirectional_meter { get; set; }

        [Required]
        [StringLength(250)]
        public string monitoring_system { get; set; }

        public int panelID { get; set; }

        public int price { get; set; }
    }
}

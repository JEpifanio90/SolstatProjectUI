namespace SolstatProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("solstatdb.components_EE")]
    public partial class components_EE
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codigo { get; set; }

        
        [StringLength(250)]
        public string marcaComercial { get; set; }

        [StringLength(250)]
        public string componente { get; set; }
        

        public double costo { get; set; }

       
        [StringLength(250)]
        public string tipoMoneda { get; set; }

        [StringLength(3)]
        public string tipo { get; set; }
    }
}

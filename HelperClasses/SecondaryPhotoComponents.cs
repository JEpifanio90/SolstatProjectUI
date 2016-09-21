using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolstatProjectUI.HelperClasses
{
    class SecondaryPhotoComponents
    {
        public int id { get; set; }
        public string model { get; set; }
        public string inverter { get; set; }
        public string regulator { get; set; }
        public string batery { get; set; }
        public string bidirectional_meter { get; set; }
        public string monitoring_system { get; set; }
        public string panelName { get; set; }
        public double price { get; set; }
    }
}

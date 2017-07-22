using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
   public class AylikCiro
    {
        public int AylikCiroID { get; set; }
        public string Yil { get; set; }
        public string Ay { get; set; }
        public double ToplamSatis{ get; set; }
        public int ToplamAdet { get; set; }
    }
}

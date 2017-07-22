using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMGunlukToplam
    {
        public string Yil { get; set; }
        public string Ay { get; set; }
        public string Gun { get; set; }
        public double ToplamSatis { get; set; }
        public int ToplamAdet { get; set; }
    }
}

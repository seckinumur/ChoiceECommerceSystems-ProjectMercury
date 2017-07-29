using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMSiparisSepeti
    {
        public List<VMUrun> Urun { get; set; }
        public Uyeler Uye { get; set; }
        public double ToplamFiyat { get; set; }
    }
}

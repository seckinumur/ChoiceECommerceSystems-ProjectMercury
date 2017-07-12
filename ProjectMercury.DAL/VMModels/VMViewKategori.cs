using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMViewKategori
    {
        public List<AltKategori> AltKategoriler { get; set; }
        public List<UrunKategori> ÜrünKategorileri { get; set; }
        public List<Urun> Urunler { get; set; }
        public string KategoriAdi { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
   public class UrunKategori
    {
        public int UrunKategoriID { get; set; }
        public string UrunKategoriAdi { get; set; }
        public int AltKategoriID { get; set; }
    }
}
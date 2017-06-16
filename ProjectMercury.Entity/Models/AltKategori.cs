using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
   public class AltKategori
    {
        public int AltKategoriID { get; set; }
        public string AltKategoriAdi { get; set; }
        public int KategoriID { get; set; }
    }
}
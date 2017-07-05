using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
   public class SanalSepet
    {
        public int SanalSepetID { get; set; }
        public int KullanicilarID { get; set; }
        public int UrunID { get; set; }
        public int Adet { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
        public virtual Urun Urun { get; set; }
    }
}

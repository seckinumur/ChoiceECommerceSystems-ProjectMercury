using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
   public class Siparis
    {
        public int SiparisID { get; set; }
        public int UyelerID { get; set; }
        public string SiparisTarihi { get; set; }
        public string GonderimTarihi { get; set; }
        public bool Onaylandimi { get; set; }
        public bool Gonderildimi { get; set; }

        public virtual List<Urun> Urun { get; set; }
        public virtual Uyeler Uyeler { get; set; }
    }
}

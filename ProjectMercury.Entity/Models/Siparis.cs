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
        public int SepetID { get; set; }
        public string SiparisTarihi { get; set; }
        public string GonderimTarihi { get; set; }
        public string Not { get; set; }
        public bool Onaylandimi { get; set; }
        public bool Gonderildimi { get; set; }
        public bool İptal { get; set; }

        public virtual Sepet Sepet { get; set; }
    }
}

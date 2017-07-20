using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
   public class SanalSepetUye
    {
        public int SanalSepetUyeID { get; set; }
        public int UyelerID { get; set; }
        public int UrunID { get; set; }
        public int Adet { get; set; }

        public virtual Uyeler Uyeler { get; set; }
        public virtual Urun Urun { get; set; }
    }
}

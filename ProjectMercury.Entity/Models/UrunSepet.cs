using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
   public class UrunSepet
    {
        public int UrunSepetID { get; set; }
        public int UrunID { get; set; }
        public int Adedi { get; set; }

        public virtual Urun Urun { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
   public class Satis
    {
        public int SatisID { get; set; }
        public int UrunID { get; set; }
        public int SatisAdedi { get; set; }

        public virtual Urun Urun { get; set; }
    }
}

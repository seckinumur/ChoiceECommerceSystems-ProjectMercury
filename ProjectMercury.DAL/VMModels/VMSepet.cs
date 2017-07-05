using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMSepet
    {
        public int SepetID { get; set; }
        public int UyelerID { get; set; }
        public bool SiparisTamamlandimi { get; set; }
        public bool Manuel { get; set; }

        public virtual List<UrunSepet> UrunSepet { get; set; }
    }
}

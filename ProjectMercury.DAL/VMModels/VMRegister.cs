using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMRegister
    {
        public string EMail { get; set; }
        public string KullaniciSifre { get; set; }
        public string KullaniciSifreTekrar { get; set; }
        public string UyeAdiSoyadi { get; set; }
    }
}

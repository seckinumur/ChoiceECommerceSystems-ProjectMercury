using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMKullanicilar
    {
        public int KullanicilarID { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSifre { get; set; }
        public string Gorev { get; set; }
        public bool Master { get; set; }
        public bool System { get; set; }
    }
}

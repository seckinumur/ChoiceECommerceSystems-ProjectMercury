using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
    public class VMSiparis
    {
        public int SiparisID { get; set; }
        public string Uye { get; set; }
        public int UyeID { get; set; }
        public string SiparisTarihi { get; set; }
        public string GonderimTarihi { get; set; }
    }
}

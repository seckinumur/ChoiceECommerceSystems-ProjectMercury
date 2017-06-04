using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
  public  class VMAnaliz
    {
        public int ToplamUrun { get; set; }
        public int Indirimli { get; set; }
        public int Indirimsiz { get; set; }
        public int OnayBekleyen { get; set; }
        public int Onaylanan { get; set; }
        public int Gönderilen { get; set; }
        public int Gonderilmeyen { get; set; }
        public int Uyeler { get; set; }
        public int Kullanıcılar { get; set; }
    }
}

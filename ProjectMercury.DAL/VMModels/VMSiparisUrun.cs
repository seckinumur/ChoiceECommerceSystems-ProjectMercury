using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
  public  class VMSiparisUrun
    {
        public string Kategori { get; set; }
        public string AltKategori { get; set; }
        public string UrunKategori { get; set; }
        public string Marka { get; set; }
        public string UrunAdi { get; set; }
        public string UrunFiyati { get; set; }
        public double Fiyat { get; set; }
        public string IndirimliFiyati { get; set; }
        public int UrunAdedi { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
  public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public double UrunFiyati { get; set; }
        public double IndirimliFiyati { get; set; }
        public bool IndirimVarmi { get; set; }
        public string UrunAciklama { get; set; }
        public string Image { get; set; }
        public int UrunAdedi { get; set; }
        public int KategoriID { get; set; }
        public int AltKategoriID { get; set; }
        public int UrunKategoriID { get; set; }
        public int MarkaID { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual AltKategori AltKategori { get; set; }
        public virtual UrunKategori UrunKategori { get; set; }
        public virtual Marka Marka { get; set; }
    }
}

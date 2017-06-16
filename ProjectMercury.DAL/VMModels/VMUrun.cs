using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMUrun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunFiyati { get; set; }
        public string IndirimliFiyati { get; set; }
        public bool IndirimVarmi { get; set; }
        public string Gramaj { get; set; }
        public string UrunAciklama { get; set; }
        public string Yorum { get; set; }
        public string Image { get; set; }
        public int UrunAdedi { get; set; }
        public string Kategori { get; set; }
        public string AltKategori { get; set; }
        public string UrunKategori { get; set; }
        public string Marka { get; set; }
        public string Gorev { get; set; }

        public int KategoriID { get; set; }
        public int AltKategoriID { get; set; }
        public int UrunKategoriID { get; set; }
        public int MarkaID { get; set; }
    }
}

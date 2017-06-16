using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMAltKategori
    {
        public int AltKategoriID { get; set; }
        public string AltKategoriAdi { get; set; }
        public string KategoriIsmi { get; set; }
        public bool UrunVarmi { get; set; }
        public string Gorev { get; set; }
    }
}

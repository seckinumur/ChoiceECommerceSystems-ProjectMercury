using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMUrunKategori
    {
        public int UrunKategoriID { get; set; }
        public string UrunKategoriAdi { get; set; }
        public bool UrunVarmi { get; set; }
        public string Gorev { get; set; }
    }
}

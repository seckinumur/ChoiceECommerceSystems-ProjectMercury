using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMKategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public bool UrunVarmi { get; set; }
        public string Gorev { get; set; }
    }
}

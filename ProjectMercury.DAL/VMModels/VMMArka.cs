using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
  public class VMMArka
    {
        public int MarkaID { get; set; }
        public string MarkaAdi { get; set; }
        public bool UrunVarmi { get; set; }
        public string Gorev { get; set; }
    }
}

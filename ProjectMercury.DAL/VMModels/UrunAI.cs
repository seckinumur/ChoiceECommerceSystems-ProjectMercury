using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class UrunAI
    {
        public List<Urun> EnCokSatan { get; set; }
        public List<Urun> EnYeni { get; set; }
        public List<Urun> GununFirsati { get; set; }
    }
}

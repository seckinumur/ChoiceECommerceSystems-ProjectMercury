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
        public string slider1 { get; set; }
        public string slider2 { get; set; }
        public string slider3 { get; set; }
        public string slider4 { get; set; }
    }
}

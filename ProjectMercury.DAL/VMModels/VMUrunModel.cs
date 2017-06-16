using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
  public class VMUrunModel
    {
        public List<Marka> marka { get; set; }
        public List<Kategori> kategori { get; set; }
        public List<AltKategori> altkategoriadi { get; set; }
        public List<UrunKategori> urunkategoriadi { get; set; }
    }
}

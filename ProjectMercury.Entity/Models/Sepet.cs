﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
   public class Sepet
    {
        public int SepetID { get; set; }
        public int UyelerID { get; set; }
        public bool SiparisTamamlandimi { get; set; }
        public bool Aktifmi { get; set; }
        public bool Manuel { get; set; }

        public virtual List<UrunSepet> UrunSepet { get; set; }
        public virtual Uyeler Uyeler { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
   public class VMUyeler
    {
        public int UyelerID { get; set; }
        public string UyeAdiSoyadi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string MailAdresi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Gorev { get; set; }
        public bool Banlimi { get; set; }
        public string Tarih { get; set; }
    }
}

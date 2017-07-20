using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.VMModels
{
  public class VMAyarlar
    {
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string MobilTelefon { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        public string Instagram { get; set; }
        public string Logo { get; set; }
        public string FLogo { get; set; }
        public string SiteAdi { get; set; }
        public string Hakkinda { get; set; }
        public string MailAdresi { get; set; }
        public List<Kullanicilar> Kullanicilar { get; set; }
        public List<Slider> Sliderler { get; set; }
        public string Slider { get; set; }
        public int SliderId { get; set; }

        public string Gorev { get; set; }

        public int KullanicilarID { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSifre { get; set; }
    }
}

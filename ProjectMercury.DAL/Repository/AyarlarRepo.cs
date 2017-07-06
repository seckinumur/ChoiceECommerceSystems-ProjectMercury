using ProjectMercury.DAL.VMModels;
using ProjectMercury.Entity.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.Repository
{
   public class AyarlarRepo
    {
        public static VMAyarlar AyarlariListele() //Ayarları Listele
        {
            using (DBCON db = new DBCON())
            {
                var kullanici = KullanicilarRepo.KullanicilariListele();
                var site = db.SiteBilgileri.FirstOrDefault(p => p.SiteBilgileriID == 1);
                return new VMAyarlar() { Adres = site.Adres, Facebook = site.Facebook, MailAdresi = site.MailAdresi, SiteAdi = site.SiteAdi, Instagram = site.Instagram, Kullanicilar = kullanici, Logo = site.Logo, MobilTelefon = site.MobilTelefon, Telefon = site.Telefon, Twitter = site.Twitter, Whatsapp = site.Whatsapp };
            }
        }
    }
}
//seçkin ben yatıyorum sen database yaratılırken site bilgilerini ekle burada patlıyor null geliyor hadi koçum
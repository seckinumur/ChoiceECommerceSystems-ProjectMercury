using ProjectMercury.Entity.DBContext;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.Repository
{
   public class SiteBilgileriRepo
    {
        public static bool Guncelle(SiteBilgileri Al) //Guncelle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.SiteBilgileri.FirstOrDefault(p => p.SiteBilgileriID == 1);
                    Bul.Adres = Al.Adres.Trim();
                    Bul.Facebook = Al.Facebook.Trim();
                    Bul.Instagram = Al.Instagram.Trim();
                    Bul.Logo = Al.Logo;
                    Bul.MailAdresi = Al.MailAdresi.Trim();
                    Bul.MobilTelefon = Al.MobilTelefon.Trim();
                    Bul.SiteAdi = Al.SiteAdi.Trim();
                    Bul.Telefon = Al.Telefon.Trim();
                    Bul.Twitter = Al.Twitter.Trim();
                    Bul.Whatsapp = Al.Whatsapp.Trim();
                    Bul.Hakkinda = Al.Hakkinda.Trim();
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static SiteBilgileri Goster() //Goster
        {
            using (DBCON db = new DBCON())
            {
                var Bul = db.SiteBilgileri.FirstOrDefault(p => p.SiteBilgileriID == 1);
                return Bul;
            }
        }
    }
}

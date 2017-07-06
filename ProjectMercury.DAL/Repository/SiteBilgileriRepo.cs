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
                    Bul.Adres = Al.Adres;
                    Bul.Facebook = Al.Facebook;
                    Bul.Instagram = Al.Instagram;
                    Bul.Logo = Al.Logo;
                    Bul.MailAdresi = Al.MailAdresi;
                    Bul.MobilTelefon = Al.MobilTelefon;
                    Bul.SiteAdi = Al.SiteAdi;
                    Bul.Telefon = Al.Telefon;
                    Bul.Twitter = Al.Twitter;
                    Bul.Whatsapp = Al.Whatsapp;
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

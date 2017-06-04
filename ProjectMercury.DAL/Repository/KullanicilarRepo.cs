using ProjectMercury.Entity.DBContext;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.Repository
{
    public class KullanicilarRepo
    {
        public static bool KullaniciKaydet(Kullanicilar Al) //Kullanıcı Kaydet
        {
            using (DBCON db = new DBCON())
            {
                bool Control = db.Kullanicilar.Any(p => p.KullaniciAdi == Al.KullaniciAdi && p.KullaniciSifre == Al.KullaniciSifre);
                if (Control != true)
                {
                    db.Kullanicilar.Add(new Kullanicilar()
                    {
                        KullaniciAdi = Al.KullaniciAdi,
                        KullaniciSifre = Al.KullaniciSifre,
                        Master = Al.Master
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool KullaniciGuncelle(Kullanicilar Al) //Kullanıcı Güncelle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Kullanicilar.FirstOrDefault(p => p.KullanicilarID == Al.KullanicilarID);
                    Bul.KullaniciAdi = Al.KullaniciAdi;
                    Bul.KullaniciSifre = Al.KullaniciSifre;
                    Bul.Master = Al.Master;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static void KullaniciSil(string ID) //Kullanıcı Sil
        {
            using (DBCON db = new DBCON())
            {
                int id = int.Parse(ID);
                var Bul = db.Kullanicilar.FirstOrDefault(p => p.KullanicilarID == id && p.System != true);
                db.Kullanicilar.Remove(Bul);
                db.SaveChanges();
            }
        }
        
        public static bool KullaniciGiris(Kullanicilar Al) //Kullanıcı Sırala
        {
            using (DBCON db = new DBCON())
            {
                return db.Kullanicilar.Any(p => p.KullaniciAdi == Al.KullaniciAdi && p.KullaniciSifre== p.KullaniciSifre);
            }
        }
    }
}

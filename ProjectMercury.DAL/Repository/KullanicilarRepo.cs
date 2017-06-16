using ProjectMercury.DAL.VMModels;
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
        public static bool KullaniciKaydet(VMKullanicilar Al) //Kullanıcı Kaydet
        {
            using (DBCON db = new DBCON())
            {
                try
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
                catch
                {
                    return false;
                }
            }
        }
        public static bool KullaniciGuncelle(VMKullanicilar Al) //Kullanıcı Güncelle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Kullanicilar.FirstOrDefault(p => p.KullanicilarID == Al.KullanicilarID);
                    Bul.KullaniciAdi = Al.KullaniciAdi;
                    Bul.KullaniciSifre = Al.KullaniciSifre;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool KullaniciSil(int ID) //Kullanıcı Sil
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Kullanicilar.FirstOrDefault(p => p.KullanicilarID == ID && p.System != true);
                    db.Kullanicilar.Remove(Bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool AdminYap(int ID) //Admin Yap
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Kullanicilar.FirstOrDefault(p => p.KullanicilarID == ID && p.System != true);
                    Bul.Master = true;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static List<VMKullanicilar> Kullanicilar() //Kullanıcı Listele
        {
            using (DBCON db = new DBCON())
            {
                return db.Kullanicilar.Where(p=> p.System==false).Select(p => new VMKullanicilar
                {
                    KullaniciAdi = p.KullaniciAdi,
                    KullanicilarID = p.KullanicilarID,
                    KullaniciSifre = p.KullaniciSifre,
                    Master = p.Master
                }).ToList();
            }
        }

        public static bool KullaniciGiris(Kullanicilar Al) //Kullanıcı Giriş
        {
            using (DBCON db = new DBCON())
            {
                bool Bul = db.Kullanicilar.Any(p => p.KullaniciAdi == Al.KullaniciAdi);
                if (Bul == true)
                {
                    bool BulSifre = db.Kullanicilar.Any(P => P.KullaniciSifre == Al.KullaniciSifre);
                    if (BulSifre == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}


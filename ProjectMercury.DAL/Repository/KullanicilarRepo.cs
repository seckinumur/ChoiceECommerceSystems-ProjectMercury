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
        public static bool KullaniciKaydetTekMod(string Ad,string Sifre) //Kullanıcı Kaydet
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    bool Control = db.Kullanicilar.Any(p => p.KullaniciAdi == Ad && p.KullaniciSifre == Sifre);
                    if (Control != true)
                    {
                        db.Kullanicilar.Add(new Kullanicilar()
                        {
                            KullaniciAdi = Ad,
                            KullaniciSifre = Sifre
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
        public static bool KullaniciGuncelleTekMod(int ID,string Ad,string Sifre) //Kullanıcı Güncelle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Kullanicilar.FirstOrDefault(p => p.KullanicilarID ==ID);
                    Bul.KullaniciAdi = Ad;
                    Bul.KullaniciSifre = Sifre;
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

        public static List<Kullanicilar> KullanicilariListele() //Kullanıcı Listele normal
        {
            using (DBCON db = new DBCON())
            {
                return db.Kullanicilar.Where(p => p.System == false).ToList();
            }
        }

        public static int KullaniciGiris(Kullanicilar Al) //Kullanıcı Giriş
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var bul = db.Kullanicilar.FirstOrDefault(p => p.KullaniciAdi == Al.KullaniciAdi && p.KullaniciSifre == Al.KullaniciSifre);
                    return bul.KullanicilarID;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}


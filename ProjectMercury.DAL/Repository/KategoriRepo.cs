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
    public class KategoriRepo
    {
        public static bool KategoriKaydet(VMKategori Al) //Kategori Kaydet
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    bool Control = db.Kategori.Any(p => p.KategoriAdi == Al.KategoriAdi);
                    if (Control == true)
                    {
                        return false;
                    }
                    else
                    {
                        Kategori Ekle = new Kategori
                        {
                            KategoriAdi = Al.KategoriAdi
                        };
                        db.Kategori.Add(Ekle);
                        db.SaveChanges();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool KategoriGuncelle(VMKategori Al) //Kategori Guncelle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Kategori.FirstOrDefault(p => p.KategoriID == Al.KategoriID);
                    Bul.KategoriAdi = Al.KategoriAdi;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool KategoriSil(int ID) //Kategori Sil
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Kategori.FirstOrDefault(p => p.KategoriID == ID);
                    db.Kategori.Remove(Bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool KategoriSilForce(int ID) //Kategori Sil
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Kategori.FirstOrDefault(p => p.KategoriID == ID);
                    bool kontrol = db.Urun.Any(p => p.KategoriID == ID),kontrol2 = db.AltKategori.Any(p=> p.KategoriID==ID);
                    if (kontrol == true)
                    {
                        var urunsil = db.Urun.Where(p => p.KategoriID == ID).ToList();
                        db.Urun.RemoveRange(urunsil);
                    }
                    if (kontrol2 == true)
                    {
                        var bulalt = db.AltKategori.Where(p => p.KategoriID == ID).ToList();
                        db.AltKategori.RemoveRange(bulalt);
                    }
                    db.Kategori.Remove(Bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static List<VMAltKategori> KategoriListele(int ID) //Kategorin Alt Kategorilerini Listele
        {
            using (DBCON db = new DBCON())
            {
                return db.AltKategori.Where(p => p.KategoriID == ID).Select(p=> new VMAltKategori {
                    AltKategoriAdi=p.AltKategoriAdi,
                    AltKategoriID=p.AltKategoriID
                }).ToList();
            }
        }
        public static string KategoriIsmiBul(int ID) //Kategori Bul
        {
            using (DBCON db = new DBCON())
            {
                return db.Kategori.FirstOrDefault(p => p.KategoriID == ID).KategoriAdi;
            }
        }
        public static List<VMKategori> Kategoriler() //Kategorileri Listele
        {
            using (DBCON db = new DBCON())
            {
                var Kontrol = db.Kategori.Select(p => new VMKategori
                {
                    KategoriAdi = p.KategoriAdi,
                    KategoriID = p.KategoriID,
                    UrunVarmi = false
                }).ToList();
                foreach (var item in Kontrol)
                {
                    bool Check = db.Urun.Any(p => p.KategoriID == item.KategoriID);
                    Check = db.AltKategori.Any(p => p.KategoriID == item.KategoriID);
                    item.UrunVarmi = Check;
                }
                return Kontrol;
            }
        }
        public static List<VMKategori> KategorilerIsim() //Kategorileri Listele
        {
            using (DBCON db = new DBCON())
            {
                var Kontrol = db.Kategori.Select(p => new VMKategori
                {
                    KategoriAdi = p.KategoriAdi
                }).ToList();
                return Kontrol;
            }
        }
    }
}

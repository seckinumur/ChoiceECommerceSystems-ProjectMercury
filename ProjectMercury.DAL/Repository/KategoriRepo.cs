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
        public static Kategori KategoriBul(string ID) //Kategori Bul
        {
            int id = int.Parse(ID);
            using (DBCON db = new DBCON())
            {
                return db.Kategori.FirstOrDefault(p => p.KategoriID == id);
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
                    item.UrunVarmi = Check;
                }
                return Kontrol;
            }
        }
    }
}

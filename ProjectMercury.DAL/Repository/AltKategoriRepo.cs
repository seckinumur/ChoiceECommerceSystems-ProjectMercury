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
    public class AltKategoriRepo
    {
        public static bool AltKategoriKaydet(VMAltKategori Al) //AltKategori Kaydet
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    bool Control = db.AltKategori.Any(p => p.AltKategoriAdi == Al.AltKategoriAdi);
                    if (Control == true)
                    {
                        return false;
                    }
                    else
                    {
                        AltKategori Ekle = new AltKategori
                        {
                            AltKategoriAdi = Al.AltKategoriAdi,
                        };
                        db.AltKategori.Add(Ekle);
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
        public static bool AltKategoriGuncelle(VMAltKategori Al) //AltKategori Guncelle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.AltKategori.FirstOrDefault(p => p.AltKategoriID == Al.AltKategoriID);
                    Bul.AltKategoriAdi = Al.AltKategoriAdi;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool AltKategoriSil(int ID) //AltKategori Sil
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.AltKategori.FirstOrDefault(p => p.AltKategoriID == ID);
                    db.AltKategori.Remove(Bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static AltKategori AltKategoriBul(string ID) //AltKategori Bul
        {
            int id = int.Parse(ID);
            using (DBCON db = new DBCON())
            {
                return db.AltKategori.FirstOrDefault(p => p.AltKategoriID == id);
            }
        }
        public static List<VMAltKategori> AltKategoriler() //AltKategorileri Bul
        {
            using (DBCON db = new DBCON())
            {
                var result = db.AltKategori.Select(p => new VMAltKategori
                {
                    AltKategoriAdi = p.AltKategoriAdi,
                    AltKategoriID = p.AltKategoriID
                }).ToList();
                foreach (var item in result)
                {
                    bool kontrol = db.Urun.Any(p => p.AltKategoriID == item.AltKategoriID);
                    item.UrunVarmi = kontrol;
                }
                return result;
            }
        }
    }
}

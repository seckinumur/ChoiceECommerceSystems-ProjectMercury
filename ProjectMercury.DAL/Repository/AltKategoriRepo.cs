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
                        var bulKat = db.Kategori.FirstOrDefault(p => p.KategoriAdi == Al.KategoriIsmi);
                        AltKategori Ekle = new AltKategori
                        {
                            AltKategoriAdi = Al.AltKategoriAdi.Trim(),
                            KategoriID=bulKat.KategoriID
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
                    var bulKat = db.Kategori.FirstOrDefault(p => p.KategoriAdi == Al.KategoriIsmi);
                    var Bul = db.AltKategori.FirstOrDefault(p => p.AltKategoriID == Al.AltKategoriID);
                    Bul.AltKategoriAdi = Al.AltKategoriAdi.Trim();
                    Bul.KategoriID = bulKat.KategoriID;
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
        public static bool AltKategoriSilForce(int ID) //AltKategori Sil
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bulalt = db.AltKategori.FirstOrDefault(p => p.AltKategoriID == ID);
                    bool kontrol = db.Urun.Any(p => p.AltKategoriID == ID);
                    if (kontrol == true)
                    {
                        var urunsil = db.Urun.Where(p => p.AltKategoriID == ID).ToList();
                        db.Urun.RemoveRange(urunsil);
                    }
                    db.AltKategori.Remove(Bulalt);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static string AltKategoriBul(int ID) //AltKategori Bul
        {
            using (DBCON db = new DBCON())
            {
                return db.AltKategori.FirstOrDefault(p => p.AltKategoriID == ID).AltKategoriAdi;
            }
        }
        public static string AltKategoriKategoriBul(int ID) //AltKategori kategori Bul
        {
            using (DBCON db = new DBCON())
            {
                int Bul =  db.AltKategori.FirstOrDefault(p => p.AltKategoriID == ID).KategoriID;
                return db.Kategori.FirstOrDefault(p => p.KategoriID == Bul).KategoriAdi;
            }
        }
        public static List<VMAltKategori> AltKategoriler() //AltKategorileri Bul
        {
            using (DBCON db = new DBCON())
            {
                var result = db.AltKategori.Select(p => new VMAltKategori
                {
                    AltKategoriAdi = p.AltKategoriAdi,
                    AltKategoriID = p.AltKategoriID,
                    KategoriIsmi= p.KategoriID.ToString()
                }).ToList();
                
                foreach (var item in result)
                {
                    bool kontrol = db.Urun.Any(p => p.AltKategoriID == item.AltKategoriID);
                    var bulKat = db.Kategori.FirstOrDefault(p => p.KategoriID.ToString() == item.KategoriIsmi);
                    item.UrunVarmi = kontrol;
                    item.KategoriIsmi = bulKat.KategoriAdi;
                }
                return result;
            }
        }
        public static List<AltKategori> AltKategorileriListele() //AltKategorileri Bul
        {
            using (DBCON db = new DBCON())
            {
                return db.AltKategori.ToList();
            }
        }
    }
}

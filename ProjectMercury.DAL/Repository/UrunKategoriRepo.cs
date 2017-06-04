using ProjectMercury.Entity.DBContext;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.Repository
{
    public class UrunKategoriRepo
    {
            public static bool UrunKategoriKaydet(UrunKategori Al) //AltKategori Kaydet
            {
                using (DBCON db = new DBCON())
                {
                    bool Control = db.UrunKategori.Any(p => p.UrunKategoriAdi == Al.UrunKategoriAdi);
                    if (Control == true)
                    {
                        return false;
                    }
                    else
                    {
                        db.UrunKategori.Add(Al);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            public static bool UrunKategoriGuncelle(UrunKategori Al) //AltKategori Guncelle
            {
                using (DBCON db = new DBCON())
                {
                    try
                    {
                        var Bul = db.UrunKategori.FirstOrDefault(p => p.UrunKategoriID == Al.UrunKategoriID);
                        Bul.UrunKategoriAdi = Al.UrunKategoriAdi;
                        db.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            public static void UrunKategoriSil(string ID) //AltKategori Sil
            {
                int id = int.Parse(ID);
                using (DBCON db = new DBCON())
                {
                    var Bul = db.UrunKategori.FirstOrDefault(p => p.UrunKategoriID == id);
                    db.UrunKategori.Remove(Bul);
                    db.SaveChanges();
                }
            }
            public static UrunKategori UrunKategoriBul(string ID) //AltKategori Bul
            {
                int id = int.Parse(ID);
                using (DBCON db = new DBCON())
                {
                    return db.UrunKategori.FirstOrDefault(p => p.UrunKategoriID == id);
                }
            }
            public static List<UrunKategori> UrunKategoriBul() //AltKategorileri Bul
            {
                using (DBCON db = new DBCON())
                {
                    return db.UrunKategori.ToList();
                }
            }
        }
    }


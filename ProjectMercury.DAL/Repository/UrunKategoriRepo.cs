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
    public class UrunKategoriRepo
    {
        public static bool UrunKategoriKaydet(VMUrunKategori Al) // Ürün KAtegori Kaydet
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    bool Control = db.UrunKategori.Any(p => p.UrunKategoriAdi == Al.UrunKategoriAdi);
                    if (Control == true)
                    {
                        return false;
                    }
                    else
                    {
                        UrunKategori Ekle = new UrunKategori
                        {
                            UrunKategoriAdi = Al.UrunKategoriAdi
                        };
                        db.UrunKategori.Add(Ekle);
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
        public static bool UrunKategoriGuncelle(VMUrunKategori Al) //Ürün Kategori Güncelleme
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
        public static bool UrunKategoriSil(int ID) //Ürün Kategori Silme
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.UrunKategori.FirstOrDefault(p => p.UrunKategoriID == ID);
                    db.UrunKategori.Remove(Bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool UrunKategoriSilForce(int ID) //Ürün Kategori Silme
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.UrunKategori.FirstOrDefault(p => p.UrunKategoriID == ID);
                    bool kontrol = db.Urun.Any(p => p.UrunKategoriID == ID);
                    if(kontrol == true)
                    {
                        var urunsil = db.Urun.Where(p => p.UrunKategoriID == ID).ToList();
                        db.Urun.RemoveRange(urunsil);
                    }
                    db.UrunKategori.Remove(Bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static UrunKategori UrunKategoriBul(string ID) 
        {
            int id = int.Parse(ID);
            using (DBCON db = new DBCON())
            {
                return db.UrunKategori.FirstOrDefault(p => p.UrunKategoriID == id);
            }
        }
        public static List<VMUrunKategori> UrunKategorileri() //Ürün Kategorilerin Hepsi
        {
            using (DBCON db = new DBCON())
            {
                var result = db.UrunKategori.Where(p=> p.UrunKategoriAdi != "Ürün Kategori Yok").Select(p => new VMUrunKategori
                {
                    UrunKategoriAdi = p.UrunKategoriAdi,
                    UrunKategoriID = p.UrunKategoriID
                }).ToList();
                foreach (var item in result)
                {
                    bool kontrol = db.Urun.Any(p => p.UrunKategoriID == item.UrunKategoriID);
                    item.UrunVarmi = kontrol;
                }
                return result;
            }
        }
    }
}


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
        public static bool KategoriKaydet(Kategori Al) //Kategori Kaydet
        {
            using (DBCON db = new DBCON())
            {
                bool Control = db.Kategori.Any(p => p.KategoriAdi == Al.KategoriAdi);
                if (Control == true)
                {
                    return false;
                }
                else
                {
                    db.Kategori.Add(Al);
                    db.SaveChanges();
                    return true;
                }
            }
        }
        public static bool KategoriGuncelle(Kategori Al) //Kategori Guncelle
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
        public static void KategoriSil(string ID) //Kategori Sil
        {
            int id = int.Parse(ID);
            using (DBCON db = new DBCON())
            {
                var Bul = db.Kategori.FirstOrDefault(p => p.KategoriID == id);
                db.Kategori.Remove(Bul);
                db.SaveChanges();
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
        public static List<Kategori> Kategoriler() //Kategorileri Listele
        {
            using (DBCON db = new DBCON())
            {
                return db.Kategori.ToList();
            }
        }
    }
}

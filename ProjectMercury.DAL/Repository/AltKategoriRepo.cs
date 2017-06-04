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
        public static bool AltKategoriKaydet(AltKategori Al) //AltKategori Kaydet
        {
            using (DBCON db = new DBCON())
            {
                bool Control = db.AltKategori.Any(p => p.AltKategoriAdi == Al.AltKategoriAdi);
                if (Control == true)
                {
                    return false;
                }
                else
                {
                    db.AltKategori.Add(Al);
                    db.SaveChanges();
                    return true;
                }
            }
        }
        public static bool AltKategoriGuncelle(AltKategori Al) //AltKategori Guncelle
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
        public static void AltKategoriSil(string ID) //AltKategori Sil
        {
            int id = int.Parse(ID);
            using (DBCON db = new DBCON())
            {
                var Bul = db.AltKategori.FirstOrDefault(p => p.AltKategoriID == id);
                db.AltKategori.Remove(Bul);
                db.SaveChanges();
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
        public static List<AltKategori> AltKategorileriBul() //AltKategorileri Bul
        {
            using (DBCON db = new DBCON())
            {
                return db.AltKategori.ToList();
            }
        }
    }
}

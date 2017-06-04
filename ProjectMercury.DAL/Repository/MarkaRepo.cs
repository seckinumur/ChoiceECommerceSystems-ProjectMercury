using ProjectMercury.Entity.DBContext;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.Repository
{
   public class MarkaRepo
    {
        public static bool MarkaKaydet(Marka Al) //Marka Kaydet
        {
            using (DBCON db = new DBCON())
            {
                bool Control = db.Marka.Any(p => p.MarkaAdi == Al.MarkaAdi);
                if (Control == true)
                {
                    return false;
                }
                else
                {
                    db.Marka.Add(Al);
                    db.SaveChanges();
                    return true;
                }
            }
        }
        public static bool MarkaGuncelle(Marka Al) //Marka Guncelle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Marka.FirstOrDefault(p => p.MarkaID == Al.MarkaID);
                    Bul.MarkaAdi = Al.MarkaAdi;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static void MarkaSil(string ID) //Marka Sil
        {
            int id = int.Parse(ID);
            using (DBCON db = new DBCON())
            {
                var Bul = db.Marka.FirstOrDefault(p => p.MarkaID == id);
                db.Marka.Remove(Bul);
                db.SaveChanges();
            }
        }
        public static Marka MarkaBul(string ID) //Marka Bul
        {
            int id = int.Parse(ID);
            using (DBCON db = new DBCON())
            {
                return db.Marka.FirstOrDefault(p => p.MarkaID == id);
            }
        }
        public static List<Marka> MarkaBul() //Marka Bul
        {
            using (DBCON db = new DBCON())
            {
                return db.Marka.ToList();
            }
        }
    }
}

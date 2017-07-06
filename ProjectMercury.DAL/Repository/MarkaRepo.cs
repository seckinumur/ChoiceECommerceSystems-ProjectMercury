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
    public class MarkaRepo
    {
        public static bool MarkaKaydet(VMMArka Al) //Marka Kaydet
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    bool Control = db.Marka.Any(p => p.MarkaAdi == Al.MarkaAdi);
                    if (Control == true)
                    {
                        return false;
                    }
                    else
                    {
                        Marka Ekle = new Marka
                        {
                            MarkaAdi = Al.MarkaAdi
                        };
                        db.Marka.Add(Ekle);
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
        public static bool MarkaGuncelle(VMMArka Al) //Marka Guncelle
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
        public static bool MarkaSil(int ID) //Marka Sil
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Marka.FirstOrDefault(p => p.MarkaID == ID);
                    db.Marka.Remove(Bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool MarkaSilForce(int ID) //Marka Sil
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Marka.FirstOrDefault(p => p.MarkaID == ID);
                    bool kontrol = db.Urun.Any(p => p.MarkaID == ID);
                    if (kontrol == true)
                    {
                        var urunsil = db.Urun.Where(p => p.MarkaID == ID).ToList();
                        db.Urun.RemoveRange(urunsil);
                    }
                    db.Marka.Remove(Bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
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
        public static List<VMMArka> Markalar() //Marka Listele
        {
            using (DBCON db = new DBCON())
            {
                var result = db.Marka.Select(p => new VMMArka
                {
                    MarkaAdi = p.MarkaAdi,
                    MarkaID = p.MarkaID
                }).ToList();
                foreach (var item in result)
                {
                    bool kontrol = db.Urun.Any(p => p.MarkaID == item.MarkaID);
                    item.UrunVarmi = kontrol;
                }
                return result;
            }
        }
    }
}

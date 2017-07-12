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
    public class ViewRepo
    {
        public static UrunAI VievIndexAI() // VievIndexAI Yapay Zeka Algoritması
        {
            using (DBCON db = new DBCON())
            {
                UrunAI Liste = new UrunAI();
                try
                {
                    List<Urun> GunufirsatiListe = new List<Urun>();
                    Random rnd = new Random();
                    var urunlistesi = db.Urun.ToList();
                    var indirimliUrun = db.Urun.Where(p => p.IndirimVarmi == true).ToList();
                    int encoksatan = db.Satis.Count();

                    if (urunlistesi.Count != 5)
                    {
                        Liste.EnYeni = urunlistesi.OrderByDescending(p => p.UrunID).Take(urunlistesi.Count).ToList();
                    }
                    else
                    {
                        Liste.EnYeni = urunlistesi.OrderByDescending(p => p.UrunID).Take(5).ToList();
                    }
                    if (encoksatan != 5 && encoksatan != 0)
                    {
                        Liste.EnCokSatan = db.Satis.OrderBy(p => p.SatisAdedi).Select(P => P.Urun).ToList();
                    }
                    else
                    {
                        Liste.EnCokSatan = db.Satis.OrderBy(p => p.SatisAdedi).Select(P => P.Urun).Take(5).ToList();
                    }
                    if (indirimliUrun.Count != 5)
                    {
                        for (int i = 0; i < urunlistesi.Count; i++) { GunufirsatiListe.Add(indirimliUrun[rnd.Next(1, indirimliUrun.Count)]); }
                        Liste.GununFirsati = GunufirsatiListe;
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++) { GunufirsatiListe.Add(indirimliUrun[rnd.Next(1, indirimliUrun.Count)]); }
                        Liste.GununFirsati = GunufirsatiListe;
                    }
                    return Liste;
                }
                catch
                {
                    Liste.EnCokSatan = null;
                    Liste.EnYeni = null;
                    Liste.GununFirsati = null;
                    return Liste;
                }
                
            }
        }
        public static VMViewKategori KategoriyeGore(int ID) 
        {
            using (DBCON db = new DBCON())
            {
                VMViewKategori liste = new VMViewKategori();
                liste.AltKategoriler = db.AltKategori.Where(p => p.KategoriID == ID).ToList();
                liste.ÜrünKategorileri = db.Urun.Where(p => p.KategoriID == ID).Select(p => p.UrunKategori).ToList();
                liste.Urunler = db.Urun.Where(p => p.KategoriID == ID).ToList();
                liste.KategoriAdi = db.Kategori.FirstOrDefault(p => p.KategoriID == ID).KategoriAdi;
                return liste;
            }
        }
    }
}

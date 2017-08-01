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
                    int encoksatan = db.EnCokSatan.Count();

                    if (urunlistesi.Count < 5)
                    {
                        Liste.EnYeni = urunlistesi.OrderByDescending(p => p.UrunID).Take(urunlistesi.Count).ToList();
                    }
                    else
                    {
                        Liste.EnYeni = urunlistesi.OrderByDescending(p => p.UrunID).Take(5).ToList();
                    }
                    if (encoksatan < 5 && encoksatan != 0)
                    {
                        Liste.EnCokSatan = db.EnCokSatan.OrderBy(p => p.Adet).Select(P => P.Urun).ToList();
                    }
                    else
                    {
                        Liste.EnCokSatan = db.EnCokSatan.OrderBy(p => p.Adet).Select(P => P.Urun).Take(5).ToList();
                    }
                    if (indirimliUrun.Count < 5)
                    {
                        for (int i = 0; i < urunlistesi.Count; i++) { GunufirsatiListe.Add(indirimliUrun[rnd.Next(1, indirimliUrun.Count)]); }
                        Liste.GununFirsati = GunufirsatiListe;
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++) { GunufirsatiListe.Add(indirimliUrun[rnd.Next(1, indirimliUrun.Count)]); }
                        Liste.GununFirsati = GunufirsatiListe;
                    }
                    Liste.slider1 = db.Slider.FirstOrDefault(p => p.SliderID == 1).Image;
                    Liste.slider2 = db.Slider.FirstOrDefault(p => p.SliderID == 2).Image;
                    Liste.slider3 = db.Slider.FirstOrDefault(p => p.SliderID == 3).Image;
                    Liste.slider4 = db.Slider.FirstOrDefault(p => p.SliderID == 4).Image;
                    return Liste;
                }
                catch
                {
                    Liste.EnCokSatan = null;
                    Liste.EnYeni = null;
                    Liste.GununFirsati = null;
                    Liste.slider1 = db.Slider.FirstOrDefault(p => p.SliderID == 1).Image;
                    Liste.slider2 = db.Slider.FirstOrDefault(p => p.SliderID == 2).Image;
                    Liste.slider3 = db.Slider.FirstOrDefault(p => p.SliderID == 3).Image;
                    Liste.slider4 = db.Slider.FirstOrDefault(p => p.SliderID == 4).Image;
                    return Liste;
                }
                
            }
        }
        public static VMViewKategori KategoriyeGore(int ID) //Kategori Sıaralama
        {
            using (DBCON db = new DBCON())
            {
                VMViewKategori liste = new VMViewKategori();
                List<UrunKategori> Urunkategorilistesi = new List<UrunKategori>();
                List<Marka> MarkalarListesi = new List<Marka>();
                var kategori = db.Kategori.FirstOrDefault(p => p.KategoriID == ID);
                var Urunler = db.Urun.Where(p => p.MarkaID == ID).OrderBy(p => p.IndirimliFiyati == 0 ? p.UrunFiyati : p.IndirimliFiyati).Select(b => new VMUrun
                {
                    Image = b.Image,
                    IndirimliFiyati = b.IndirimliFiyati == 0 ? b.UrunFiyati : b.IndirimliFiyati,
                    UrunFiyati = b.UrunFiyati,
                    UrunAciklama = b.UrunAciklama,
                    UrunID = b.UrunID,
                    UrunAdi = b.UrunAdi,
                    AltKategoriID = b.AltKategoriID,
                    AltKategori = b.AltKategori.AltKategoriAdi,
                    UrunKategori = b.UrunKategori.UrunKategoriAdi,
                    UrunKategoriID = b.UrunKategoriID,
                    KategoriID = b.KategoriID,
                    MarkaID = b.MarkaID,
                    Kategori = b.Kategori.KategoriAdi,
                    Marka = b.Marka.MarkaAdi
                }).ToList();
                liste.AltKategoriler = db.AltKategori.Where(p => p.KategoriID == ID).ToList();
                liste.Urunler = Urunler;
                var urunkategori = db.Urun.Where(p => p.KategoriID == ID).Select(p => p.UrunKategori).OrderBy(P=> P.UrunKategoriID).ToList();
                var marka = db.Urun.Where(p => p.KategoriID == ID).Select(p => p.Marka).OrderBy(p=> p.MarkaID).ToList();
                
                int data = 0;
                foreach (var urk in urunkategori)
                {
                   
                    if(urk.UrunKategoriID != data)
                    {
                        Urunkategorilistesi.Add(urk);
                        data = urk.UrunKategoriID;
                    }
                }
                data = 0;
                foreach (var ma in marka)
                {
                    if(ma.MarkaID != data)
                    {
                        MarkalarListesi.Add(ma);
                        data = ma.MarkaID;
                    }
                }
                liste.KategoriAdi = kategori.KategoriAdi;
                liste.Markalar = MarkalarListesi;
                liste.ÜrünKategorileri = Urunkategorilistesi;
                return liste;
            }
        }
        public static VMViewKategori AltKategoriyeGore(int ID)
        {
            using (DBCON db = new DBCON())
            {
                VMViewKategori liste = new VMViewKategori();
                List<UrunKategori> Urunkategorilistesi = new List<UrunKategori>();
                List<Marka> MarkalarListesi = new List<Marka>();
                var Urunler = db.Urun.Where(p => p.MarkaID == ID).OrderBy(p => p.IndirimliFiyati == 0 ? p.UrunFiyati : p.IndirimliFiyati).Select(b => new VMUrun
                {
                    Image = b.Image,
                    IndirimliFiyati = b.IndirimliFiyati == 0 ? b.UrunFiyati : b.IndirimliFiyati,
                    UrunFiyati = b.UrunFiyati,
                    UrunAciklama = b.UrunAciklama,
                    UrunID = b.UrunID,
                    UrunAdi = b.UrunAdi,
                    AltKategoriID = b.AltKategoriID,
                    AltKategori = b.AltKategori.AltKategoriAdi,
                    UrunKategori = b.UrunKategori.UrunKategoriAdi,
                    UrunKategoriID = b.UrunKategoriID,
                    KategoriID = b.KategoriID,
                    MarkaID = b.MarkaID,
                    Kategori = b.Kategori.KategoriAdi,
                    Marka = b.Marka.MarkaAdi
                }).ToList();
                liste.AltKategoriler = db.AltKategori.Where(p => p.AltKategoriID == ID).ToList();
                liste.Urunler = Urunler;
                var urunkategori = db.UrunKategori.Where(p => p.AltKategoriID == ID).OrderBy(p=> p.AltKategoriID).ToList();
                var marka = db.Urun.Where(p => p.AltKategoriID == ID).Select(p => p.Marka).OrderBy(P=> P.MarkaID).ToList();

                int data = 0;
                foreach (var urk in urunkategori)
                {

                    if (urk.UrunKategoriID != data)
                    {
                        Urunkategorilistesi.Add(urk);
                        data = urk.UrunKategoriID;
                    }
                }
                data = 0;
                foreach (var ma in marka)
                {
                    if (ma.MarkaID != data)
                    {
                        MarkalarListesi.Add(ma);
                        data = ma.MarkaID;
                    }
                }
                liste.KategoriAdi = Urunler.FirstOrDefault(p => p.AltKategoriID == ID).Kategori;
                liste.Markalar = MarkalarListesi;
                liste.AltKategoriAdi = db.AltKategori.FirstOrDefault(p => p.AltKategoriID == ID).AltKategoriAdi;
                liste.ÜrünKategorileri = Urunkategorilistesi;
                liste.Kategoriid=  db.AltKategori.FirstOrDefault(p => p.AltKategoriID == ID).KategoriID;
                return liste;
            }
        }
        public static VMViewKategori UrunKategoriyeGore(int ID)
        {
            using (DBCON db = new DBCON())
            {
                VMViewKategori liste = new VMViewKategori();
                List<UrunKategori> Urunkategorilistesi = new List<UrunKategori>();
                List<Marka> MarkalarListesi = new List<Marka>();
                List<AltKategori> altkategorilistesi = new List<AltKategori>();
                
                var altkategorisi = db.UrunKategori.FirstOrDefault(p => p.UrunKategoriID == ID);
                var Urunler = db.Urun.Where(p => p.MarkaID == ID).OrderBy(p => p.IndirimliFiyati == 0 ? p.UrunFiyati : p.IndirimliFiyati).Select(b => new VMUrun
                {
                    Image = b.Image,
                    IndirimliFiyati = b.IndirimliFiyati == 0 ? b.UrunFiyati : b.IndirimliFiyati,
                    UrunFiyati = b.UrunFiyati,
                    UrunAciklama = b.UrunAciklama,
                    UrunID = b.UrunID,
                    UrunAdi = b.UrunAdi,
                    AltKategoriID = b.AltKategoriID,
                    AltKategori = b.AltKategori.AltKategoriAdi,
                    UrunKategori = b.UrunKategori.UrunKategoriAdi,
                    UrunKategoriID = b.UrunKategoriID,
                    KategoriID = b.KategoriID,
                    MarkaID = b.MarkaID,
                    Kategori = b.Kategori.KategoriAdi,
                    Marka = b.Marka.MarkaAdi
                }).ToList();
                var altKategoriler = db.AltKategori.Where(p => p.AltKategoriID == altkategorisi.AltKategoriID).OrderBy(p=> p.AltKategoriID).ToList();
                liste.Urunler = Urunler;
                var urunkategori = db.Urun.Where(p => p.UrunKategoriID == ID).Select(p=> p.UrunKategori).OrderBy(p=> p.UrunKategoriID).ToList();
                var marka = db.Urun.Where(p => p.UrunKategoriID == ID).Select(p => p.Marka).OrderBy(P=> P.MarkaID).ToList();

                int data = 0;
                foreach (var urk in urunkategori)
                {

                    if (urk.UrunKategoriID != data)
                    {
                        Urunkategorilistesi.Add(urk);
                        data = urk.UrunKategoriID;
                    }
                }
                data = 0;
                foreach (var urk in altKategoriler)
                {

                    if (urk.AltKategoriID != data)
                    {
                        altkategorilistesi.Add(urk);
                        data = urk.AltKategoriID;
                    }
                }
                data = 0;
                foreach (var ma in marka)
                {
                    if (ma.MarkaID != data)
                    {
                        MarkalarListesi.Add(ma);
                        data = ma.MarkaID;
                    }
                }

                liste.AltKategoriler = altkategorilistesi;
                liste.KategoriAdi = Urunler.FirstOrDefault(p => p.UrunKategoriID == ID).Kategori;
                liste.Markalar = MarkalarListesi;
                liste.AltKategoriAdi = db.Urun.FirstOrDefault(p => p.UrunKategoriID == ID).AltKategori.AltKategoriAdi;
                liste.ÜrünKategorileri = Urunkategorilistesi;
                liste.Kategoriid = db.Urun.FirstOrDefault(p => p.UrunKategoriID == ID).KategoriID;
                liste.UrunKategoriAdi = db.UrunKategori.FirstOrDefault(p => p.UrunKategoriID == ID).UrunKategoriAdi;
                liste.AltKategoriid= db.Urun.FirstOrDefault(p => p.UrunKategoriID == ID).AltKategoriID;
                return liste;
            }
        }
        public static VMViewKategori Markayagore(int ID)
        {
            using (DBCON db = new DBCON())
            {
                VMViewKategori liste = new VMViewKategori();
                List<UrunKategori> Urunkategorilistesi = new List<UrunKategori>();
                List<AltKategori> Altkategori = new List<AltKategori>();

                var Urunler = db.Urun.Where(p => p.MarkaID == ID).OrderBy(p => p.IndirimliFiyati == 0 ? p.UrunFiyati : p.IndirimliFiyati).Select(b=> new VMUrun {
                    Image= b.Image,
                    IndirimliFiyati = b.IndirimliFiyati==0 ? b.UrunFiyati : b.IndirimliFiyati,
                    UrunFiyati = b.UrunFiyati,
                    UrunAciklama= b.UrunAciklama,
                    UrunID= b.UrunID,
                    UrunAdi= b.UrunAdi,
                    AltKategoriID= b.AltKategoriID,
                    AltKategori = b.AltKategori.AltKategoriAdi,
                    UrunKategori = b.UrunKategori.UrunKategoriAdi,
                    UrunKategoriID = b.UrunKategoriID,
                    KategoriID= b.KategoriID,
                    MarkaID = b.MarkaID,
                    Kategori = b.Kategori.KategoriAdi,
                    Marka = b.Marka.MarkaAdi
                }).ToList();
                var AltKategoriler = db.Urun.Where(p => p.MarkaID == ID).Select(p=> p.AltKategori).OrderBy(p => p.AltKategoriID).ToList();
                liste.Urunler = Urunler;
                var urunkategori = db.Urun.Where(p => p.MarkaID == ID).Select(p => p.UrunKategori).OrderBy(p => p.UrunKategoriID).ToList();

                int data = 0;
                foreach (var urk in urunkategori)
                {

                    if (urk.UrunKategoriID != data)
                    {
                        Urunkategorilistesi.Add(urk);
                        data = urk.UrunKategoriID;
                    }
                }
                data = 0;
                foreach (var urk in AltKategoriler)
                {

                    if (urk.AltKategoriID != data)
                    {
                        Altkategori.Add(urk);
                        data = urk.AltKategoriID;
                    }
                }
                liste.AltKategoriler = Altkategori;
                liste.ÜrünKategorileri = Urunkategorilistesi;
                liste.MarkaAdi = db.Marka.FirstOrDefault(p => p.MarkaID == ID).MarkaAdi;
                return liste;
            }
        }
        public static string UyeSepet(string ID)
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                        int id = int.Parse(ID);
                        int adet = db.SanalSepetUye.Where(p => p.UyelerID == id).Sum(P=> P.Adet);
                        return "Sepette " + adet + " Adet Ürün Bekliyor.";
                }
                catch
                {
                    return "Sepette Bekleyen Ürün Yok";
                }
            }
        }
    }
}

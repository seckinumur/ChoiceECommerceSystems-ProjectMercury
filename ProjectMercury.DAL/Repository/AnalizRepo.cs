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
   public class AnalizRepo
    {
        public static VMAnaliz Analiz() //Toplam
        {
            using (DBCON db = new DBCON())
            {
                int ToplamUrun = db.Urun.Count();
                int Indirim = db.Urun.Where(p => p.IndirimVarmi == true).Count();
                int Indirimsiz = db.Urun.Where(p => p.IndirimVarmi == false).Count();
                int Musteriler = db.Uyeler.Count();
                int Kullanicilar = db.Kullanicilar.Where(p=> p.System==false).ToList().Count();
                int Gonderilenurunler = db.Siparis.Where(p => p.Gonderildimi == true).Count();
                int Gonderilmeyenurunler = db.Siparis.Where(p => p.Gonderildimi == false).Count();
                int OnayBekleyenler = db.Siparis.Where(p => p.Onaylandimi == false).Count();
                int Onaylananlar = db.Siparis.Where(p => p.Onaylandimi == true).Count();

                VMAnaliz Analiz = new VMAnaliz
                {
                    Gönderilen = Gonderilenurunler,
                    Indirimli = Indirim,
                    Indirimsiz = Indirimsiz,
                    Kullanıcılar = Kullanicilar,
                    Uyeler = Musteriler,
                    OnayBekleyen = OnayBekleyenler,
                    Onaylanan = Onaylananlar,
                    ToplamUrun = ToplamUrun,
                    Gonderilmeyen = Gonderilmeyenurunler
                };
                return Analiz;
            }
        }
        public static VMUrunModel UrunKaydetKategori() //Toplam
        {
            using (DBCON db = new DBCON())
            {
                var Marka = db.Marka.ToList();
                var Kategori = db.Kategori.ToList();
                var AltKategori = db.AltKategori.ToList();
                var UrunKategori = db.UrunKategori.ToList();

                VMUrunModel Model = new VMUrunModel
                {
                    altkategoriadi=AltKategori,
                    kategori=Kategori,
                    marka=Marka,
                    urunkategoriadi=UrunKategori
                };
                return Model;
            }
        }
        public static List<VMUrun> ToplamUrun() //Toplam Ürün
        {
            using (DBCON db = new DBCON())
            {
                var Bul = db.Urun.Select(p => new VMUrun
                {
                    AltKategori = p.AltKategori.AltKategoriAdi,
                    AltKategoriID = p.AltKategoriID,
                    Gramaj = p.Gramaj,
                    UrunAciklama = p.UrunAciklama,
                    UrunAdedi = p.UrunAdedi,
                    UrunAdi = p.UrunAdi,
                    Image = p.Image,
                    IndirimliFiyati = p.IndirimliFiyati,
                    IndirimVarmi = p.IndirimVarmi,
                    Kategori = p.Kategori.KategoriAdi,
                    KategoriID = p.KategoriID,
                    Marka = p.Marka.MarkaAdi,
                    MarkaID = p.MarkaID,
                    UrunFiyati = p.UrunFiyati,
                    UrunID = p.UrunID,
                    UrunKategori = p.UrunKategori.UrunKategoriAdi,
                    UrunKategoriID = p.UrunKategoriID,
                    Yorum = p.Yorum
                }).ToList();
                return Bul;
            }
        }
        public static List<VMUrun> IndirimliUrun() //İndirimli Ürün
        {
            using (DBCON db = new DBCON())
            {
                var Bul = db.Urun.Where(n=> n.IndirimVarmi==true).Select(p => new VMUrun
                {
                    AltKategori = p.AltKategori.AltKategoriAdi,
                    AltKategoriID = p.AltKategoriID,
                    Gramaj = p.Gramaj,
                    UrunAciklama = p.UrunAciklama,
                    UrunAdedi = p.UrunAdedi,
                    UrunAdi = p.UrunAdi,
                    Image = p.Image,
                    IndirimliFiyati = p.IndirimliFiyati,
                    IndirimVarmi = p.IndirimVarmi,
                    Kategori = p.Kategori.KategoriAdi,
                    KategoriID = p.KategoriID,
                    Marka = p.Marka.MarkaAdi,
                    MarkaID = p.MarkaID,
                    UrunFiyati = p.UrunFiyati,
                    UrunID = p.UrunID,
                    UrunKategori = p.UrunKategori.UrunKategoriAdi,
                    UrunKategoriID = p.UrunKategoriID,
                    Yorum = p.Yorum
                }).ToList();
                return Bul;
            }
        }
        public static List<VMUrun> IndirimsizUrun() //İndirimsiz Ürün
        {
            using (DBCON db = new DBCON())
            {
                var Bul = db.Urun.Where(n => n.IndirimVarmi == false).Select(p => new VMUrun
                {
                    AltKategori = p.AltKategori.AltKategoriAdi,
                    AltKategoriID = p.AltKategoriID,
                    Gramaj = p.Gramaj,
                    UrunAciklama = p.UrunAciklama,
                    UrunAdedi = p.UrunAdedi,
                    UrunAdi = p.UrunAdi,
                    Image = p.Image,
                    IndirimliFiyati = p.IndirimliFiyati,
                    IndirimVarmi = p.IndirimVarmi,
                    Kategori = p.Kategori.KategoriAdi,
                    KategoriID = p.KategoriID,
                    Marka = p.Marka.MarkaAdi,
                    MarkaID = p.MarkaID,
                    UrunFiyati = p.UrunFiyati,
                    UrunID = p.UrunID,
                    UrunKategori = p.UrunKategori.UrunKategoriAdi,
                    UrunKategoriID = p.UrunKategoriID,
                    Yorum = p.Yorum
                }).ToList();
                return Bul;
            }
        }
        public static List<VMUyeler> UyeleriListele() //Uyeleri Listele
        {
            using (DBCON db = new DBCON())
            {
                return db.Uyeler.Select(p => new VMUyeler
                {
                    Adres = p.Adres,
                    Banlimi = p.Banlimi,
                    KullaniciAdi = p.KullaniciAdi,
                    MailAdresi = p.MailAdresi,
                    UyeAdiSoyadi = p.UyeAdiSoyadi,
                    Sifre = p.Sifre,
                    Tarih = p.Tarih,
                    Telefon = p.Telefon,
                    UyelerID = p.UyelerID
                }).ToList();
            }
        }
        public static List<Kullanicilar> KullaniciListele() //Kullanıcı Listele
        {
            using (DBCON db = new DBCON())
            {
                var Bul = db.Kullanicilar.Where(p => p.System != true).ToList();
                return Bul;
            }
        }
    }
}

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
                string gun = DateTime.Now.Day.ToString(), ay = DateTime.Now.Month.ToString(), yil = DateTime.Now.Year.ToString();

                int ToplamUrun = db.Urun.Count();
                int Indirim = db.Urun.Where(p => p.IndirimVarmi == true).Count();
                int Indirimsiz = db.Urun.Where(p => p.IndirimVarmi == false).Count();
                int Musteriler = db.Uyeler.Count();
                int Kullanicilar = db.Kullanicilar.Where(p => p.System == false).ToList().Count();
                int Gonderilenurunler = db.Siparis.Where(p => p.Gonderildimi == true && p.İptal == false).Count();
                int Gonderilmeyenurunler = db.Siparis.Where(p => p.Gonderildimi == false && p.İptal == false && p.Onaylandimi == true).Count();
                int IptalEdilen = db.Siparis.Where(p => p.İptal == true && p.Gonderildimi == false).Count();
                int OnayBekleyenler = db.Siparis.Where(p => p.Onaylandimi == false && p.Gonderildimi == false && p.İptal == false).Count();
                double ciroay = 0;
                int urunindex = 0;
                bool kontrol = db.AylikCiro.Any(d => d.Yil == yil && d.Ay == ay);
                if (Gonderilenurunler != 0 && kontrol == true)
                {
                    ciroay = db.AylikCiro.Where(P => P.Yil == yil && P.Ay == ay).Sum(P => P.ToplamSatis);
                    urunindex = db.AylikCiro.Where(p => p.Yil == yil && p.Ay == ay).Sum(p => p.ToplamAdet);
                }
                VMAnaliz Analiz = new VMAnaliz
                {
                    Gönderilen = Gonderilenurunler,
                    Indirimli = Indirim,
                    Indirimsiz = Indirimsiz,
                    Kullanıcılar = Kullanicilar,
                    Uyeler = Musteriler,
                    OnayBekleyen = OnayBekleyenler,
                    ToplamUrun = ToplamUrun,
                    Gonderilmeyen = Gonderilmeyenurunler,
                    Iptal = IptalEdilen,
                    Ciro = ciroay,
                    UrunEndeks = urunindex
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
                    altkategoriadi = AltKategori,
                    kategori = Kategori,
                    marka = Marka,
                    urunkategoriadi = UrunKategori
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
                    UrunKategoriID = p.UrunKategoriID
                }).ToList();
                return Bul;
            }
        }
        public static List<VMUrun> IndirimliUrun() //İndirimli Ürün
        {
            using (DBCON db = new DBCON())
            {
                var Bul = db.Urun.Where(n => n.IndirimVarmi == true).Select(p => new VMUrun
                {
                    AltKategori = p.AltKategori.AltKategoriAdi,
                    AltKategoriID = p.AltKategoriID,
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
                    UrunKategoriID = p.UrunKategoriID
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
                    UrunKategoriID = p.UrunKategoriID
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
        public static List<VMGunlukToplam> CiroAylik() //Ciro/Toplam Ürün Aylık Listele
        {
            using (DBCON db = new DBCON())
            {
                return db.AylikCiro.OrderByDescending(p => p.Yil).Select(p => new VMGunlukToplam
                {
                    Ay = p.Ay,
                    Yil = p.Yil,
                    ToplamAdet = p.ToplamAdet,
                    ToplamSatis = p.ToplamSatis
                }).ToList();
            }
        }
        public static List<VMGunlukToplam> CiroGunluk(string yil, string ay) //Ciro gunuk Listele
        {
            using (DBCON db = new DBCON())
            {
                return db.GunlukCiro.Where(p => p.Yil == yil && p.Ay == ay).OrderBy(p => p.Gun).Select(p => new VMGunlukToplam
                {
                    Yil = p.Yil,
                    Ay = p.Ay,
                    Gun = p.Gun,
                    ToplamSatis = p.ToplamSatis
                }).ToList();
            }
        }
        public static List<VMGunlukToplam> ToplamGunluk(string yil, string ay) //Toplam Ürün gunluk Listele
        {
            using (DBCON db = new DBCON())
            {
                return db.GunlukCiro.Where(p => p.Yil == yil && p.Ay == ay).OrderBy(p => p.Gun).Select(p => new VMGunlukToplam
                {
                    Yil = p.Yil,
                    Ay = p.Ay,
                    Gun = p.Gun,
                    ToplamAdet = p.ToplamAdet
                }).ToList();
            }
        }
    }
}

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
    public class UrunRepo
    {
        public class KullanicilarRepo
        {
            public static bool UrunKaydet(VMUrun Al) //Ürün Kaydet
            {
                using (DBCON db = new DBCON())
                {
                    bool Control = db.Urun.Any(p => p.UrunAdi == Al.UrunAdi && p.MarkaID == Al.MarkaID);
                    if (Control == true)
                    {
                        return false;
                    }
                    else
                    {
                        db.Urun.Add(new Urun
                        {
                            AltKategoriID = Al.AltKategoriID,
                            Gramaj = Al.Gramaj,
                            Image = Al.Image,
                            IndirimliFiyati = Al.IndirimliFiyati,
                            IndirimVarmi = Al.IndirimVarmi,
                            KategoriID = Al.KategoriID,
                            MarkaID = Al.MarkaID,
                            UrunAciklama = Al.UrunAciklama,
                            UrunAdedi = Al.UrunAdedi,
                            UrunAdi = Al.UrunAdi,
                            UrunFiyati = Al.UrunFiyati,
                            UrunKategoriID = Al.UrunKategoriID,
                            Yorum = Al.Yorum
                        });
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            public static bool UrunGuncelle(VMUrun Al) //Ürün Guncelle
            {
                using (DBCON db = new DBCON())
                {
                    try
                    {
                        var Bul = db.Urun.FirstOrDefault(p => p.UrunID == Al.UrunID);
                        Bul.AltKategoriID = Al.AltKategoriID;
                        Bul.Gramaj = Al.Gramaj;
                        Bul.Image = Al.Image;
                        Bul.IndirimliFiyati = Al.IndirimliFiyati;
                        Bul.IndirimVarmi = Al.IndirimVarmi;
                        Bul.KategoriID = Al.KategoriID;
                        Bul.MarkaID = Al.MarkaID;
                        Bul.UrunAciklama = Al.UrunAciklama;
                        Bul.UrunAdedi = Al.UrunAdedi;
                        Bul.UrunAdi = Al.UrunAdi;
                        Bul.UrunFiyati = Al.UrunFiyati;
                        Bul.UrunKategoriID = Al.UrunKategoriID;
                        Bul.Yorum = Al.Yorum;
                        db.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            public static void UrunSil(string ID) //Ürün Sil
            {
                int id = int.Parse(ID);
                using (DBCON db = new DBCON())
                {
                    var Bul = db.Urun.FirstOrDefault(p => p.UrunID == id);
                    db.Urun.Remove(Bul);
                    db.SaveChanges();
                }
            }
            public static VMUrun UrunBul(string ID) //Ürün Bul
            {
                int id = int.Parse(ID);
                using (DBCON db = new DBCON())
                {
                    return db.Urun.Where(p => p.UrunID == id).Select(p => new VMUrun
                    {
                        AltKategori = p.AltKategori.AltKategoriAdi,
                        AltKategoriID = p.AltKategoriID,
                        Gramaj = p.Gramaj,
                        Image = p.Image,
                        UrunAciklama = p.UrunAciklama,
                        UrunAdedi = p.UrunAdedi,
                        UrunAdi = p.UrunAdi,
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
                    }).FirstOrDefault();
                }
            }
            public static List<VMUrun> UrunleriBul() //Ürünleri Bul
            {
                using (DBCON db = new DBCON())
                {
                    return db.Urun.Select(p => new VMUrun
                    {
                        AltKategori = p.AltKategori.AltKategoriAdi,
                        AltKategoriID = p.AltKategoriID,
                        Gramaj = p.Gramaj,
                        Image = p.Image,
                        UrunAciklama = p.UrunAciklama,
                        UrunAdedi = p.UrunAdedi,
                        UrunAdi = p.UrunAdi,
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
                }
            }
            public static List<VMUrun> UrunleriKategoriyeGoreBul(string ID) //Ürünleri Kategoriye Göre Bul
            {
                int id = int.Parse(ID);
                using (DBCON db = new DBCON())
                {
                    return db.Urun.Where(p=> p.KategoriID==id).Select(p => new VMUrun
                    {
                        AltKategori = p.AltKategori.AltKategoriAdi,
                        AltKategoriID = p.AltKategoriID,
                        Gramaj = p.Gramaj,
                        Image = p.Image,
                        UrunAciklama = p.UrunAciklama,
                        UrunAdedi = p.UrunAdedi,
                        UrunAdi = p.UrunAdi,
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
                }
            }
            public static List<VMUrun> UrunleriAltKategoriyeGoreBul(string ID) //Ürünleri AltKategoriye Göre Bul
            {
                int id = int.Parse(ID);
                using (DBCON db = new DBCON())
                {
                    return db.Urun.Where(p => p.AltKategoriID == id).Select(p => new VMUrun
                    {
                        AltKategori = p.AltKategori.AltKategoriAdi,
                        AltKategoriID = p.AltKategoriID,
                        Gramaj = p.Gramaj,
                        Image = p.Image,
                        UrunAciklama = p.UrunAciklama,
                        UrunAdedi = p.UrunAdedi,
                        UrunAdi = p.UrunAdi,
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
                }
            }
            public static List<VMUrun> UrunleriUrunKategoriyeGoreBul(string ID) //Ürünleri UrunKategoriye Göre Bul
            {
                int id = int.Parse(ID);
                using (DBCON db = new DBCON())
                {
                    return db.Urun.Where(p => p.UrunKategoriID == id).Select(p => new VMUrun
                    {
                        AltKategori = p.AltKategori.AltKategoriAdi,
                        AltKategoriID = p.AltKategoriID,
                        Gramaj = p.Gramaj,
                        Image = p.Image,
                        UrunAciklama = p.UrunAciklama,
                        UrunAdedi = p.UrunAdedi,
                        UrunAdi = p.UrunAdi,
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
                }
            }
            public static List<VMUrun> UrunleriMarkayaGoreBul(string ID) //Ürünleri Markaya Göre Bul
            {
                int id = int.Parse(ID);
                using (DBCON db = new DBCON())
                {
                    return db.Urun.Where(p => p.MarkaID == id).Select(p => new VMUrun
                    {
                        AltKategori = p.AltKategori.AltKategoriAdi,
                        AltKategoriID = p.AltKategoriID,
                        Gramaj = p.Gramaj,
                        Image = p.Image,
                        UrunAciklama = p.UrunAciklama,
                        UrunAdedi = p.UrunAdedi,
                        UrunAdi = p.UrunAdi,
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
                }
            }
        }
    }
}

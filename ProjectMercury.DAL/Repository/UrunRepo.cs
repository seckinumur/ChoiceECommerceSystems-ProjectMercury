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
        public static bool UrunKaydet(VMUrun Al) //Ürün Kaydet
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    if (Al.IndirimliFiyati == 0)
                    {
                        Al.IndirimVarmi = false;
                        Al.IndirimliFiyati = 0;
                    }
                    else
                    {
                        Al.IndirimVarmi = true;
                    }
                    if (Al.UrunKategori == "Ürün Kategori Yok")
                    {
                        Al.UrunKategoriID = 1;
                    }
                    else
                    {
                        Al.UrunKategoriID = db.UrunKategori.FirstOrDefault(p => p.UrunKategoriAdi == Al.UrunKategori).UrunKategoriID;
                    }
                    var marka = db.Marka.FirstOrDefault(p => p.MarkaAdi == Al.Marka);
                    var kategori = db.Kategori.FirstOrDefault(p => p.KategoriAdi == Al.Kategori);
                    var altkategori = db.AltKategori.FirstOrDefault(p => p.AltKategoriAdi == Al.AltKategori);


                    bool Control = db.Urun.Any(p => p.UrunAdi == Al.UrunAdi && p.MarkaID == marka.MarkaID);
                    if (Control == true)
                    {
                        return false;
                    }
                    else
                    {
                        db.Urun.Add(new Urun
                        {
                            AltKategoriID = altkategori.AltKategoriID,
                            Image = Al.Image,
                            IndirimliFiyati = Al.IndirimliFiyati,
                            IndirimVarmi = Al.IndirimVarmi,
                            KategoriID = kategori.KategoriID,
                            MarkaID = marka.MarkaID,
                            UrunAciklama = Al.UrunAciklama.Trim(),
                            UrunAdedi = Al.UrunAdedi,
                            UrunAdi = Al.UrunAdi.Trim(),
                            UrunFiyati = Al.UrunFiyati,
                            UrunKategoriID = Al.UrunKategoriID
                        });
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

        public static bool UrunGuncelle(VMUrun Al) //Ürün Guncelle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    if (Al.IndirimliFiyati == 0)
                    {
                        Al.IndirimVarmi = false;
                        Al.IndirimliFiyati = 0;
                    }
                    else
                    {
                        Al.IndirimVarmi = true;
                    }
                    if (Al.UrunKategori == "Ürün Kategori Yok")
                    {
                        Al.UrunKategoriID = 1;
                    }
                    else
                    {
                        Al.UrunKategoriID = db.UrunKategori.FirstOrDefault(p => p.UrunKategoriAdi == Al.UrunKategori).UrunKategoriID;
                    }
                    var marka = db.Marka.FirstOrDefault(p => p.MarkaAdi == Al.Marka);
                    var kategori = db.Kategori.FirstOrDefault(p => p.KategoriAdi == Al.Kategori);
                    var altkategori = db.AltKategori.FirstOrDefault(p => p.AltKategoriAdi == Al.AltKategori);

                    var Bul = db.Urun.FirstOrDefault(p => p.UrunID == Al.UrunID);
                    Bul.AltKategoriID = altkategori.AltKategoriID;
                    Bul.Image = Al.Image;
                    Bul.IndirimliFiyati = Al.IndirimliFiyati;
                    Bul.IndirimVarmi = Al.IndirimVarmi;
                    Bul.KategoriID = kategori.KategoriID;
                    Bul.MarkaID = marka.MarkaID;
                    Bul.UrunAciklama = Al.UrunAciklama.Trim();
                    Bul.UrunAdedi = Al.UrunAdedi;
                    Bul.UrunAdi = Al.UrunAdi.Trim();
                    Bul.UrunFiyati = Al.UrunFiyati;
                    Bul.UrunKategoriID = Al.UrunKategoriID;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool UrunSil(int ID) //Ürün Sil
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Urun.FirstOrDefault(p => p.UrunID == ID);
                    db.Urun.Remove(Bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool UrunStokEkle(VMUrun Data) //Ürün Stok Ekle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Urun.FirstOrDefault(p => p.UrunID == Data.UrunID);
                    Bul.UrunAdedi += Data.UrunAdedi;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static VMUrun UrunBul(int ID) //Ürün Bul
        {
            using (DBCON db = new DBCON())
            {
                return db.Urun.Where(p => p.UrunID == ID).Select(p => new VMUrun
                {
                    AltKategori = p.AltKategori.AltKategoriAdi,
                    AltKategoriID = p.AltKategoriID,
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
                    UrunKategoriID = p.UrunKategoriID
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
                    UrunKategoriID = p.UrunKategoriID
                }).ToList();
            }
        }
        public static List<VMUrun> UrunleriKategoriyeGoreBul(string ID) //Ürünleri Kategoriye Göre Bul
        {
            int id = int.Parse(ID);
            using (DBCON db = new DBCON())
            {
                return db.Urun.Where(p => p.KategoriID == id).Select(p => new VMUrun
                {
                    AltKategori = p.AltKategori.AltKategoriAdi,
                    AltKategoriID = p.AltKategoriID,
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
                    UrunKategoriID = p.UrunKategoriID
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
                    UrunKategoriID = p.UrunKategoriID
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
                    UrunKategoriID = p.UrunKategoriID
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
                    UrunKategoriID = p.UrunKategoriID
                }).ToList();
            }
        }
        public static bool IndirimDegistir(VMUrun Al) //Ürünleri Markaya Göre Bul
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Degistir = db.Urun.FirstOrDefault(p => p.UrunID == Al.UrunID);
                    if (Al.IndirimliFiyati == 0)
                    {
                        Degistir.IndirimVarmi = false;
                        Degistir.IndirimliFiyati = 0;
                    }
                    else
                    {
                        Degistir.IndirimVarmi = true;
                        Degistir.IndirimliFiyati = Al.IndirimliFiyati;
                    }
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}


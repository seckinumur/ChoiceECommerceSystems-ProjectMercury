using ProjectMercury.DAL.Repository;
using ProjectMercury.DAL.VMModels;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProjectMercury.WEB.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Kategori()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = KategoriRepo.Kategoriler();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Kategoriler Sayfa Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "4750";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult Kategori(VMKategori Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Sil")
                    {
                        bool sonucu = KategoriRepo.KategoriSil(Data.KategoriID);
                        if (sonucu == true)
                        {
                            return RedirectToAction("Kategori");
                        }
                        else
                        {
                            TempData["Hata"] = "Kategori Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0051";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Force")
                    {
                        bool sonuc = KategoriRepo.KategoriSilForce(Data.KategoriID);
                        if (sonuc == true)
                        {
                            return RedirectToAction("Kategori");
                        }
                        else
                        {
                            TempData["Hata"] = "Kategori Force Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "88052";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Guncelle")
                    {
                        bool sonuc = KategoriRepo.KategoriGuncelle(Data);
                        if (sonuc == true)
                        {
                            return RedirectToAction("Kategori");
                        }
                        else
                        {
                            TempData["Hata"] = "Kategori Güncelleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0052";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Ekle")
                    {
                        bool sonuc = KategoriRepo.KategoriKaydet(Data);
                        if (sonuc == true)
                        {
                            return RedirectToAction("Kategori");
                        }
                        else
                        {
                            TempData["Hata"] = "Kategori Ekleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0053";
                            return RedirectToAction("Hata");
                        }
                    }
                    else
                    {
                        TempData["Hata"] = "Kategori İşlemleri Başarısız Oldu!";
                        TempData["HataKodu"] = "0050";
                        return RedirectToAction("Hata");
                    }
                }
                catch
                {
                    TempData["Hata"] = "Kategoriler İşlemleri Başarısız Oldu!";
                    TempData["HataKodu"] = "4650";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult AltKategoriler()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = AltKategoriRepo.AltKategoriler();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Alt Kategoriler Sayfa Gosterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "3650";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult AltKategoriler(VMAltKategori Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Sil")
                    {
                        bool sonucu = AltKategoriRepo.AltKategoriSil(Data.AltKategoriID);
                        if (sonucu == true)
                        {
                            return RedirectToAction("AltKategoriler");
                        }
                        else
                        {
                            TempData["Hata"] = "Alt Kategori Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0061";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Force")
                    {
                        bool sonuc = AltKategoriRepo.AltKategoriSilForce(Data.AltKategoriID);
                        if (sonuc == true)
                        {
                            return RedirectToAction("AltKategoriler");
                        }
                        else
                        {
                            TempData["Hata"] = "Alt Kategori Force Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "82052";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Guncelle")
                    {
                        bool sonuc = AltKategoriRepo.AltKategoriGuncelle(Data);
                        if (sonuc == true)
                        {
                            return RedirectToAction("AltKategoriler");
                        }
                        else
                        {
                            TempData["Hata"] = "Alt Kategori Güncelleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0062";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Ekle")
                    {
                        bool sonuc = AltKategoriRepo.AltKategoriKaydet(Data);
                        if (sonuc == true)
                        {
                            return RedirectToAction("AltKategoriler");
                        }
                        else
                        {
                            TempData["Hata"] = "Alt Kategori Ekleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0063";
                            return RedirectToAction("Hata");
                        }
                    }
                    else
                    {
                        TempData["Hata"] = "Alt Kategori İşlemleri Başarısız Oldu!";
                        TempData["HataKodu"] = "0050";
                        return RedirectToAction("Hata");
                    }
                }
                catch
                {
                    TempData["Hata"] = "Alt Kategori Sayfa Gosterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "3350";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult UrunKategori()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = UrunKategoriRepo.UrunKategorileri();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Ürün Kategori Sayfası Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "1250";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult UrunKategori(VMUrunKategori Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Sil")
                    {
                        bool sonucu = UrunKategoriRepo.UrunKategoriSil(Data.UrunKategoriID);
                        if (sonucu == true)
                        {
                            return RedirectToAction("UrunKategori");
                        }
                        else
                        {
                            TempData["Hata"] = "Ürün Kategori Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0071";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Force")
                    {
                        bool sonuc = UrunKategoriRepo.UrunKategoriSilForce(Data.UrunKategoriID);
                        if (sonuc == true)
                        {
                            return RedirectToAction("UrunKategori");
                        }
                        else
                        {
                            TempData["Hata"] = "Ürün Kategori Force Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "98052";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Guncelle")
                    {
                        bool sonuc = UrunKategoriRepo.UrunKategoriGuncelle(Data);
                        if (sonuc == true)
                        {
                            return RedirectToAction("UrunKategori");
                        }
                        else
                        {
                            TempData["Hata"] = "Ürün Kategori Güncelleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0072";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Ekle")
                    {
                        bool sonuc = UrunKategoriRepo.UrunKategoriKaydet(Data);
                        if (sonuc == true)
                        {
                            return RedirectToAction("UrunKategori");
                        }
                        else
                        {
                            TempData["Hata"] = "Ürün Kategori Ekleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0073";
                            return RedirectToAction("Hata");
                        }
                    }
                    else
                    {
                        TempData["Hata"] = "Kategori İşlemleri Başarısız Oldu!";
                        TempData["HataKodu"] = "0050";
                        return RedirectToAction("Hata");
                    }
                }
                catch
                {
                    TempData["Hata"] = "Ürün Kategori Sayfası Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "0150";
                    return RedirectToAction("Hata");
                } 
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Marka()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = MarkaRepo.Markalar();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Marka Güncelleme Sayfası Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "0882";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult Marka(VMMArka Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Sil")
                    {
                        bool sonucu = MarkaRepo.MarkaSil(Data.MarkaID);
                        if (sonucu == true)
                        {
                            return RedirectToAction("Marka");
                        }
                        else
                        {
                            TempData["Hata"] = "Marka Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0081";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Force")
                    {
                        bool sonuc = MarkaRepo.MarkaSilForce(Data.MarkaID);
                        if (sonuc == true)
                        {
                            return RedirectToAction("Marka");
                        }
                        else
                        {
                            TempData["Hata"] = "Marka Force Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "28052";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Guncelle")
                    {
                        bool sonuc = MarkaRepo.MarkaGuncelle(Data);
                        if (sonuc == true)
                        {
                            return RedirectToAction("Marka");
                        }
                        else
                        {
                            TempData["Hata"] = "Marka Güncelleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0082";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Ekle")
                    {
                        bool sonuc = MarkaRepo.MarkaKaydet(Data);
                        if (sonuc == true)
                        {
                            return RedirectToAction("Marka");
                        }
                        else
                        {
                            TempData["Hata"] = "Marka Ekleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0083";
                            return RedirectToAction("Hata");
                        }
                    }
                    else
                    {
                        TempData["Hata"] = "Marka İşlemleri Başarısız Oldu!";
                        TempData["HataKodu"] = "0050";
                        return RedirectToAction("Hata");
                    }
                }
                catch
                {
                    TempData["Hata"] = "Marka Güncelleme İşlemi Başarısız Oldu!";
                    TempData["HataKodu"] = "0082";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult KategoriListele(int id)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    ViewBag.KategoriAdi = KategoriRepo.KategoriIsmiBul(id);
                    var Bul = KategoriRepo.KategoriListele(id);
                    return View(Bul);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "0010";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult AltKategori(int id)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    ViewBag.KategoriAdi = KategoriRepo.KategoriIsmiBul(id);
                    var Bul = KategoriRepo.KategoriListele(id);
                    return View(Bul);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "0010";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult AltKategoriListele(int id)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    ViewBag.KategoriAdi = AltKategoriRepo.AltKategoriKategoriBul(id);
                    ViewBag.AltKategoriAdi = AltKategoriRepo.AltKategoriBul(id);
                    var Bul = UrunRepo.UrunleriAltKategoriyeGoreBul(id.ToString());
                    return View(Bul);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "0011";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult AltKategoriListele(VMUrun Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Degistir")
                    {
                        bool Sonucu = UrunRepo.IndirimDegistir(Data);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("AltKategoriListele");
                        }
                        else
                        {
                            TempData["Hata"] = "Ürün İndirim Güncelleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0041";
                            return RedirectToAction("Hata");
                        }
                    }
                    else if (Data.Gorev == "Sil")
                    {
                        bool sonucu = UrunRepo.UrunSil(Data.UrunID);
                        if(sonucu == true)
                        {
                            return RedirectToAction("AltKategoriListele");
                        }
                        else
                        {
                            TempData["Hata"] = "Ürün Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0090";
                            return RedirectToAction("Hata");
                        }
                    }
                    else
                    {
                        TempData["Hata"] = "Ürün İndirim Güncelleme İşlemi Başarısız Oldu!";
                        TempData["HataKodu"] = "0040";
                        return RedirectToAction("Hata");
                    }
                    
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "0011";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult UrunEkle()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = AnalizRepo.UrunKaydetKategori();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı Ürün Ekleme Sayfası Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "6111";
                    return RedirectToAction("Hata");
                }
                
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult UrunEkle(VMUrun Data, HttpPostedFileBase Resim)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    WebImage img = new WebImage(Resim.InputStream);
                    FileInfo imginfo = new FileInfo(Resim.FileName);
                    string newfoto = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(860, 480);
                    img.Save("~/images/ImageStore/" + newfoto);
                    Data.Image = "/images/ImageStore/" + newfoto;
                    bool sonuc = UrunRepo.UrunKaydet(Data);
                    if(sonuc != true)
                    {
                        TempData["Hata"] = "Database Bağlantısı Sağlanamadı Ürün Ekleme İşlemi Başarısız Oldu!";
                        TempData["HataKodu"] = "1111";
                        return RedirectToAction("Hata");
                    }
                    TempData["1"] = "alert alert-success";
                    TempData["2"] = false;
                    TempData["3"] = "Ürün Başarıyla Kaydedildi! Şimdi Başka Bir Ürün Ekleyebilirsiniz.";
                    return RedirectToAction("UrunEkle");
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı Ürün Ekleme İşlemi Başarısız Oldu!";
                    TempData["HataKodu"] = "1111";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult UrunDuzenle(int ID)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Al = AnalizRepo.UrunKaydetKategori();
                    ViewBag.Marka = Al.marka;
                    ViewBag.Kategori = Al.kategori;
                    ViewBag.AltKategori = Al.altkategoriadi;
                    ViewBag.UrunKategori = Al.urunkategoriadi;
                    var Data = UrunRepo.UrunBul(ID);
                    if(Data != null)
                    {
                        return View(Data);
                    }
                    else
                    {
                        TempData["Hata"] = "Database Bağlantısı Sağlanamadı Ürün Bulma İşlemi Başarısız Oldu!";
                        TempData["HataKodu"] = "2111";
                        return RedirectToAction("Hata");
                    }
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı Ürün Bulma İşlemi Başarısız Oldu!";
                    TempData["HataKodu"] = "2111";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult UrunDuzenle(VMUrun Data, HttpPostedFileBase Resim)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (System.IO.File.Exists(Server.MapPath("~" + Data.Image)))
                    {
                        System.IO.File.Delete(Server.MapPath("~"+Data.Image));
                    }

                    WebImage img = new WebImage(Resim.InputStream);
                    FileInfo imginfo = new FileInfo(Resim.FileName);
                    string newfoto = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(860, 480);
                    img.Save("~/images/ImageStore/" + newfoto);
                    Data.Image = "/images/ImageStore/" + newfoto;

                    bool Result = UrunRepo.UrunGuncelle(Data);
                    if (Result == true)
                    {
                        var Al = AnalizRepo.UrunKaydetKategori();
                        ViewBag.Marka = Al.marka;
                        ViewBag.Kategori = Al.kategori;
                        ViewBag.AltKategori = Al.altkategoriadi;
                        ViewBag.UrunKategori = Al.urunkategoriadi;
                        var gonder = UrunRepo.UrunBul(Data.UrunID);
                        TempData["1"] = "alert alert-success";
                        TempData["2"] = false;
                        TempData["3"] = "Ürün Başarıyla Güncellendi!";
                        return View(gonder);
                    }
                    else
                    {
                        TempData["Hata"] = "Database Bağlantısı Sağlanamadı Ürün Kaydetme İşlemi Başarısız Oldu!";
                        TempData["HataKodu"] = "8111";
                        return RedirectToAction("Hata");
                    }
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı Ürün Bulma İşlemi Başarısız Oldu!";
                    TempData["HataKodu"] = "2111";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Hata()
        {
            if (Session["Login"] != null)
            {
                return View();
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
    }
}
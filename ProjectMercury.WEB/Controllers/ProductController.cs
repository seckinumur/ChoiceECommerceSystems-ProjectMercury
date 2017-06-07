using ProjectMercury.DAL.Repository;
using ProjectMercury.DAL.VMModels;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMercury.WEB.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Kategori()
        {
            if (Session["Login"] != null)
            {
                var Gonder = KategoriRepo.Kategoriler();
                return View(Gonder);
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
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult AltKategori()
        {
            if (Session["Login"] != null)
            {
                var Gonder = AltKategoriRepo.AltKategoriler();
                return View(Gonder);
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
        public ActionResult AltKategori(VMAltKategori Data)
        {
            if (Session["Login"] != null)
            {
                if (Data.Gorev == "Sil")
                {
                    bool sonucu = AltKategoriRepo.AltKategoriSil(Data.AltKategoriID);
                    if (sonucu == true)
                    {
                        return RedirectToAction("AltKategori");
                    }
                    else
                    {
                        TempData["Hata"] = "Alt Kategori Silme İşlemi Başarısız Oldu!";
                        TempData["HataKodu"] = "0061";
                        return RedirectToAction("Hata");
                    }
                }
                else if (Data.Gorev == "Guncelle")
                {
                    bool sonuc = AltKategoriRepo.AltKategoriGuncelle(Data);
                    if (sonuc == true)
                    {
                        return RedirectToAction("AltKategori");
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
                        return RedirectToAction("AltKategori");
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
                var Gonder = UrunKategoriRepo.UrunKategorileri();
                return View(Gonder);
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
                var Gonder = MarkaRepo.Markalar();
                return View(Gonder);
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
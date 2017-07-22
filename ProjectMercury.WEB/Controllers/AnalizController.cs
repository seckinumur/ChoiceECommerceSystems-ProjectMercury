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
    public class AnalizController : Controller
    {
        public ActionResult TumUrunler()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = AnalizRepo.ToplamUrun();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Stok Sayfasının Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "8965";
                    return RedirectToAction("Hata", "Product");
                }
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult TumUrunler(VMUrun Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Stok")
                    {
                        bool Sonucu = UrunRepo.UrunStokEkle(Data);
                        if (Sonucu == true)
                        {
                            var Gonder = AnalizRepo.ToplamUrun();
                            return View(Gonder);
                        }
                        else
                        {
                            TempData["Hata"] = "Ürün Stok Güncelleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "02241";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Sil")
                    {
                        bool sonucu = UrunRepo.UrunSil(Data.UrunID);
                        if (sonucu == true)
                        {
                            var Gonder = AnalizRepo.ToplamUrun();
                            return View(Gonder);
                        }
                        else
                        {
                            TempData["Hata"] = "Ürün Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "1090";
                            return RedirectToAction("Hata", "Product");
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
                    TempData["Hata"] = "Stok Sayfasının Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "8966";
                    return RedirectToAction("Hata", "Product");
                }
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult IndirimliUrunler()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = AnalizRepo.IndirimliUrun();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "İndirimli Ürünler Sayfasının Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "8866";
                    return RedirectToAction("Hata", "Product");
                }
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult IndirimliUrunler(VMUrun Data)
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
                            return RedirectToAction("IndirimliUrunler");
                        }
                        else
                        {
                            TempData["Hata"] = "Ürün İndirim Güncelleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0041";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else
                    {
                        TempData["Hata"] = "Ürün İndirim Güncelleme İşlemi Başarısız Oldu!";
                        TempData["HataKodu"] = "0040";
                        return RedirectToAction("Hata", "Product");
                    }
                }
                catch
                {
                    TempData["UyariTipi"] = "text-danger";
                    TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                    return RedirectToAction("Login", "Admin");
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
        public ActionResult IndirimsizUrunler()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = AnalizRepo.IndirimsizUrun();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "İndirimsiz Ürünler Sayfasının Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "7786";
                    return RedirectToAction("Hata", "Product");
                }
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult IndirimsizUrunler(VMUrun Data)
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
                            return RedirectToAction("IndirimsizUrunler");
                        }
                        else
                        {
                            TempData["Hata"] = "Ürün İndirim Güncelleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "0031";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else
                    {
                        TempData["Hata"] = "Ürün İndirim Güncelleme İşlemi Başarısız Oldu!";
                        TempData["HataKodu"] = "0030";
                        return RedirectToAction("Hata", "Product");
                    }
                }
                catch
                {
                    TempData["Hata"] = "İndirimsiz Ürünler Sayfasının İşlemi Başarısız Oldu!";
                    TempData["HataKodu"] = "7886";
                    return RedirectToAction("Hata", "Product");
                }
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Ciro()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = AnalizRepo.CiroAylik();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Ciro Sayfasının Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "773386";
                    return RedirectToAction("Hata", "Product");
                }
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult UrunEndeks()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = AnalizRepo.CiroAylik();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Toplam Satış Sayfasının Gösterimi Başarısız Oldu!";
                    TempData["HataKodu"] = "7733386";
                    return RedirectToAction("Hata", "Product");
                }
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult CiroGun(string Yil, string Ay)
        {
            var gonder = AnalizRepo.CiroGunluk(Yil,Ay);
            return Json(gonder, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ToplamGun(string Yil, string Ay)
        {
            var gonder = AnalizRepo.ToplamGunluk(Yil, Ay);
            return Json(gonder, JsonRequestBehavior.AllowGet);
        }
    }
}
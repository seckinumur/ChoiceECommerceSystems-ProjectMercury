using ProjectMercury.DAL.Repository;
using ProjectMercury.DAL.VMModels;
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
                var Gonder = AnalizRepo.ToplamUrun();
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
        public ActionResult IndirimliUrunler()
        {
            if (Session["Login"] != null)
            {
                var Gonder = AnalizRepo.IndirimliUrun();
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
        public ActionResult IndirimliUrunler(VMUrun Data)
        {
            if (Session["Login"] != null)
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
                        return RedirectToAction("Hata","Product");
                    }
                }
                else
                {
                    TempData["Hata"] = "Ürün İndirim Güncelleme İşlemi Başarısız Oldu!";
                    TempData["HataKodu"] = "0040";
                    return RedirectToAction("Hata", "Product");
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
                var Gonder = AnalizRepo.IndirimsizUrun();
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
        public ActionResult IndirimsizUrunler(VMUrun Data)
        {
            if (Session["Login"] != null)
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
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
                return RedirectToAction("Login","Admin");
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
                else if(Data.Gorev== "Guncelle")
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
                else if(Data.Gorev == "Ekle")
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
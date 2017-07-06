using ProjectMercury.DAL.Repository;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMercury.WEB.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch
            {
                TempData["Hata"] = "Sistem Login Sayfasını Göstermeyi Denedi Ancak Gösterim Başarısız Oldu. Bu Kritik Bir Sistem Hatasıdır.";
                TempData["HataKodu"] = "6666";
                return RedirectToAction("Hata","Product");
            }
        }
        public ActionResult Logoff()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("Login");
            }
            catch
            {
                TempData["Hata"] = "Sistem Login İşleminden Çıkmak İstedi Ancak Bu İşlem Başarız Oldu. Bu Kritik Bir Sistem Hatasıdır.";
                TempData["HataKodu"] = "9666";
                return RedirectToAction("Hata", "Product");
            }
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar Al)
        {
            try
            {
                int Kontrol = KullanicilarRepo.KullaniciGiris(Al);
                if (Kontrol != 0)
                {
                    Session["Login"] = Kontrol;
                    return RedirectToAction("Admin");
                }
                else
                {
                    TempData["UyariTipi"] = "alert alert-danger";
                    TempData["Uyari"] = false;
                    TempData["Sonuc"] = "Kullanıcı Adı Yada Parolası Hatalı!";
                    return View();
                }
            }
            catch
            {
                TempData["Hata"] = "Sistem Login işlemini Gerçekleştirmek İçin Çağrıda Bulundu Ancak Database Bu İşleme Yanıt Vermedi Yada Yanıt Verme Süresi Sona Erdi. Bu Kritik Bir Sistem Hatasıdır.";
                TempData["HataKodu"] = "9966";
                return RedirectToAction("Hata", "Product");
            }
        }
        public ActionResult Admin()
        {
            if(Session["Login"] != null)
            {
                try
                {
                    var Gonder = AnalizRepo.Analiz();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Sistem Admin Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "9866";
                    return RedirectToAction("Hata", "Product");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login");
            }
        }
        public ActionResult Ayarlar()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = AyarlarRepo.AyarlariListele();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Sistem Ayarlar Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "559866";
                    return RedirectToAction("Hata", "Product");
                }
            }
            else
            {
                TempData["UyariTipi"] = "alert alert-danger";
                TempData["Uyari"] = false;
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login");
            }
        }
    }
}
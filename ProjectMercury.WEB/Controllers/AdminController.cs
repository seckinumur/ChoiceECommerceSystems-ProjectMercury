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
            return View();
        }
        public ActionResult Logoff()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar Al)
        {
            bool Kontrol = KullanicilarRepo.KullaniciGiris(Al);
            if (Kontrol == true)
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
        public ActionResult Admin()
        {
            if(Session["Login"] != null)
            {
                var Gonder = AnalizRepo.Analiz();
                return View(Gonder);
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
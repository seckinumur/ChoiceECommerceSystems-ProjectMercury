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
        [HttpPost]
        public ActionResult Login(Kullanicilar Al)
        {
            bool Kontrol = KullanicilarRepo.KullaniciGiris(Al);
            if (Kontrol == true)
            {
                Session["Login"] = "Admin";
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.UyariTipi = "alert alert-warning";
                ViewBag.Uyari = false;
                ViewBag.Sonuc = "Kullanıcı Adı Yada Parolası Hatalı!";
                return View();
            }
        }
        public ActionResult Admin()
        {
            if(Session["Login"].ToString() == "Admin")
            {
                var Gonder = AnalizRepo.Analiz();
                return View(Gonder);
            }
            else
            {
                ViewBag.UyariTipi = "alert alert-warning";
                ViewBag.Uyari = false;
                ViewBag.Sonuc = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login");
            }
        }
    }
}
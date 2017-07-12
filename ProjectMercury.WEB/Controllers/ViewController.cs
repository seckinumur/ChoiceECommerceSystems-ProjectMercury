using ProjectMercury.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMercury.WEB.Controllers
{
    public class ViewController : Controller
    {
        // GET: View
        public ActionResult Anasayfa()
        {
            if (Session["User"] != null)
            {
                try
                {
                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    var Gonder = ViewRepo.VievIndexAI();
                    if(Gonder == null)
                    {
                        return View(Gonder);
                    }
                    else
                    {
                        return View();
                    }
                }
                catch
                {
                    TempData["Hata"] = "Sistem Admin Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "9866";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                try
                {
                    ViewBag.User = "Misafir Kullanıcı";
                    var Gonder = ViewRepo.VievIndexAI();
                        return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Sistem Admin Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "9866";
                    return RedirectToAction("Hata");
                }
            }

        }
        public ActionResult Kategori(int ID)
        {
            if (Session["User"] != null)
            {
                try
                {
                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    var Gonder = ViewRepo.KategoriyeGore(ID);
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Sistem Admin Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "9866";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                try
                {
                    ViewBag.User = "Misafir Kullanıcı";
                    var Gonder = ViewRepo.KategoriyeGore(ID);
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Sistem Admin Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "9866";
                    return RedirectToAction("Hata");
                }
            }

        }
        public ActionResult Hata()
        {
            return View();
        }
        public ActionResult HataBulunamadi()
        {
            return View();
        }
    }
}
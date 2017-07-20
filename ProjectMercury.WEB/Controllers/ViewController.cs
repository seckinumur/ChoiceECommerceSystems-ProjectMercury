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
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
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
            else
            {
                try
                {
                    ViewBag.User = "Misafir Kullanıcı";
                    ViewBag.Sepet = "Sepette Bekleyen Ürün Yok";
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
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
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
                    ViewBag.Sepet = "Sepette Bekleyen Ürün Yok";
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
        [HttpPost]
        public ActionResult Kategori(int data, int data2)
        {
            if (Session["User"] != null)
            {
                try
                {
                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
                    //var Gonder = ViewRepo.KategoriyeGore(ID);
                    return View();
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
                    ViewBag.Sepet = "Sepette Bekleyen Ürün Yok";
                    //var Gonder = ViewRepo.KategoriyeGore(ID);
                    return View();
                }
                catch
                {
                    TempData["Hata"] = "Sistem Admin Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "9866";
                    return RedirectToAction("Hata");
                }
            }
        }
        public ActionResult AltKategori(int ID)
        {
            if (Session["User"] != null)
            {
                try
                {
                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
                    var Gonder = ViewRepo.AltKategoriyeGore(ID);
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
                    ViewBag.Sepet = "Sepette Bekleyen Ürün Yok";
                    var Gonder = ViewRepo.AltKategoriyeGore(ID);
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
        public ActionResult UrunKategori(int ID)
        {
            if (Session["User"] != null)
            {
                try
                {
                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
                    var Gonder = ViewRepo.UrunKategoriyeGore(ID);
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
                    ViewBag.Sepet = "Sepette Bekleyen Ürün Yok";
                    var Gonder = ViewRepo.UrunKategoriyeGore(ID);
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
        public ActionResult Marka(int ID)
        {
            if (Session["User"] != null)
            {
                try
                {
                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
                    var Gonder = ViewRepo.Markayagore(ID);
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
                    ViewBag.Sepet = "Sepette Bekleyen Ürün Yok";
                    var Gonder = ViewRepo.Markayagore(ID);
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
        public ActionResult Odeme()
        {
            if (Session["User"] != null)
            {
                try
                {
                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
                    return View();
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
                    ViewBag.Sepet = "Sepette Bekleyen Ürün Yok";
                    return View();
                }
                catch
                {
                    TempData["Hata"] = "Sistem Admin Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "9866";
                    return RedirectToAction("Hata");
                }
            }
        }

        public ActionResult Uye()
        {
            if (Session["User"] != null)
            {
                try
                {
                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
                    return View();
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
                    ViewBag.Sepet = "Sepette Bekleyen Ürün Yok";
                    return View();
                }
                catch
                {
                    TempData["Hata"] = "Sistem Admin Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "9866";
                    return RedirectToAction("Hata");
                }
            }
        }
        //[HttpPost]
        //public Action Sepet(int UrunID,string Gorev)
        //{

        //    return Json(gonder, JsonRequestBehavior.AllowGet);
        //}
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
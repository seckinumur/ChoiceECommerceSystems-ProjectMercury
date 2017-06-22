using ProjectMercury.DAL.Repository;
using ProjectMercury.DAL.VMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMercury.WEB.Controllers
{
    public class SiparisController : Controller
    {
        public ActionResult Gonderilen()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = SiparisRepo.GonderilenSiparisler();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "1811";
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
        [HttpPost]
        public ActionResult Gonderilen(VMSiparis Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    SiparisRepo.SiparisSil(Data.SiparisID);
                    var Gonder = SiparisRepo.GonderilenSiparisler();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "1811";
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
        public ActionResult Gonderilmeyen()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = SiparisRepo.GonderilmeyenSiparisler();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "1811";
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
        public ActionResult sepetlistele(int id)
        {
            var gonder = SiparisRepo.UrunSepeti(id);
            return Json(gonder, JsonRequestBehavior.AllowGet);
        }
    }
}
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
                try
                {
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
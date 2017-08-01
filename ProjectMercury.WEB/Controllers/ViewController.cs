using ProjectMercury.DAL.Repository;
using ProjectMercury.DAL.VMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMercury.WEB.Controllers
{
    public class ViewController : Controller
    {
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
                    var gonder = UyeSepetRepo.Liste(Session["User"].ToString());
                    return View(gonder);
                }
                catch
                {
                    TempData["Hata"] = "Sistem Ödeme Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "983366";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                try
                {
                    ViewBag.User = "Misafir Kullanıcı";
                    ViewBag.Sepet = "Sepette Bekleyen Ürün Yok";
                    return RedirectToAction("Anasayfa");
                }
                catch
                {
                    TempData["Hata"] = "Sistem Ödeme Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "983366";
                    return RedirectToAction("Hata");
                }
            }
        }
        [HttpPost]
        public ActionResult Odeme(VMUyeSepet Data)
        {
            if (Session["User"] != null)
            {
                try
                {
                    if (Data.Gorev == "Adet")
                    {
                        bool sonuc = UyeSepetRepo.Adet(Data.UyelerID, Data.UrunID, Data.UrunAdet);
                        if (sonuc != true)
                        {
                            TempData["Hata"] = "Sistem Ödeme Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                            TempData["HataKodu"] = "9833366";
                            return RedirectToAction("Hata");
                        }
                    }

                    else if (Data.Gorev == "Sil")
                    {
                        bool sonuc1 = UyeSepetRepo.SepettenCikarma(Data.UyelerID, Data.UrunID);
                        if (sonuc1 != true)
                        {
                            TempData["Hata"] = "Sistem Ödeme Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                            TempData["HataKodu"] = "9833966";
                            return RedirectToAction("Hata");
                        }
                    }

                    else if (Data.Gorev == "Guncelle")
                    {
                        bool sonuc2 = UyelerRepo.UyeGuncelleHizli(Data);
                        if (sonuc2 != true)
                        {
                            TempData["Hata"] = "Sistem Ödeme Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                            TempData["HataKodu"] = "9837966";
                            return RedirectToAction("Hata");
                        }
                    }

                    else if (Data.Gorev == "Gonder")
                    {
                        bool sonuc3 = UyeSepetRepo.Gonder(Data.UyelerID);
                        if (sonuc3 != true)
                        {
                            TempData["Hata"] = "Sistem Ödeme Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                            TempData["HataKodu"] = "9827966";
                            return RedirectToAction("Hata");
                        }
                    }

                    else
                    {
                        TempData["Hata"] = "Sistem Ödeme Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                        TempData["HataKodu"] = "9847966";
                        return RedirectToAction("Hata");
                    }

                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
                    var gonder = UyeSepetRepo.Liste(Session["User"].ToString());
                    return View(gonder);
                }
                catch
                {
                    TempData["Hata"] = "Sistem Ödeme Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "983366";
                    return RedirectToAction("Hata");
                }
            }
            else
            {
                try
                {
                    ViewBag.User = "Misafir Kullanıcı";
                    ViewBag.Sepet = "Sepette Bekleyen Ürün Yok";
                    return RedirectToAction("Anasayfa");
                }
                catch
                {
                    TempData["Hata"] = "Sistem Ödeme Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "983366";
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
                    var gonder = UyelerRepo.UyeListele(Session["User"].ToString());
                    return View(gonder);
                }
                catch
                {
                    TempData["Hata"] = "Sistem Üye Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "982266";
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
                    TempData["Hata"] = "Sistem Üye Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "922866";
                    return RedirectToAction("Hata");
                }
            }
        }
        [HttpPost]
        public ActionResult Uye(VMUyeler Data)
        {
            if (Session["User"] != null)
            {
                try
                {
                    bool sonuc = UyelerRepo.UyeGuncelle(Data);
                    if(sonuc != true)
                    {
                        TempData["Hata"] = "Sistem Üye Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                        TempData["HataKodu"] = "926866";
                        return RedirectToAction("Hata");
                    }
                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
                    var gonder = UyelerRepo.UyeListele(Session["User"].ToString());
                    return View(gonder);
                }
                catch
                {
                    TempData["Hata"] = "Sistem Üye Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "986996";
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
        public ActionResult Siparisler()
        {
            if (Session["User"] != null)
            {
                try
                {
                    ViewBag.User = UyelerRepo.UyeIsmi(Session["User"].ToString());
                    ViewBag.Sepet = ViewRepo.UyeSepet(Session["User"].ToString());
                    var gonder = SiparisRepo.UyeSiparisListele(Session["User"].ToString());
                    return View(gonder);
                }
                catch
                {
                    TempData["Hata"] = "Sistem Siparişler Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                    TempData["HataKodu"] = "95996";
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
        [HttpPost]
        public ActionResult Sepet(int UrunID, string Gorev)
        {
            if (Session["User"] != null)
            {
                int Uye = int.Parse(Session["User"].ToString());
                bool sonuc = UyeSepetRepo.Ekle(Uye, UrunID);
                if (sonuc != false)
                {
                    return Json(new { success = true, responseText = "Ürün Sepete Başarıyla Eklendi!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Ürün Sepete Eklenirken Hata Oluştu!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, responseText = "Önce Sisteme Giriş Yapmalısınız!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Logoff()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("Anasayfa");
            }
            catch
            {
                TempData["Hata"] = "Sistem Login İşleminden Çıkmak İstedi Ancak Bu İşlem Başarız Oldu. Bu Kritik Bir Sistem Hatasıdır.";
                TempData["HataKodu"] = "9666";
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
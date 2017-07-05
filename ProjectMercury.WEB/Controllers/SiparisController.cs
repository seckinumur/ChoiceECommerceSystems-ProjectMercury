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
        [HttpPost]
        public ActionResult Gonderilmeyen(VMSiparis Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Sil")
                    {
                        SiparisRepo.SiparisSil(Data.SiparisID);
                    }
                    else if (Data.Gorev == "Gonder")
                    {
                        SiparisRepo.SiparisGonder(Data.SiparisID);
                    }
                    else if (Data.Gorev == "Iptal")
                    {
                        SiparisRepo.SiparisİptalEt(Data.SiparisID);
                    }
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
        public ActionResult IptalOlan()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = SiparisRepo.IptalEdilenSiparisler();
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
        public ActionResult IptalOlan(VMSiparis Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Sil")
                    {
                        SiparisRepo.SiparisSil(Data.SiparisID);
                    }
                    else if (Data.Gorev == "Iptal")
                    {
                        SiparisRepo.SiparisİptalEtme(Data.SiparisID);
                    }
                    var Gonder = SiparisRepo.IptalEdilenSiparisler();
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
        
        public ActionResult SiparisOlustur()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = UrunRepo.UrunleriBul();
                    int ID = int.Parse(Session["Login"].ToString());
                    bool kontrol = SepetRepo.SanalSepetKontrol(ID);
                    if(kontrol== true)
                    {
                        ViewBag.ID = ID;
                        TempData["UyariTipi"] = "alert alert-danger";
                        TempData["Uyari"] = false;
                        TempData["Sonuc"] = "Sipariş Sepetinde Daha Önceden Kaydedilmiş Ürünler Bulunmaktadır.";
                    }
                    else
                    {
                        ViewBag.ID = 0;
                    }
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "1711";
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
        public ActionResult SiparisOlustur(string Gorev,int? UyelerID)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    int ID = int.Parse(Session["Login"].ToString());
                    if (Gorev == "Sil")
                    {
                        bool sonuc = SepetRepo.SepetiSilKullanici(ID);
                        if(sonuc == false)
                        {
                            TempData["Hata"] = "Database Bağlantısı Sağlanamadı! Elle Sipariş Silme İşlemi Başarısız";
                            TempData["HataKodu"] = "19921";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Gorev == "Kaydet")
                    {
                      bool sonuc =  SepetRepo.SepetiKaydetKullanici(ID, UyelerID.ToString());
                        if(sonuc == false)
                        {
                            TempData["Hata"] = "Database Bağlantısı Sağlanamadı! Elle Sipariş Kaydetme İşlemi Başarısız";
                            TempData["HataKodu"] = "19911";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    
                    bool kontrol = SepetRepo.SanalSepetKontrol(ID);
                    if (kontrol == true)
                    {
                        ViewBag.ID = ID;
                        TempData["UyariTipi"] = "alert alert-danger";
                        TempData["Uyari"] = false;
                        TempData["Sonuc"] = "Sipariş Sepetinde Daha Önceden Kaydedilmiş Ürünler Bulunmaktadır.";
                    }
                    return RedirectToAction("SiparisOlustur");
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "1711";
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
        public ActionResult OnayBekleyen()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Gonder = SiparisRepo.OnayBEkleyenSiparisler();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "1311";
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
        public ActionResult OnayBekleyen(VMSiparis Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Sil")
                    {
                        SiparisRepo.SiparisSil(Data.SiparisID);
                    }
                    else if (Data.Gorev == "Gonder")
                    {
                        SiparisRepo.SiparisOnayla(Data.SiparisID);
                    }
                    var Gonder = SiparisRepo.OnayBEkleyenSiparisler();
                    return View(Gonder);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı!";
                    TempData["HataKodu"] = "1311";
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
        public ActionResult sepetlistele(int id) //Ajax
        {
            var gonder = SiparisRepo.UrunSepeti(id);
            return Json(gonder, JsonRequestBehavior.AllowGet);
        }

        public ActionResult sepetlistelekullanicilar(int ID) //Ajax
        {
            var gonder = SepetRepo.SanalSepeteListe(ID);
            return Json(gonder, JsonRequestBehavior.AllowGet);
        }

        public ActionResult sepetekle(int urunId, int adet) //Ajax 
        {
            int Kullanici = int.Parse(Session["Login"].ToString());
            var gonder = SepetRepo.SanalSepeteEkle(Kullanici, urunId, adet);
            return Json(gonder, JsonRequestBehavior.AllowGet);
        }

        public ActionResult sepetcikar(int urunId, int adet) //Ajax 
        {
            int Kullanici = int.Parse(Session["Login"].ToString());
            var gonder = SepetRepo.SanalSepeteCikar(Kullanici, urunId, adet);
            return Json(gonder, JsonRequestBehavior.AllowGet);
        }
    }
}
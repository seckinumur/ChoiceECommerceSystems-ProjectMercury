using ProjectMercury.DAL.Repository;
using ProjectMercury.DAL.VMModels;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        public ActionResult Login(VMLogin Al)
        {
            try
            {
                int Admin = KullanicilarRepo.KullaniciGiris(Al);
                int User = UyelerRepo.UyeGirisi(Al);
                if (Admin != 0)
                {
                    Session["Login"] = Admin;
                    return RedirectToAction("Admin");
                }
                else if(User != 0)
                {
                    Session["User"] = User;
                    return RedirectToAction("Anasayfa","View");
                }
                else
                {
                    TempData["UyariTipi"] = "text-danger";
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
                TempData["UyariTipi"] = "text-danger";
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
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult Ayarlar(VMAyarlar Data, HttpPostedFileBase Resim)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Sil")
                    {
                        bool Sonucu = KullanicilarRepo.KullaniciSil(Data.KullanicilarID);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Ayarlar");
                        }
                        else
                        {
                            TempData["Hata"] = "Kullanıcı Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "188831";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Degistir")
                    {
                        bool Sonucu = KullanicilarRepo.KullaniciGuncelleTekMod(Data.KullanicilarID, Data.KullaniciAdi, Data.KullaniciSifre);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Ayarlar");
                        }
                        else
                        {
                            TempData["Hata"] = "Kullanıcı Düzenleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "134442";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Ekle")
                    {
                        bool Sonucu = KullanicilarRepo.KullaniciKaydetTekMod(Data.KullaniciAdi, Data.KullaniciSifre);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Ayarlar");
                        }
                        else
                        {
                            TempData["Hata"] = "Kullanıcı Düzenleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "1344332";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Company")
                    {
                        if (System.IO.File.Exists(Server.MapPath("~" + Data.Logo)))
                        {
                            System.IO.File.Delete(Server.MapPath("~" + Data.Logo));
                        }
                        WebImage img = new WebImage(Resim.InputStream);
                        FileInfo imginfo = new FileInfo(Resim.FileName);
                        string newfoto = Guid.NewGuid().ToString() + imginfo.Extension;
                        img.Resize(275,90);
                        img.Save("~/images/Company/" + newfoto);
                        Data.Logo = "/images/Company/" + newfoto;
                        SiteBilgileri data = new SiteBilgileri()
                        {
                            Adres = Data.Adres,
                            MailAdresi = Data.MailAdresi,
                            SiteAdi = Data.SiteAdi,
                            Facebook = Data.Facebook,
                            Instagram = Data.Instagram,
                            Logo = Data.Logo,
                            MobilTelefon = Data.MobilTelefon,
                            Telefon = Data.Telefon,
                            Twitter = Data.Twitter,
                            Whatsapp = Data.Whatsapp,
                            Hakkinda= Data.Hakkinda
                        };
                        bool Sonucu = SiteBilgileriRepo.Guncelle(data);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Ayarlar");
                        }
                        else
                        {
                            TempData["Hata"] = "Site Düzenleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "199932";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Sliders")
                    {
                        if (System.IO.File.Exists(Server.MapPath("~" + Data.Slider)))
                        {
                            System.IO.File.Delete(Server.MapPath("~" + Data.Slider));
                        }
                        WebImage img = new WebImage(Resim.InputStream);
                        FileInfo imginfo = new FileInfo(Resim.FileName);
                        string newfoto = Guid.NewGuid().ToString() + imginfo.Extension;
                        img.Resize(1200, 600);
                        img.Save("~/images/Company/Slider/" + newfoto);
                        Data.Slider = "/images/Company/Slider/" + newfoto;
                        
                        bool Sonucu = SliderRepo.SliderDuzenle(Data.SliderId, Data.Slider);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Ayarlar");
                        }
                        else
                        {
                            TempData["Hata"] = "Slider İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "197932";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else
                    {
                        TempData["Hata"] = "Sistem Ayarlar Sayfasının Gösterimini İstedi Ancak Database Bu İşleme Yanıt Vermedi. Bu Kritik Bir Sistem Hatasıdır.";
                        TempData["HataKodu"] = "559866";
                        return RedirectToAction("Hata", "Product");
                    }
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
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Login");
            }
        }
    }
}
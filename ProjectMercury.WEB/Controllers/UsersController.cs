using ProjectMercury.DAL.Repository;
using ProjectMercury.DAL.VMModels;
using ProjectMercury.Entity.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMercury.WEB.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Uyeler()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Bul = UyelerRepo.TumUyeler();
                    return View(Bul);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı! Üyeler Gösterilemiyor";
                    TempData["HataKodu"] = "111";
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
        public ActionResult Uyeler(VMUyeler Data)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    if (Data.Gorev == "Sil")
                    {
                        bool Sonucu = UyelerRepo.UyeSil(Data.UyelerID);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Uyeler");
                        }
                        else
                        {
                            TempData["Hata"] = "Üye Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "131";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Duzenle")
                    {
                        bool Sonucu = UyelerRepo.UyeGuncelle(Data);
                        if(Sonucu == true)
                        {
                            return RedirectToAction("Uyeler");
                        }
                        else
                        {
                            TempData["Hata"] = "Üye Düzenleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "132";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Banla")
                    {
                        bool Sonucu = UyelerRepo.UyeBanla(Data);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Uyeler");
                        }
                        else
                        {
                            TempData["Hata"] = "Üye Banlama İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "132";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "BanKaldir")
                    {
                        bool Sonucu = UyelerRepo.UyeBanlaKaldir(Data);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Uyeler");
                        }
                        else
                        {
                            TempData["Hata"] = "Üye Ban Kaldırma İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "132";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Ekle")
                    {
                        bool Sonucu = UyelerRepo.UyeKaydet(Data);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Uyeler");
                        }
                        else
                        {
                            TempData["Hata"] = "Üye Ekleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "132";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else
                    {
                        TempData["Hata"] = "Üye İşlemleri Başarısız Oldu!";
                        TempData["HataKodu"] = "210";
                        return RedirectToAction("Hata", "Product");
                    }
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı! Üyeler Gösterilemiyor";
                    TempData["HataKodu"] = "111";
                    return RedirectToAction("Login", "Admin");
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
        public ActionResult Kullanici()
        {
            if (Session["Login"] != null)
            {
                try
                {
                    var Bul = KullanicilarRepo.Kullanicilar();
                    return View(Bul);
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı! Kullanicilar Gösterilemiyor";
                    TempData["HataKodu"] = "211";
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
        public ActionResult Kullanici(VMKullanicilar Data)
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
                            return RedirectToAction("Kullanici");
                        }
                        else
                        {
                            TempData["Hata"] = "Kullanıcı Silme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "731";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Duzenle")
                    {
                        bool Sonucu = KullanicilarRepo.KullaniciGuncelle(Data);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Kullanici");
                        }
                        else
                        {
                            TempData["Hata"] = "Kullanıcı Düzenleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "732";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Admin")
                    {
                        bool Sonucu = KullanicilarRepo.AdminYap(Data.KullanicilarID);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Kullanici");
                        }
                        else
                        {
                            TempData["Hata"] = "Kullanıcı Admin İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "732";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else if (Data.Gorev == "Ekle")
                    {
                        bool Sonucu = KullanicilarRepo.KullaniciKaydet(Data);
                        if (Sonucu == true)
                        {
                            return RedirectToAction("Kullanici");
                        }
                        else
                        {
                            TempData["Hata"] = "Kullanıcı Ekleme İşlemi Başarısız Oldu!";
                            TempData["HataKodu"] = "732";
                            return RedirectToAction("Hata", "Product");
                        }
                    }
                    else
                    {
                        TempData["Hata"] = "Kullanıcı İşlemleri Başarısız Oldu!";
                        TempData["HataKodu"] = "710";
                        return RedirectToAction("Hata", "Product");
                    }
                }
                catch
                {
                    TempData["Hata"] = "Database Bağlantısı Sağlanamadı! Kullanicilar Gösterilemiyor";
                    TempData["HataKodu"] = "811";
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
    }
}
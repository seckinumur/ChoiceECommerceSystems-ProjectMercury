﻿using ProjectMercury.DAL.VMModels;
using ProjectMercury.Entity.DBContext;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.Repository
{
    public class UyeSepetRepo
    {
        public static bool Ekle(int kullanici, int urun) //Sanal sepet ekle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var bul = db.SanalSepetUye.FirstOrDefault(p => p.UyelerID == kullanici && p.UrunID == urun);
                    bul.Adet += 1;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    try
                    {
                        db.SanalSepetUye.Add(new SanalSepetUye()
                        {
                            Adet = 1,
                            UyelerID = kullanici,
                            UrunID = urun
                        });
                        db.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
        public static bool SanalSepetKontrol(int ID) //Sanal sepet
        {
            using (DBCON db = new DBCON())
            {
                bool varmi = db.SanalSepetUye.Any(p => p.UyelerID == ID);
                return varmi;
            }
        }
        public static VMSiparisSepeti Liste(string id) //Sanal sepet liste
        {
            using (DBCON db = new DBCON())
            {
                int kullanici = int.Parse(id);
                var Al = Urunler(kullanici);
                var uye = db.Uyeler.FirstOrDefault(p => p.UyelerID == kullanici);
                return new VMSiparisSepeti()
                {
                    Urun = Al,
                    Uye = uye,
                    ToplamFiyat = Al.Sum(p => p.ToplamFiyat)
                };
            }
        }
        private static List<VMUrun> Urunler(int kullanici)
        {
            using (DBCON db = new DBCON())
            {
                return db.SanalSepetUye.Where(p => p.UyelerID == kullanici).Select(p => new VMUrun
                {
                    Image = p.Urun.Image,
                    UrunAdi = p.Urun.UrunAdi,
                    UrunFiyati = (p.Urun.IndirimliFiyati == 0) ? p.Urun.UrunFiyati : p.Urun.IndirimliFiyati,
                    UrunAdedi = p.Adet,
                    ToplamFiyat = (p.Urun.IndirimliFiyati == 0) ? p.Urun.UrunFiyati : p.Urun.IndirimliFiyati * p.Adet,
                    UrunID = p.UrunID
                }).ToList();
            }
        }
        
        public static bool Adet(int kullanici, int urun, int adet) //Adet Ekle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var bul = db.SanalSepetUye.FirstOrDefault(p => p.UyelerID == kullanici && p.UrunID == urun);
                    bul.Adet = adet;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool Gonder(int KullaniciID) //Sipariş kaydetme
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var bul = db.SanalSepetUye.Where(p => p.UyelerID == KullaniciID).ToList();
                    if (bul.Count != 0)
                    {
                        var liste = bul.Select(p => new UrunSepet
                        {
                            Adedi = p.Adet,
                            UrunID = p.Urun.UrunID
                        }).ToList();

                        db.Sepet.Add(new Sepet()
                        {
                            SiparisTamamlandimi = true,
                            UyelerID = KullaniciID,
                            UrunSepet = liste,
                            Manuel = false,
                            Aktifmi = true
                        });
                        db.SaveChanges();

                        var bulsepet = db.Sepet.FirstOrDefault(p => p.Aktifmi == true);
                        bool sonuc = SiparisRepo.SiparisKaydetUye(bulsepet);
                        if (sonuc == true)
                        {
                            bulsepet.Aktifmi = false;
                        }
                        db.SanalSepetUye.RemoveRange(bul);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool SepettenCikarma(int KullaniciID,int urun) //Sepetten Çıkar
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var sil = db.SanalSepetUye.FirstOrDefault(p => p.UyelerID == KullaniciID && p.UrunID==urun);
                    db.SanalSepetUye.Remove(sil);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}

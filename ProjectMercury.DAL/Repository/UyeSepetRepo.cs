using ProjectMercury.DAL.VMModels;
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
                var urunler =  db.SanalSepetUye.Where(p => p.SanalSepetUyeID == kullanici).Select(p => new VMUrun
                {
                    Image = p.Urun.Image,
                    UrunAdi = p.Urun.UrunAdi,
                    UrunFiyati = p.Urun.IndirimliFiyati,
                    UrunAdedi = db.SanalSepetUye.Where(s => s.UyelerID == kullanici).Sum(m => m.Adet),
                    ToplamFiyat = db.SanalSepetUye.Where(s => s.UyelerID == kullanici).Sum(m => m.Urun.IndirimliFiyati)
                }).ToList();
                var uye = db.Uyeler.FirstOrDefault(p => p.UyelerID == kullanici);
                return new VMSiparisSepeti()
                {
                    Urunler = urunler,
                    Uye = uye
                };
            }
        }
        public static List<VMUrun> SanalSepeteCikar(int kullanici, int urun, int adet) //Sanal sepet
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var bul = db.SanalSepetUye.FirstOrDefault(p => p.UyelerID == kullanici);
                    bul.Adet -= adet;
                    db.SaveChanges();
                    return db.SanalSepetUye.Where(p => p.UyelerID == kullanici).Select(p => new VMUrun
                    {
                        AltKategori = p.Urun.AltKategori.AltKategoriAdi,
                        Kategori = p.Urun.Kategori.KategoriAdi,
                        Marka = p.Urun.Marka.MarkaAdi,
                        UrunAdedi = p.Adet,
                        UrunAdi = p.Urun.UrunAdi,
                        UrunKategori = p.Urun.UrunKategori.UrunKategoriAdi
                    }).ToList();
                }
                catch
                {
                    return db.SanalSepetUye.Where(p => p.UyelerID == kullanici).Select(p => new VMUrun
                    {
                        AltKategori = p.Urun.AltKategori.AltKategoriAdi,
                        Kategori = p.Urun.Kategori.KategoriAdi,
                        Marka = p.Urun.Marka.MarkaAdi,
                        UrunAdedi = p.Adet,
                        UrunAdi = p.Urun.UrunAdi,
                        UrunKategori = p.Urun.UrunKategori.UrunKategoriAdi
                    }).ToList();
                }
            }
        }
        public static bool SepetiKaydetKullanici(int KullaniciID, string UyeID) //Kullanıcı Modunda Manuel Sepeti Ekle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    int uyelerid = int.Parse(UyeID);
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
                            UyelerID = uyelerid,
                            UrunSepet = liste,
                            Manuel = true,
                            Aktifmi = true
                        });
                        db.SaveChanges();

                        var bulsepet = db.Sepet.FirstOrDefault(p => p.Aktifmi == true);
                        bool sonuc = SiparisRepo.SiparisKaydet(bulsepet);
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
        public static bool SepetiSilKullanici(int KullaniciID) //Kullanıcı Modunda Manuel Sepeti Sil
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var sil = db.SanalSepetUye.Where(p => p.UyelerID == KullaniciID).ToList();
                    db.SanalSepetUye.RemoveRange(sil);
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

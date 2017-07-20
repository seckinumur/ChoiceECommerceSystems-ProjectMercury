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
        public static List<VMUrun> SanalSepeteEkle(int kullanici, int urun, int adet) //Sanal sepet
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var bul = db.SanalSepet.FirstOrDefault(p => p.KullanicilarID == kullanici && p.UrunID == urun);
                    bul.Adet += adet;
                    db.SaveChanges();
                    return db.SanalSepet.Where(p => p.KullanicilarID == kullanici).Select(p => new VMUrun
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
                    db.SanalSepet.Add(new SanalSepet()
                    {
                        Adet = adet,
                        KullanicilarID = kullanici,
                        UrunID = urun
                    });
                    db.SaveChanges();
                    return db.SanalSepet.Where(p => p.KullanicilarID == kullanici).Select(p => new VMUrun
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
        public static bool SanalSepetKontrol(int ID) //Sanal sepet
        {
            using (DBCON db = new DBCON())
            {
                bool varmi = db.SanalSepet.Any(p => p.KullanicilarID == ID);
                return varmi;
            }
        }
        public static List<VMUrun> SanalSepeteListe(int kullanici) //Sanal sepet
        {
            using (DBCON db = new DBCON())
            {
                return db.SanalSepet.Where(p => p.KullanicilarID == kullanici).Select(p => new VMUrun
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
        public static List<VMUrun> SanalSepeteCikar(int kullanici, int urun, int adet) //Sanal sepet
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var bul = db.SanalSepet.FirstOrDefault(p => p.KullanicilarID == kullanici);
                    bul.Adet -= adet;
                    db.SaveChanges();
                    return db.SanalSepet.Where(p => p.KullanicilarID == kullanici).Select(p => new VMUrun
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
                    return db.SanalSepet.Where(p => p.KullanicilarID == kullanici).Select(p => new VMUrun
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
                    var bul = db.SanalSepet.Where(p => p.KullanicilarID == KullaniciID).ToList();
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
                        db.SanalSepet.RemoveRange(bul);
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
                    var sil = db.SanalSepet.Where(p => p.KullanicilarID == KullaniciID).ToList();
                    db.SanalSepet.RemoveRange(sil);
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

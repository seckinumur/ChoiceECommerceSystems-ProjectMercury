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
    public class SiparisRepo
    {
        public static bool SiparisKaydet(Sepet Data) //sepet olarak gelen datayı siparişe ekledik
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    db.Siparis.Add(new Siparis()
                    {
                        Gonderildimi = false,
                        Onaylandimi = true,
                        SepetID = Data.SepetID,
                        SiparisTarihi = DateTime.Now.ToShortDateString(),
                        İptal = false
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
        public static bool SiparisKaydetUye(Sepet Data) //sepet olarak gelen datayı siparişe ekledik
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    db.Siparis.Add(new Siparis()
                    {
                        Gonderildimi = false,
                        Onaylandimi = false,
                        SepetID = Data.SepetID,
                        SiparisTarihi = DateTime.Now.ToShortDateString(),
                        İptal = false
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
        public static bool SiparisOnayla(int ID)
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Siparis = db.Siparis.FirstOrDefault(p => p.SiparisID == ID && p.Onaylandimi == false);
                    Siparis.Onaylandimi = true;
                    Siparis.İptal = false;
                    Siparis.Gonderildimi = false;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool SiparisİptalEt(int ID)
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Siparis = db.Siparis.FirstOrDefault(p => p.SiparisID == ID && p.İptal != true);
                    Siparis.Onaylandimi = true;
                    Siparis.İptal = true;
                    Siparis.Gonderildimi = false;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool SiparisİptalEtme(int ID) //iptal siparişi tekrar iptallikten çıkarma
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Siparis = db.Siparis.FirstOrDefault(p => p.SiparisID == ID && p.İptal == true);
                    Siparis.Onaylandimi = true;
                    Siparis.İptal = false;
                    Siparis.Gonderildimi = false;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static void SiparisSil(int ID)
        {
            using (DBCON db = new DBCON())
            {
                var Siparis = db.Siparis.FirstOrDefault(p => p.SiparisID == ID);
                var Sepet = db.Sepet.FirstOrDefault(p => p.SepetID == Siparis.SepetID);
                foreach (var item in Sepet.UrunSepet)
                {
                    var bul = db.UrunSepet.FirstOrDefault(p => p.UrunSepetID == item.UrunSepetID);
                    db.UrunSepet.Remove(bul);
                    db.SaveChanges();
                }
                db.Siparis.Remove(Siparis);
                db.Sepet.Remove(Sepet);
                db.SaveChanges();
            }
        }
        public static bool SiparisGonder(int ID)
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Siparis = db.Siparis.FirstOrDefault(p => p.SiparisID == ID && p.İptal != true && p.Onaylandimi == true);
                    string gun = DateTime.Now.Day.ToString(), ay = DateTime.Now.Month.ToString(), yil = DateTime.Now.Year.ToString();
                    Siparis.Onaylandimi = true;
                    Siparis.İptal = false;
                    Siparis.Gonderildimi = true;
                    Siparis.GonderimTarihi = DateTime.Now.ToShortDateString();
                    foreach (var item in Siparis.Sepet.UrunSepet)
                    {
                        item.Urun.UrunAdedi -= item.Adedi;
                        db.SaveChanges();
                    }
                    foreach (var item in Siparis.Sepet.UrunSepet)
                    {
                        double fiyat = item.Urun.IndirimliFiyati != 0 ? item.Urun.IndirimliFiyati : item.Urun.UrunFiyati, toplam = fiyat * item.Adedi;

                        try
                        {
                            var Bul = db.AylikCiro.FirstOrDefault(p => p.Yil == yil && p.Ay == ay);
                            Bul.ToplamAdet += item.Adedi;
                            Bul.ToplamSatis += fiyat;
                            db.SaveChanges();
                            try
                            {
                                var kontrol = db.GunlukCiro.FirstOrDefault(p => p.Yil == yil && p.Ay == ay && p.Gun == gun);
                                kontrol.ToplamAdet += item.Adedi;
                                kontrol.ToplamSatis += fiyat;
                                db.SaveChanges();
                            }
                            catch
                            {
                                db.GunlukCiro.Add(new GunlukCiro
                                {
                                    Ay = ay,
                                    Gun = gun,
                                    Yil = yil,
                                    ToplamAdet = item.Adedi,
                                    ToplamSatis = fiyat
                                });
                                db.SaveChanges();
                            }
                        }
                        catch
                        {
                            db.AylikCiro.Add(new AylikCiro
                            {
                                Ay = ay,
                                Yil = yil,
                                ToplamAdet = item.Adedi,
                                ToplamSatis = fiyat
                            });
                            db.SaveChanges();

                            db.GunlukCiro.Add(new GunlukCiro
                            {
                                Ay = ay,
                                Gun = gun,
                                Yil = yil,
                                ToplamAdet = item.Adedi,
                                ToplamSatis = fiyat
                            });
                            db.SaveChanges();
                        }
                        try
                        {
                            var al = db.EnCokSatan.FirstOrDefault(p => p.UrunID == item.UrunID);
                            al.Adet += item.Adedi;
                            db.SaveChanges();
                        }
                        catch
                        {
                            db.EnCokSatan.Add(new EnCokSatan
                            {
                                UrunID = item.UrunID,
                                Adet = item.Adedi
                            });
                            db.SaveChanges();
                        }
                    }
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static List<VMSiparis> OnayBEkleyenSiparisler()
        {
            using (DBCON db = new DBCON())
            {
                return db.Siparis.Where(p => p.Onaylandimi == false && p.İptal != true && p.Gonderildimi != true).Select(p => new VMSiparis
                {
                    SepetID = p.SepetID,
                    SiparisID = p.SiparisID,
                    SiparisTarihi = p.SiparisTarihi,
                    Uyeler = db.Uyeler.FirstOrDefault(w => w.UyelerID == p.Sepet.UyelerID)
                }).ToList();
            }
        }
        public static List<VMSiparis> OnaylananSiparisler()
        {
            using (DBCON db = new DBCON())
            {
                return db.Siparis.Where(p => p.Onaylandimi == true && p.İptal != true && p.Gonderildimi != true).Select(p => new VMSiparis
                {
                    SepetID = p.SepetID,
                    SiparisID = p.SiparisID,
                    SiparisTarihi = p.SiparisTarihi,
                    Uyeler = db.Uyeler.FirstOrDefault(w => w.UyelerID == p.Sepet.UyelerID)
                }).ToList();
            }
        }
        public static List<VMSiparis> IptalEdilenSiparisler()
        {
            using (DBCON db = new DBCON())
            {
                return db.Siparis.Where(p => p.İptal == true && p.Gonderildimi != true).Select(p => new VMSiparis
                {
                    SepetID = p.SepetID,
                    SiparisID = p.SiparisID,
                    SiparisTarihi = p.SiparisTarihi,
                    Uyeler = db.Uyeler.FirstOrDefault(w => w.UyelerID == p.Sepet.UyelerID)
                }).ToList();
            }
        }
        public static List<VMSiparis> GonderilenSiparisler()
        {
            using (DBCON db = new DBCON())
            {
                return db.Siparis.Where(p => p.Gonderildimi == true && p.İptal != true).Select(p => new VMSiparis
                {
                    SepetID = p.SepetID,
                    GonderimTarihi = p.GonderimTarihi,
                    SiparisID = p.SiparisID,
                    SiparisTarihi = p.SiparisTarihi,
                    Uyeler = db.Uyeler.FirstOrDefault(w => w.UyelerID == p.Sepet.UyelerID)
                }).ToList();
            }
        }
        public static List<VMSiparis> GonderilmeyenSiparisler()
        {
            using (DBCON db = new DBCON())
            {
                return db.Siparis.Where(p => p.Gonderildimi == false && p.İptal != true && p.Onaylandimi == true).Select(p => new VMSiparis
                {
                    SepetID = p.SepetID,
                    SiparisID = p.SiparisID,
                    SiparisTarihi = p.SiparisTarihi,
                    Uyeler = db.Uyeler.FirstOrDefault(w => w.UyelerID == p.Sepet.UyelerID)
                }).ToList();
            }
        }
        public static List<VMSiparis> UyeSiparisleri(int ID)
        {
            using (DBCON db = new DBCON())
            {
                return db.Siparis.Where(p => p.Sepet.UyelerID == ID).Select(p => new VMSiparis
                {
                    SepetID = p.SepetID,
                    Gonderildimi = p.Gonderildimi,
                    Onaylandimi = p.Onaylandimi,
                    İptal = p.İptal,
                    GonderimTarihi = p.GonderimTarihi,
                    SiparisID = p.SiparisID,
                    SiparisTarihi = p.SiparisTarihi,
                    Uyeler = db.Uyeler.FirstOrDefault(w => w.UyelerID == p.Sepet.UyelerID)
                }).ToList();
            }
        }
        public static List<VMSiparis> UyeSiparisListele(string id)
        {
            using (DBCON db = new DBCON())
            {
                int ID = int.Parse(id);

                return db.Siparis.Where(p => p.Sepet.UyelerID == ID).Select(p => new VMSiparis
                {
                    SepetID = p.SepetID,
                    GonderimTarihi = p.GonderimTarihi,
                    Durum = p.Gonderildimi == false  ? "label label-danger" : "label label-primary",
                    Sonuc = p.Gonderildimi == false ? "Sipariş Hazırlanıyor" : "Sipariş Gönderildi",
                    SiparisID = p.SiparisID,
                    Gonderildimi=p.Gonderildimi,
                    SiparisTarihi = p.SiparisTarihi,
                    ToplamAdet= p.Sepet.UrunSepet.Sum(n=> n.Adedi),
                    ToplamFiyat = p.Sepet.UrunSepet.Sum(n => (n.Urun.IndirimliFiyati ==0 ? n.Urun.UrunFiyati : n.Urun.IndirimliFiyati)*n.Adedi),
                    Uyeler = db.Uyeler.FirstOrDefault(w => w.UyelerID == p.Sepet.UyelerID)
                }).ToList();
            }
        }
        public static List<VMSiparisUrun> UrunSepeti(int ID)
        {
            using (DBCON db = new DBCON())
            {
                List<VMSiparisUrun> liste = new List<VMSiparisUrun>();
                var ayir = db.Siparis.FirstOrDefault(p => p.SiparisID == ID);
                foreach (var item in ayir.Sepet.UrunSepet)
                {
                    liste.Add(new VMSiparisUrun
                    {
                        AltKategori = item.Urun.AltKategori.AltKategoriAdi,
                        Kategori = item.Urun.Kategori.KategoriAdi,
                        Marka = item.Urun.Marka.MarkaAdi,
                        UrunAdedi = item.Adedi,
                        UrunAdi = item.Urun.UrunAdi,
                        UrunKategori = item.Urun.UrunKategori.UrunKategoriAdi
                    });
                }
                return liste;
            }
        }
        public static List<VMSiparisUrun> UrunSepetiKullanici(int ID)
        {
            using (DBCON db = new DBCON())
            {
                List<VMSiparisUrun> liste = new List<VMSiparisUrun>();
                var ayir = db.Siparis.FirstOrDefault(p => p.SiparisID == ID);
                foreach (var item in ayir.Sepet.UrunSepet)
                {
                    liste.Add(new VMSiparisUrun
                    {
                        AltKategori = item.Urun.AltKategori.AltKategoriAdi,
                        Kategori = item.Urun.Kategori.KategoriAdi,
                        Marka = item.Urun.Marka.MarkaAdi,
                        UrunAdedi = item.Adedi,
                        UrunAdi = item.Urun.UrunAdi,
                        UrunKategori = item.Urun.UrunKategori.UrunKategoriAdi
                    });
                }
                return liste;
            }
        }
    }
}


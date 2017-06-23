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
        public static bool SiparisOnayla(int ID)
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Siparis = db.Siparis.FirstOrDefault(p => p.SiparisID == ID && p.Onaylandimi == false);
                    Siparis.Onaylandimi = true;
                    foreach (var item in Siparis.Sepet.UrunSepet)
                    {
                        var bul = db.Satis.FirstOrDefault(p => p.UrunID == item.UrunID);
                        if (bul != null)
                        {
                            bul.SatisAdedi = bul.SatisAdedi++;
                            db.SaveChanges();
                        }
                        else
                        {
                            db.Satis.Add(new Satis()
                            {
                                SatisAdedi = 1,
                                UrunID = item.UrunID
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
        public static bool SiparisİptalEt(int ID)
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Siparis = db.Siparis.FirstOrDefault(p => p.SiparisID == ID && p.İptal != true);
                    Siparis.Onaylandimi = false;
                    Siparis.İptal = true;
                    foreach (var item in Siparis.Sepet.UrunSepet)
                    {
                        var bul = db.Satis.FirstOrDefault(p => p.UrunID == item.UrunID);
                        bul.SatisAdedi = bul.SatisAdedi--;
                        db.SaveChanges();
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
        public static bool SiparisİptalEtme(int ID)
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Siparis = db.Siparis.FirstOrDefault(p => p.SiparisID == ID && p.İptal != true);
                    Siparis.Onaylandimi = false;
                    Siparis.İptal = false;
                    foreach (var item in Siparis.Sepet.UrunSepet)
                    {
                        var bul = db.Satis.FirstOrDefault(p => p.UrunID == item.UrunID);
                        bul.SatisAdedi = bul.SatisAdedi++;
                        db.SaveChanges();
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
                    Siparis.Gonderildimi = true;
                    Siparis.GonderimTarihi = DateTime.Now.ToShortDateString();
                    foreach (var item in Siparis.Sepet.UrunSepet)
                    {
                        item.Urun.UrunAdedi -= item.Adedi;
                        db.SaveChanges();
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
                return db.Siparis.Where(p => p.Onaylandimi == false).Select(p => new VMSiparis
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
                return db.Siparis.Where(p => p.Onaylandimi == true).Select(p => new VMSiparis
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
                return db.Siparis.Where(p => p.İptal == true).Select(p => new VMSiparis
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
                return db.Siparis.Where(p => p.Gonderildimi == true).Select(p => new VMSiparis
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
                return db.Siparis.Where(p => p.Gonderildimi == false).Select(p => new VMSiparis
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
    }
}


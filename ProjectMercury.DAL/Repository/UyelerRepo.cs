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
    public class UyelerRepo
    {
        public static bool UyeKaydet(VMUyeler Al) //Üye Kaydet
        {
            using (DBCON db = new DBCON())
            {
                int? No = db.Uyeler.OrderByDescending(p => p.UyeNo).FirstOrDefault().UyeNo + 1; // bu yapıyı kontrol et
                bool Control = db.Uyeler.Any(p => p.KullaniciAdi == Al.KullaniciAdi && p.Sifre == Al.Sifre && p.UyeNo == Al.UyeNo);
                if (Control != true)
                {
                    db.Uyeler.Add(new Uyeler()
                    {
                        Adres = Al.Adres,
                        Banlimi = Al.Banlimi,
                        KullaniciAdi = Al.KullaniciAdi,
                        MailAdresi = Al.MailAdresi,
                        UyeAdiSoyadi = Al.UyeAdiSoyadi,
                        Sifre = Al.Sifre,
                        Tarih = Al.Tarih,
                        Telefon = Al.Telefon,
                        UyeNo = int.Parse(No.ToString())
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool UyeGuncelle(VMUyeler Al) //Üye Guncelle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Uyeler.FirstOrDefault(p => p.UyelerID == Al.UyelerID);

                    Bul.Adres = Al.Adres;
                    Bul.Banlimi = Al.Banlimi;
                    Bul.KullaniciAdi = Al.KullaniciAdi;
                    Bul.MailAdresi = Al.MailAdresi;
                    Bul.UyeAdiSoyadi = Al.UyeAdiSoyadi;
                    Bul.Sifre = Al.Sifre;
                    Bul.Telefon = Al.Telefon;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static void UyeSil(string ID) //Üye Sil
        {
            using (DBCON db = new DBCON())
            {
                int id = int.Parse(ID);
                var Bul = db.Uyeler.FirstOrDefault(p => p.UyelerID == id);
                db.Uyeler.Remove(Bul);
                db.SaveChanges();
            }
        }
       
        public static VMUyeler UyeListele(string ID) //Üye Bul
        {
            int id = int.Parse(ID);
            using (DBCON db = new DBCON())
            {
                return db.Uyeler.Where(p=> p.UyelerID==id).Select(p => new VMUyeler
                {
                    Adres = p.Adres,
                    Banlimi = p.Banlimi,
                    KullaniciAdi = p.KullaniciAdi,
                    MailAdresi = p.MailAdresi,
                    UyeAdiSoyadi = p.UyeAdiSoyadi,
                    Sifre = p.Sifre,
                    Tarih = p.Tarih,
                    Telefon = p.Telefon,
                    UyelerID = p.UyelerID,
                    UyeNo = p.UyeNo
                }).FirstOrDefault();
            }
        }
    }
}

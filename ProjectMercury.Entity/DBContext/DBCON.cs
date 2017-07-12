namespace ProjectMercury.Entity.DBContext
{
    using ProjectMercury.Entity.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBCON : DbContext
    {
        public DBCON()
            : base("name=DBCON")
        {
            Database.SetInitializer(new DBCONInitializer()); // Bu Kod Otomatik database Olu�turma Otomasyonu
        }
        public virtual DbSet<AltKategori> AltKategori { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
        public virtual DbSet<Sepet> Sepet { get; set; }
        public virtual DbSet<Siparis> Siparis { get; set; }
        public virtual DbSet<SiteBilgileri> SiteBilgileri { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<UrunKategori> UrunKategori { get; set; }
        public virtual DbSet<Uyeler> Uyeler { get; set; }
        public virtual DbSet<Satis> Satis { get; set; }
        public virtual DbSet<UrunSepet> UrunSepet { get; set; }
        public virtual DbSet<SanalSepet> SanalSepet { get; set; }
    }
    public class DBCONInitializer : CreateDatabaseIfNotExists<DBCON> //Otomatik database Olu�turma
    {
        protected override void Seed(DBCON db)
        {
            db.Kategori.Add(new Kategori
            {
                KategoriAdi = "KPSS Kitaplar�"
            });
            db.SaveChanges();

            db.AltKategori.Add(new AltKategori
            {
                AltKategoriAdi = "KPSS E�itim Bilimleri",
                KategoriID= 1
            });
            db.SaveChanges();

            db.UrunKategori.Add(new UrunKategori
            {
                UrunKategoriAdi = "�r�n Kategori Yok"
            });
            db.SaveChanges();

            db.UrunKategori.Add(new UrunKategori
            {
                UrunKategoriAdi = "KPSS Konu Anlat�m�"
            });
            db.SaveChanges();

            db.Marka.Add(new Marka
            {
                MarkaAdi= "Lider Yay�nlar�"
            });
            db.SaveChanges();

            db.Urun.Add(new Urun
            {
                AltKategoriID = 1,
                IndirimliFiyati = "35,70",
                IndirimVarmi = true,
                KategoriID = 1,
                MarkaID=1,
                UrunAciklama="Program Geli�tirme, ��renme Psikolojisi, Geli�im psikiolojisi, Rehberlik Ve �zel E�itim, ��retim Y�ntem Ve Teknikleri, �l�me Ve De�erlendirme.",
                UrunAdedi=1,
                UrunAdi="Murat Yay�nlar� KPSS E�itim Bilimleri Konu Anlat�ml� Mod�ler Set(2017)",
                UrunFiyati="59,50",
                Yorum="1456 Sayfa 19.50 x 27.50 cm 1.Hamur Ka��t Po�et Ambalaj",
                UrunKategoriID=2,
                Image= "/images/ImageStore/Demo.JPG"
            });
            db.SaveChanges();

            db.Kullanicilar.Add(new Kullanicilar
            {
                KullaniciAdi="admin",
                KullaniciSifre="9916",
                Master=true,
                System=true
            });
            db.SaveChanges();
            db.Kullanicilar.Add(new Kullanicilar
            {
                KullaniciAdi = "demo",
                KullaniciSifre = "1234",
                Master = true,
                System = false
            });
            db.SaveChanges();
            db.Uyeler.Add(new Uyeler
            {
                Sifre = "1234",
                Adres="demo adres",
                Banlimi=false,
                MailAdresi="seckinumur@gmail.com",
                Tarih=DateTime.Now.ToShortDateString(),
                Telefon="05423428009",
                UyeAdiSoyadi="demo demo"
            });
            db.SaveChanges();

            db.SiteBilgileri.Add(new SiteBilgileri()
            {
                Adres = "Kar��yaka/�ZM�R",
                Facebook= "https://www.facebook.com/seckinumur85",
                Instagram="#",
                Telefon="#",
                MailAdresi= "mailto:seckinumur@gmail.com",
                MobilTelefon= "tel:+905423428009",
                SiteAdi= "Choice Admin Control Systems V.1.5",
                Twitter= "https://twitter.com/SeckinUmur",
                Whatsapp="+905423428009",
                Logo= "/images/Company/projectmercury.PNG"
            });
            db.SaveChanges();

            db.Slider.Add(new Slider()
            {
                Image = "/images/Company/Slider/Slider1.JPG"
            });
            db.SaveChanges();
        }
    }
}
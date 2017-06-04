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
            Database.SetInitializer(new DBCONInitializer()); // Bu Kod Otomatik database Oluþturma Otomasyonu
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
    }
    public class DBCONInitializer : CreateDatabaseIfNotExists<DBCON> //Otomatik database Oluþturma
    {
        protected override void Seed(DBCON db)
        {
            db.UrunKategori.Add(new UrunKategori
            {
                UrunKategoriAdi = "KPSS Konu Anlatýmý"
            });
            db.SaveChanges();

            db.AltKategori.Add(new AltKategori
            {
                AltKategoriAdi = "KPSS Eðitim Bilimleri",
                Urunkategori = db.UrunKategori.Where(p=> p.UrunKategoriID==1).ToList()
            });
            db.SaveChanges();
            db.Kategori.Add(new Kategori
            {
                KategoriAdi = "KPSS Kitaplarý",
                Altkategori = db.AltKategori.Where(p => p.AltKategoriID == 1).ToList()
            });
            db.SaveChanges();
            db.Marka.Add(new Marka
            {
                MarkaAdi= "Lider Yayýnlarý"
            });
            db.SaveChanges();
            db.Urun.Add(new Urun
            {
                AltKategoriID = 1,
                IndirimliFiyati = "35,70",
                IndirimVarmi = true,
                KategoriID = 1,
                MarkaID=1,
                UrunAciklama="Program Geliþtirme, Öðrenme Psikolojisi, Geliþim psikiolojisi, Rehberlik Ve Özel Eðitim, Öðretim Yöntem Ve Teknikleri, Ölçme Ve Deðerlendirme.",
                UrunAdedi=1,
                UrunAdi="Murat Yayýnlarý KPSS Eðitim Bilimleri Konu Anlatýmlý Modüler Set(2017)",
                UrunFiyati="59,50",
                Yorum="1456 Sayfa 19.50 x 27.50 cm 1.Hamur Kaðýt Poþet Ambalaj",
                UrunKategoriID=1
            });
            db.SaveChanges();
            db.Kullanicilar.Add(new Kullanicilar
            {
                KullaniciAdi="Admin",
                KullaniciSifre="9916",
                Master=true,
                System=true
            });
            db.SaveChanges();
        }
    }
}
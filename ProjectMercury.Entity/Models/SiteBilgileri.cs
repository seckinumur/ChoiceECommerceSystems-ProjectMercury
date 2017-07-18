using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.Entity.Models
{
   public class SiteBilgileri
    {
        public int SiteBilgileriID { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string MobilTelefon { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        public string Instagram { get; set; }
        public string Logo { get; set; }
        public string SiteAdi { get; set; }
        public string MailAdresi { get; set; }
        public string Hakkinda { get; set; }
    }
}

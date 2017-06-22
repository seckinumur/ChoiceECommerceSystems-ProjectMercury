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
    public class ViewRepo
    {
        public static UrunAI VievIndexAI() // VievIndexAI Yapay Zeka Algoritması
        {
            using (DBCON db = new DBCON())
            {
                UrunAI Liste = new UrunAI();
                Random rnd = new Random();
                var urunlistesi = db.Urun.OrderByDescending(p => p.UrunID).ToList();
                var indirimliUrun = db.Urun.Where(p => p.IndirimVarmi == true).ToList();
                
                if (urunlistesi.Count != 5)
                {
                    Liste.EnYeni.AddRange(urunlistesi.Take(urunlistesi.Count));
                    Liste.EnCokSatan.AddRange(db.Satis.OrderBy(p => p.SatisAdedi).Select(P => P.Urun).Take(urunlistesi.Count).ToList());
                    for (int i = 0; i < urunlistesi.Count; i++){Liste.GununFirsati.Add(indirimliUrun[rnd.Next(0, indirimliUrun.Count)]);}
                }
                else
                {
                    Liste.EnYeni.AddRange(urunlistesi.Take(5));
                    Liste.EnCokSatan.AddRange(db.Satis.OrderBy(p => p.SatisAdedi).Select(P => P.Urun).Take(5).ToList());
                    for (int i = 0; i < 5; i++){Liste.GununFirsati.Add(indirimliUrun[rnd.Next(0, indirimliUrun.Count)]); }
                }
                return Liste;
            }
        }
    }
}

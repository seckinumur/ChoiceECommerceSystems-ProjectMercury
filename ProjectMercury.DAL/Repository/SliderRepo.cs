using ProjectMercury.Entity.DBContext;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.Repository
{
   public class SliderRepo
    {
        public static List<Slider> SliderList() //Ayarları Listele
        {
            using (DBCON db = new DBCON())
            {
                return db.Slider.ToList();
            }
        }
        public static bool SliderDuzenle(int id,string link) //ekle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var slider = db.Slider.FirstOrDefault(p => p.SliderID == id);
                    slider.Image = link;
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

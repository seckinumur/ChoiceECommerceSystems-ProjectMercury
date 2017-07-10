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
    }
}

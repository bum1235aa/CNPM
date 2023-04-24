using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class HoaDonController
    {
        public HoaDonService hd = new HoaDonService();

        public List<HoaDon> GetAllHoaDons()
        {
            return hd.GetAllHoaDon();
        }

        public List<ChiTiet> GetChiTiets(int id)
        {
            return hd.GetChiTiets(id);
        }
    }
}

using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class KhachHangController
    {
        public KhachHangServices kh = new KhachHangServices();

        public List<KhachHang> GetAllKhachHang()
        {
            return kh.GetAllKhachHang();
        }
        public int GetMaxID()
        {
            return kh.GetMaxID();  
        }
    }
}

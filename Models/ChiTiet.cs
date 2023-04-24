using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ChiTiet
    {
        public int id {  get; set; }
        public int sanPhamId { get; set; }
        public int soLuong { get; set; }
        public int gia { get; set; }
        public int donHangId { get; set; }
    }
}

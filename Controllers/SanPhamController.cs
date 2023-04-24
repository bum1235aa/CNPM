using Services;
using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class SanPhamController
    {
        public SanPhamServices sp = new SanPhamServices();

        public List<SanPham> GetAllSanPham()
        {
            return sp.GetAllProduct();
        }

        public void AddSanPham(int id,string name,string decs,int price,int quantity)
        {
            SanPham sanPham = new SanPham();
            sanPham.id = id;
            sanPham.name = name;
            sanPham.description = decs;
            sanPham.price = price;
            sanPham.quantity = quantity;

            sp.AddSanPham(sanPham);
        }
        public void UpdateSanPham(int id, string name, string decs, int price, int quantity)
        {
            SanPham sanPham = new SanPham();
            sanPham.id = id;
            sanPham.name = name;
            sanPham.description = decs;
            sanPham.price = price;
            sanPham.quantity = quantity;

            sp.UpdateSanPham(sanPham);
        }

        public void DeleteSanPham(int id)
        {
            sp.DeleteSanPham(id);
        }
        public int GetMaxId()
        {
            return sp.GetMaxId();
        }
    }
}
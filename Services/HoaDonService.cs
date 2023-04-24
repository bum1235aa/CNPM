using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HoaDonService
    {
        SqlConnection conn;
        List<HoaDon> list;

        public List<HoaDon> GetAllHoaDon()
        {
            using(conn = new SqlConnection(Connection.GetConnectionString()))
            {
                list = new List<HoaDon>();
                string query = "SELECT * FROM don_hang";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon = new HoaDon();
                    hoaDon.id = (int)reader["id"];
                    hoaDon.date = DateTime.Parse(reader["ngay_dat"].ToString());
                    
                    hoaDon.state = (string)reader["trang_thai"];
                    hoaDon.khachHangId = (int)reader["khach_hang_id"];

                    list.Add(hoaDon);
                    
                }
            }

            return list;
        }

        public List<ChiTiet> GetChiTiets(int id)
        {
            List<ChiTiet> list =new List<ChiTiet>();

            using (conn = new SqlConnection(Connection.GetConnectionString()))
            {
                string query = "SELECT * FROM chi_tiet_don_hang WHERE don_hang_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTiet chiTiet = new ChiTiet();
                    chiTiet.id = (int)reader["id"];
                    chiTiet.sanPhamId = (int)reader["san_pham_id"];
                    chiTiet.soLuong = (int)reader["so_luong"];
                    chiTiet.gia = (int)reader["gia"];
                    chiTiet.donHangId = (int)reader["don_hang_id"];

                    list.Add(chiTiet);
                } 

            }
            return list;
        }

    }
}

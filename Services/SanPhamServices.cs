using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    
    public class SanPhamServices
    {
        List<SanPham> ls;
        int maxid;
        SqlConnection conn;


        public List<SanPham> GetAllProduct()
        {
            ls = new List<SanPham>();
            using (conn = new SqlConnection(Connection.GetConnectionString()))
            {
                string query = "SELECT * FROM san_pham";
                SqlCommand cmd = new SqlCommand(query,conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SanPham sp = new SanPham();
                    sp.id = (int)reader["id"];
                    sp.name = (string)reader["ten_san_pham"].ToString();
                    sp.description = (string)reader["mo_ta"].ToString();
                    sp.price = (int)reader["gia"];
                    sp.quantity = (int)reader["so_luong_ton_kho"];

                    ls.Add(sp);
                    maxid = sp.id + 1;
                }
                reader.Close();
            }
            return ls;
        }

        public void AddSanPham(SanPham sanPham)
        {
            using (conn = new SqlConnection(Connection.GetConnectionString()))
            {
                string query = "INSERT INTO san_pham (id, ten_san_pham, mo_ta, gia, so_luong_ton_kho) " +
                    "VALUES (@id, @name, @decs, @price, @quantity)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", sanPham.id);
                command.Parameters.AddWithValue("@name", sanPham.name);
                command.Parameters.AddWithValue("@decs", sanPham.description);
                command.Parameters.AddWithValue("@price", sanPham.price);
                command.Parameters.AddWithValue("@quantity", sanPham.quantity);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateSanPham(SanPham sanPham)
        {
            using (conn = new SqlConnection(Connection.GetConnectionString()))
            {
                string query = "UPDATE san_pham SET ten_san_pham = @name, mo_ta = @decs, " +
                    "gia = @price, so_luong_ton_kho = @quantity " +
                    "WHERE id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", sanPham.id);
                command.Parameters.AddWithValue("@name", sanPham.name);
                command.Parameters.AddWithValue("@decs", sanPham.description);
                command.Parameters.AddWithValue("@price", sanPham.price);
                command.Parameters.AddWithValue("@quantity", sanPham.quantity);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteSanPham(int id)
        {
            using(conn = new SqlConnection(Connection.GetConnectionString()))
            {
                string query = "DELETE FROM san_pham WHERE id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }
        public int GetMaxId()
        {
            return maxid;
        }
    }
}

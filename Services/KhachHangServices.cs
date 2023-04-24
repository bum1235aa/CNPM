using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class KhachHangServices
    {
        List<KhachHang> ls;
        int maxId;
        SqlConnection conn;

        public KhachHangServices()
        {
            conn = new SqlConnection(Connection.GetConnectionString());
        }

        public List<KhachHang> GetAllKhachHang()
        {
            ls = new List<KhachHang>();
            using (conn)
            {
                string query = "SELECT * FROM khach_hang";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KhachHang kh = new KhachHang();
                    kh.id = (int)reader["id"];
                    kh.name = (string)reader["ho_ten"];
                    kh.adress = (string)reader["dia_chi"];
                    kh.email = (string)reader["email"];
                    kh.phone = (string)reader["so_dien_thoai"];
                    ls.Add(kh);
                    maxId = kh.id + 1 ;
                }
                    
            }

            return ls;
        }

        public int GetMaxID()
        {
            return maxId;
        }

    }
}

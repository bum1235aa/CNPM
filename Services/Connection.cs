using System;
using System.Data.SqlClient;
namespace Services
{
    public class Connection
    {
        public SqlConnection conn;
        
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder;

            builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            builder["Data Source"] = "LAPTOP-ORFGSI1N";
            builder["integrated Security"] = true;
            builder["Initial Catalog"] = "Medic";
            builder.UserID = "LAPTOP-ORFGSI1N\\ADMIN";
            Console.WriteLine(builder.ConnectionString);
            builder["Password"] = "";
            Console.Write(builder.ConnectionString);
            return builder.ConnectionString;
        }

        public Connection()
        {
            conn = new SqlConnection(GetConnectionString());
        }
    }
}
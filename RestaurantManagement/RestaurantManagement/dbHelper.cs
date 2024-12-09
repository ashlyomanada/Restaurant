using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RestaurantManagement
{


    public static class DbHelper
    {
        // Method to get the connection string
        public static string GetConnectionString()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ashly Omanada\source\repos\RestaurantManagement\RestaurantManagement\Database.mdf;Integrated Security=True;MultipleActiveResultSets=True";
        }


        // Method to create and return a new SqlConnection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public static DataTable ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table); // Fill the DataTable with query results
                            return table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Optionally log or handle the exception
                throw new Exception("Error executing query: " + ex.Message);
            }
        }

        public static DataTable ExecuteQueryWithReader(string query)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }




    }




    internal class dbHelper
    {
    }
}

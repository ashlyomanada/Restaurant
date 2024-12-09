using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantManagement
{

      class CategoriesData
      {


        public int ID { set; get; }
        public string Category { set; get; }
        public string Date { set; get; }

        public List<CategoriesData> AllCategoriesData()
        {
            List<CategoriesData> listData = new List<CategoriesData>();

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ROBEL MANALON\OneDrive\Documents\RMS.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            try
            {
                using (SqlConnection connectState = new SqlConnection(connectionString))
                {
                    connectState.Open();

                    string selectData = "SELECT id, Category, date FROM Categories";

                    using (SqlCommand cmd = new SqlCommand(selectData, connectState))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CategoriesData cData = new CategoriesData
                                {
                                    // Safely cast values with type-checking
                                    ID = reader["id"] is DBNull ? 0 : Convert.ToInt32(reader["id"]),
                                    Category = reader["Category"] is DBNull ? string.Empty : reader["Category"].ToString(),
                                    Date = reader["date"] is DBNull ? string.Empty : reader["date"].ToString()
                                };

                                listData.Add(cData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (or rethrow if required)
                Console.WriteLine($"Error retrieving categories: {ex.Message}");
            }

            return listData;
        }

    }
}

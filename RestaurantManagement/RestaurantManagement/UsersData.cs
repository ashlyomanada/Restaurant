using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web.Caching;

namespace RestaurantManagement
{
    internal class UsersData
    {
    

        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public string date {  get; set; }

        public List<UsersData> AllUsersData() 
        {
            List<UsersData> listData = new List<UsersData>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ROBEL MANALON\OneDrive\Documents\RMS.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False"))
            {
                connect.Open();

                string selectData = "SELECT * FROM users";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UsersData uData = new UsersData();
                        uData.ID = (int)reader["ID"];
                        uData.username = reader["username"].ToString();
                        uData.password = reader["password"].ToString();
                        uData.role = reader["role"].ToString();
                        uData.status = reader["status"].ToString();

                        listData.Add(uData);
                    }
                }

               
            }

            return listData;
        }

     
    }
}

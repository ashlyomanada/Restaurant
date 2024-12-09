using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using connectState;

namespace RestaurantManagement
{
    public partial class AdminDashboard : UserControl
    {
        private SqlConnection connect;
        public AdminDashboard()
        {
            connect = DbHelper.GetConnection();
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
         
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadTodaysCustomers();
            try
            {
                connect.Open();

                // SQL query to count all users in the 'Users' table
                string countQuery = "SELECT COUNT(*) FROM Users";  // Replace 'Users' with your actual table name
                using (SqlCommand countCmd = new SqlCommand(countQuery, connect))
                {
                    // Execute the query and retrieve the count
                    int userCount = Convert.ToInt32(countCmd.ExecuteScalar());
                    label10.Text = userCount.ToString();  // Display user count
                }

                // Query to get all distinct customers based on orders
                string customerQuery = @"
                SELECT COUNT(DISTINCT UserId) FROM Orders";
                using (SqlCommand customerCmd = new SqlCommand(customerQuery, connect))
                {
                    // Execute the query and retrieve the count of distinct customers
                    int customerCount = Convert.ToInt32(customerCmd.ExecuteScalar());
                    lblAllCustomer.Text = customerCount.ToString();  // Display customer count
                }

                // Query to get today's income (using Quantity and price)
                string todayIncomeQuery = @"
                SELECT SUM(o.Quantity * f.price) 
                FROM Orders o
                INNER JOIN Food f ON o.FoodId = f.Id
                WHERE CONVERT(DATE, o.OrderDate) = CONVERT(DATE, GETDATE())";
                using (SqlCommand todayIncomeCmd = new SqlCommand(todayIncomeQuery, connect))
                {
                    // Execute the query and retrieve today's income
                    decimal todayIncome = Convert.ToDecimal(todayIncomeCmd.ExecuteScalar());
                    lblTodayIncome.Text = "₱" + todayIncome.ToString("N2");  // Display today's income (formatted as currency)
                }

                // Query to get total income (using Quantity and price)
                string totalIncomeQuery = @"
                SELECT SUM(o.Quantity * f.price) 
                FROM Orders o
                INNER JOIN Food f ON o.FoodId = f.Id";
                using (SqlCommand totalIncomeCmd = new SqlCommand(totalIncomeQuery, connect))
                {
                    // Execute the query and retrieve the total income
                    decimal totalIncome = Convert.ToDecimal(totalIncomeCmd.ExecuteScalar());
                    lblTotalIncome.Text = "₱" + totalIncome.ToString("N2");  // Display total income (formatted as currency)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }


        }
        public void LoadTodaysCustomers()
        {
            try
            {
                // SQL query to get today's customers
                string query = @"
                SELECT DISTINCT u.Id AS UserId, u.username AS UserName
                FROM Orders o
                INNER JOIN Users u ON o.UserId = u.Id
                WHERE CONVERT(DATE, o.OrderDate) = CONVERT(DATE, GETDATE())";

                // Open the connection
                connect.Open();

                // Execute the query and load data into DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Set the data source of DataGridView
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.DataSource = dataTable;

                //// Optionally, you can adjust column headers to be more user-friendly
                //dataGridView1.Columns["UserId"].HeaderText = "Customer ID";
                //dataGridView1.Columns["UserName"].HeaderText = "Customer Name";
                //dataGridView1.Columns["UserEmail"].HeaderText = "Customer Email";

                // Optionally adjust the DataGridView width to fill the screen
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show($"Error displaying today's customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed after the operation
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }


        private void Dashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadTodaysCustomers();
        }
    }
}

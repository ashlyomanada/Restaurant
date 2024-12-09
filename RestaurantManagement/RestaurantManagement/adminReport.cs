using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class adminReport : Form
    {
        private SqlConnection connect; 
        public adminReport()
        {
            InitializeComponent();
            connect = DbHelper.GetConnection();
        }

        public void loadDailySales()
        {
            try
            {
                // Query to fetch daily sales data for all dates
                string query = @"
            SELECT 
                CONVERT(DATE, o.OrderDate) AS OrderDate,   -- Group by day (removes time part)
                SUM(o.Quantity) AS TotalQuantitySold,      -- Total quantity sold per day
                SUM(o.Quantity * f.price) AS TotalSales,   -- Total sales revenue per day
                COUNT(o.OrderId) AS TotalOrders            -- Total number of orders per day
            FROM Orders o
            INNER JOIN Food f ON o.FoodId = f.Id
            INNER JOIN Categories c ON f.category_id = c.Id
            GROUP BY CONVERT(DATE, o.OrderDate)          -- Group by date (removes time part)
            ORDER BY OrderDate DESC;                     -- Orders by most recent date
        ";

                // Open the connection
                connect.Open();

                // Execute the query and load data into DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Format the DataGridView and load data
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show($"Error displaying Sales Report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public void loadMonthlySales()
        {
            try
            {
                // Query to fetch monthly sales data for all months
                string query = @"
            SELECT 
                YEAR(o.OrderDate) AS OrderYear, 
                 DATENAME(MONTH, o.OrderDate) AS OrderMonth,
                SUM(o.Quantity) AS TotalQuantitySold, 
                SUM(o.Quantity * f.price) AS TotalSales, 
                COUNT(o.OrderId) AS TotalOrders
            FROM Orders o
            INNER JOIN Food f ON o.FoodId = f.Id
            INNER JOIN Categories c ON f.category_id = c.Id
            GROUP BY YEAR(o.OrderDate), DATENAME(MONTH, o.OrderDate)
            ORDER BY OrderYear DESC, OrderMonth DESC;
        ";

                // Open the connection
                connect.Open();

                // Execute the query and load data into DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Format the DataGridView and load data
                dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView2.DataSource = dataTable;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show($"Error displaying Sales Report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        // Handle the click event on the DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadDailySales();
        }

        private void adminReport_Load_1(object sender, EventArgs e)
        {
            loadDailySales();
            loadMonthlySales();
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            loadDailySales();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadMonthlySales();
        }
    }
}

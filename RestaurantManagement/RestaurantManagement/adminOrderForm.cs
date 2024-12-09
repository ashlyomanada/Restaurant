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
    public partial class adminOrderForm : Form
    {
        private SqlConnection connect;
        public adminOrderForm()
        {
            connect = DbHelper.GetConnection();
            InitializeComponent();
        }
        public void loadData()
        {
            try
            {
                // SQL query with JOIN to get username and foodname
                string query = @"
            SELECT 
                o.OrderId,
                o.OrderDate,
                u.username AS CustomerName,      -- Display username
                f.foodname AS FoodName,          -- Display foodname
                o.Quantity,
                (o.Quantity * f.price) AS TotalAmount
            FROM 
                Orders o
            INNER JOIN 
                Users u ON o.UserId = u.Id      -- Join Users table to get username
            INNER JOIN 
                Food f ON o.FoodId = f.Id       -- Join Food table to get foodname";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Set the DataGridView's data source
                dataGridView1.DataSource = dataTable;

                // Optional: Change font color for the DataGridView
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadData();
        }

        private void adminOrderForm_Load(object sender, EventArgs e)
        {
            loadData();
            label1.ForeColor = Color.Black;
        }
    }
}

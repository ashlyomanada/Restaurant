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
    public partial class StatusForm : Form
    {
        private SqlConnection connect;

        public StatusForm()
        {
            connect = DbHelper.GetConnection();
            InitializeComponent();
        }

        private void StatusForm_Load(object sender, EventArgs e)
        {
            LoadAppetizerData();
        }

        private void LoadAppetizerData()
        {
            try
            {
                // Define your SQL query
                string query = "SELECT * FROM Orders"; // Replace with your actual table name

                // Fetch data using DbHelper
                DataTable table = DbHelper.ExecuteQuery(query);

                // Bind the DataTable to the DataGridView
                appetizerGridView.DataSource = table;

                // Optional: Adjust the DataGridView appearance
                //appetizerGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //appetizerGridView.ReadOnly = true;
                //appetizerGridView.RowHeadersVisible = false;

                appetizerGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                appetizerGridView.RowHeadersVisible = true;
                appetizerGridView.ReadOnly = false;  // Allow selecting and clicking
            }
            catch (Exception ex)
            {
                // Show error if the data load fails
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
    }
}

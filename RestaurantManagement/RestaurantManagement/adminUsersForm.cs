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

namespace RestaurantManagement
{
    public partial class adminUsersForm : Form
    {
        private SqlConnection connect;
        public adminUsersForm()
        {
            connect = DbHelper.GetConnection();
            InitializeComponent();
        }
        public void loadData()
        {
            try
            {
                string query = "SELECT * FROM Users";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);


                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying Food: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminUsersForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadData();
        }
    }
}

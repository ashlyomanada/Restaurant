using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class MainForm : Form
    {
        private AdminAddCategory adminAddCategory;


        private void InitializeCustomControls()
        {
            adminAddCategory = new AdminAddCategory
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(adminAddCategory);
        }



        public MainForm()




        {
            InitializeComponent();
            InitializeCustomControls();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginForm Login = new LoginForm();
                Login.Show();

                this.Hide();
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowAdminForm()
        {
            
            AdminDashboard admin = new AdminDashboard();
            admin.Dock = DockStyle.Fill;

            mainpanel.Controls.Clear(); 
            mainpanel.Controls.Add(admin);

            admin.Show();
        }


        private void ShowCategoryForm()
        { 
            AdminAddCategory category = new AdminAddCategory();
            category.Dock = DockStyle.Fill;

            mainpanel.Controls.Clear(); 
            mainpanel.Controls.Add(category);

            category.Show();
        }

        private void ShowFoodForm()
        {
            adminFoodForm category = new adminFoodForm();
            category.TopLevel = false;
            category.Dock = DockStyle.Fill;

            mainpanel.Controls.Clear();
            mainpanel.Controls.Add(category);

            category.Show();
        }

        private void ShowOrderForm()
        {
            adminOrderForm category = new adminOrderForm();
            category.TopLevel = false;
            category.Dock = DockStyle.Fill;

            mainpanel.Controls.Clear();
            mainpanel.Controls.Add(category);

            category.Show();
        }

        private void ShowReportForm()
        {
            adminReport category = new adminReport();
            category.TopLevel = false;
            category.Dock = DockStyle.Fill;

            mainpanel.Controls.Clear();
            mainpanel.Controls.Add(category);

            category.Show();
        }

        private void ShowUserForm()
        {
            adminUsersForm category = new adminUsersForm();
            category.TopLevel = false;
            category.Dock = DockStyle.Fill;

            mainpanel.Controls.Clear();
            mainpanel.Controls.Add(category);

            category.Show();
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            ShowAdminForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowAdminForm();
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void category_btn_Click(object sender, EventArgs e)
        {
            ShowCategoryForm();
        }

        private void users_btn_Click(object sender, EventArgs e)
        {
            ShowUserForm();
        }

        private void food_btn_Click(object sender, EventArgs e)
        {
            ShowFoodForm();
        }

        private void costumer_btn_Click(object sender, EventArgs e)
        {
            ShowReportForm();
        }

        private void order_btn_Click(object sender, EventArgs e)
        {
            ShowOrderForm();
        }
    }
}


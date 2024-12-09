using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using connectState;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Web.Security;
using RestaurantManagement;

namespace RestaurantManagement
{

    public partial class LoginForm : Form
    {
        //private SqlConnection connect;
        
        public LoginForm()
        {
            InitializeComponent();
            //connect = DbHelper.GetConnection();
            InvalidU.Hide();
            InvalidP.Hide();
        }


        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        private void Register_label_Click(object sender, EventArgs e)
        {
            RegisterLabel registerForm = new RegisterLabel();
            registerForm.Show();

            this.Hide();
        }

        private void Login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            txtLoginPassword.PasswordChar = Login_showPass.Checked ? '\0' : '*';
        }

        public bool checkConnection()
        {
            using (SqlConnection connect = DbHelper.GetConnection())
            {
                try
                {
                    connect.Open();
                    return connect.State == ConnectionState.Open;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        private void Login_User_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = DbHelper.GetConnection())
            {
                if (checkConnection())
                {
                    try
                    {
                        string selectData = "SELECT * FROM users WHERE username = @usern AND password = @pass";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            // Ensure to use specific types
                            cmd.Parameters.Add("@usern", SqlDbType.VarChar).Value = txtLoginUsername.Text.Trim();
                            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtLoginPassword.Text.Trim(); // Hash password if stored in the database

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Login Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                MainForm mForm = new MainForm();
                                mForm.Show();


                               
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect username/password or there's no Admin Approval", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Correction Failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                    
                }
            }
        }

        private void Login_User_Click_1(object sender, EventArgs e)
        {
            // Validate empty fields
            if (string.IsNullOrWhiteSpace(txtLoginUsername.Text))
            {
                MessageBox.Show("Please fill the username field", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLoginPassword.Text))
            {
                MessageBox.Show("Please fill the password field", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connect = DbHelper.GetConnection())
            {
                try
                {
                    // SQL query to validate the user
                    string selectData = "SELECT role FROM users WHERE username = @usern AND password = @pass";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.Add("@usern", SqlDbType.VarChar).Value = txtLoginUsername.Text.Trim();
                        cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtLoginPassword.Text.Trim(); // Use hashed password in production

                        connect.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Check if a matching user is found
                            {
                                string role = reader["role"].ToString();

                                if (role == "Admin")
                                {
                                    MessageBox.Show($"Login Successfully as {role}", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Open Admin Dashboard
                                    MainForm mForm = new MainForm();
                                    mForm.Show();

                                    this.Hide();
                                }
                                else if(role == "User")
                                {
                                    MessageBox.Show($"Login Successful! Redirecting to {role} Dashboard.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Open User Dashboard or another form as required
                                    UserForm uForm = new UserForm();
                                    uForm.Show();

                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect username/password or there's no Admin Approval", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void tbnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

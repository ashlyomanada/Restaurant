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
using System.Diagnostics.Eventing.Reader;
using System.Web.Management;

namespace RestaurantManagement
{
    public partial class RegisterLabel : Form
    {
        private SqlConnection connect;
        public RegisterLabel()
        {
            InitializeComponent();
            connect = DbHelper.GetConnection();
        }

        private void tbnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_label_Click(object sender, EventArgs e)
        {
            LoginForm frmLogin = new LoginForm();
            frmLogin.Show();
            this.Hide();
        }
        private void Login_User_Click(object sender, EventArgs e)
        {
            // Check for empty fields
           

            if (txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Please fill all the empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            try
            {
                // Open the connection if it's not already open
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                // Check if username is already taken
                string selectData = "SELECT * FROM Users WHERE username = @usern";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@usern", txtUsername.Text.Trim());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Username already exists
                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show(txtUsername.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Password validation
                    if (txtPassword.Text.Length < 8)
                    {
                        MessageBox.Show("Invalid Password, at least 8 characters needed", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                    {
                        MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Insert new user
                    
                    string insertData = "INSERT INTO users(username, password, role) VALUES(@usern, @pass, @role)";
                    using (SqlCommand insertID = new SqlCommand(insertData, connect))
                    {
                        insertID.Parameters.AddWithValue("@usern", txtUsername.Text.Trim());
                        insertID.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());
                        insertID.Parameters.AddWithValue("@role", "User");
                        //insertID.Parameters.AddWithValue("@status", "Approval");

                        insertID.ExecuteNonQuery();
                        MessageBox.Show("Registered Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Show login form and hide the current form
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection in the finally block to ensure it gets closed even if an error occurs
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }
        public bool checkConnection()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            return connect.State == ConnectionState.Open;
        }

        private void Register_showPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = Register_showPass.Checked ? '\0' : '*';
            txtConfirmPassword.PasswordChar = Register_showPass.Checked ? '\0' : '*';
        }

        private void Register_label_Load(object sender, EventArgs e)
        {

        }
    }
}

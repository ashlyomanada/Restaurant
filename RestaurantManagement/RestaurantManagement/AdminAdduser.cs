using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RestaurantManagement
{
    public partial class AdminAdduser : UserControl
    {
        public AdminAdduser()
        {
            InitializeComponent();

            displayAllUsersData();


        }

        private void listData()
        {
            throw new NotImplementedException();
        }

        private ConnectionState ConnectState;
        private SqlConnection connect;

        public void displayAllUsersData()
        {
            try
            {
                // Ensure connection is open
                if (CheckConnection())
                {
                    // Query to fetch all user data
                    string query = "SELECT * FROM users";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        // Bind DataTable to DataGridView
                        dataGridView1.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch user data: {ex.Message}",
                                "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public object Connection { get; private set; }

        private void label2_Click(object sender, EventArgs e)
        {
            // Optional: Add functionality for label click event if needed
        }

        private void addUser_addBtn_Click(object sender, EventArgs e)
        {
            // Check for empty fields
            if (string.IsNullOrWhiteSpace(addUser_username.Text) ||
                string.IsNullOrWhiteSpace(addUser_password.Text) ||
                addUser_role.SelectedIndex == -1 ||
                addUser_status.SelectedIndex == -1)
            {
                MessageBox.Show("Empty Field", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check database connection
            if (CheckConnection())
            {
                try
                {
                    ConnectState = ConnectionState.Open;

                    // Query to check if username exists
                    string checkUsername = "SELECT * FROM users WHERE username = @usern";

                    using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                    {
                        cmd.Parameters.AddWithValue("@usern", addUser_username.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // Pass command to adapter
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0) // If username exists
                        {
                            MessageBox.Show($"{addUser_username.Text.Trim()} is already taken",
                                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Query to insert a new user
                            string insertData = "INSERT INTO users (username, password, role, status, date) " +
                                                "VALUES (@usern, @pass, @role, @status WHERE id = @date)";

                            using (SqlCommand insertD = new SqlCommand(insertData, connect))
                            {
                                insertD.Parameters.AddWithValue("@usern", addUser_username.Text.Trim());
                                insertD.Parameters.AddWithValue("@pass", addUser_password.Text.Trim());
                                insertD.Parameters.AddWithValue("@role", addUser_role.SelectedIndex.ToString());
                                insertD.Parameters.AddWithValue("@status", addUser_status.SelectedIndex.ToString());
                                insertD.Parameters.AddWithValue("@date", DateTime.Now);

                                displayAllUsersData();
                                insertD.ExecuteNonQuery();
                                Clearfields();

                                MessageBox.Show("Successfully Added", "Information Message",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection Failed: {ex.Message}",
                                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ConnectState = ConnectionState.Closed;
                    connect.Close(); // Close the connection
                }
            }
        }

        public bool CheckConnection()
        {
            // Initialize connection if null
            if (connect == null)
            {
                // Replace with your actual connection string
                connect = new SqlConnection(@"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\RestaurantManagement\\RestaurantManagement\\RestaurantManagement\\RestaurantManagement\\Database.mdf;Integrated Security=True");
            }

            // Open connection if closed
            if (connect.State == ConnectionState.Closed)
            {
                Open();
            }

            // Return connection state
            return connect.State == ConnectionState.Open;
        }

        private void Open()
        {
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open the connection: {ex.Message}",
                                "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Clearfields()
        {
            addUser_username.Text = "";
            addUser_password.Text = "";
            addUser_role.SelectedIndex = -1;
            addUser_status.SelectedIndex = -1;

        }
        private void addUser_clearBtn_Click(object sender, EventArgs e)
        {
            Clearfields();
        }

        private void addUser_updateBtn_Click(object sender, EventArgs e)
        {
            // Ensure fields are not empty
            if (string.IsNullOrWhiteSpace(addUser_username.Text) ||
                string.IsNullOrWhiteSpace(addUser_password.Text) ||
                addUser_role.SelectedIndex == -1 ||
                addUser_status.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmation dialog before updating
            if (MessageBox.Show($"Are you sure you want to update user with ID: {getID}?",
                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Ensure the database connection is established
                if (CheckConnection())
                {
                    try
                    {
                        // Open the connection
                        ConnectState = ConnectionState.Open;

                        // Update query
                        string updateQuery = "UPDATE users SET username = @username, password = @password, role = @role, status = @status WHERE id = @id";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, connect))
                        {
                            // Add parameters
                            updateCmd.Parameters.AddWithValue("@username", addUser_username.Text.Trim());
                            updateCmd.Parameters.AddWithValue("@password", addUser_password.Text.Trim());
                            updateCmd.Parameters.AddWithValue("@role", addUser_role.SelectedItem.ToString());
                            updateCmd.Parameters.AddWithValue("@status", addUser_status.SelectedItem.ToString());
                            updateCmd.Parameters.AddWithValue("@id", getID);

                            // Execute the query
                            int rowsAffected = updateCmd.ExecuteNonQuery();

                            // Notify the user and refresh the data
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clearfields();
                                displayAllUsersData();
                            }
                            else
                            {
                                MessageBox.Show("Update failed. No rows affected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Close the connection
                        ConnectState = ConnectionState.Closed;
                        connect.Close();
                    }
                }
            }
        }
        private int getID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row is selected

            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Retrieve data from the selected row
                getID = Convert.ToInt32(row.Cells["id"].Value); // Assuming "id" is the primary key column
                addUser_username.Text = row.Cells["username"].Value.ToString();
                addUser_password.Text = row.Cells["password"].Value.ToString();
                addUser_role.Text = row.Cells["role"].Value.ToString();
                addUser_status.Text = row.Cells["status"].Value.ToString();
            }
        }
        private void btnconnect_Click(object sender, EventArgs e)
        {

        }

        private void addUser_removeBtn_Click(object sender, EventArgs e)
        {
            // Ensure a user is selected
            if (getID == 0)
            {
                MessageBox.Show("Please select a user to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmation dialog before removing
            if (MessageBox.Show($"Are you sure you want to remove the user with ID: {getID}?",
                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Ensure the database connection is established
                if (CheckConnection())
                {
                    try
                    {
                        // Query to delete the user by ID
                        string deleteQuery = "DELETE FROM users WHERE id = @id";

                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connect))
                        {
                            // Add parameter for the ID
                            deleteCmd.Parameters.AddWithValue("@id", getID);

                            // Execute the delete query
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            // Check if the delete was successful
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clearfields();
                                displayAllUsersData();
                                getID = 0; // Reset the selected ID
                            }
                            else
                            {
                                MessageBox.Show("Failed to remove the user. The record might not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error removing user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Close the connection
                        connect.Close();
                    }
                }
            }
        }

        private void AdminAdduser_Load(object sender, EventArgs e)
        {

        }
    }
}
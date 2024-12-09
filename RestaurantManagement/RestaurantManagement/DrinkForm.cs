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
    public partial class DrinkForm : Form
    {
        private SqlConnection connect;

        public DrinkForm()
        {
            connect = DbHelper.GetConnection();
            InitializeComponent();
        }

        private void DrinkForm_Load(object sender, EventArgs e)
        {
            LoadMenu();
            LoadAppetizerData();
            getTotalItem();
            getTotalPrice();
        }

        private void LoadAppetizerData()
        {
            try
            {
                // Define your SQL query with JOIN and filter by "Appetizer"
                string query = @"
    SELECT 
        Orders.OrderId,
        Orders.FoodId,
        Food.foodname,
        Food.price,
        Categories.category,
        Orders.Quantity,
        Orders.TotalAmount
    FROM Orders
    INNER JOIN Food ON Orders.FoodId = Food.Id
    INNER JOIN Categories ON Food.category_id = Categories.Id
    WHERE Categories.category = 'Drinks'";

                // Fetch data using DbHelper
                DataTable table = DbHelper.ExecuteQuery(query);

                // Bind the DataTable to the DataGridView
                appetizerGridView.DataSource = table;

                // Hide the FoodId and OrderId columns
                if (appetizerGridView.Columns["FoodId"] != null)
                {
                    appetizerGridView.Columns["FoodId"].Visible = false;
                }
                if (appetizerGridView.Columns["OrderId"] != null)
                {
                    appetizerGridView.Columns["OrderId"].Visible = false;
                }

                // Adjust the DataGridView appearance
                appetizerGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                appetizerGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                appetizerGridView.RowHeadersVisible = false; // Hide row headers for cleaner appearance
                appetizerGridView.ReadOnly = true; // Prevent editing rows directly
                appetizerGridView.AllowUserToResizeRows = false; // Disable row resizing

                // Adjust column settings
                foreach (DataGridViewColumn column in appetizerGridView.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Make columns resize based on content
                }

                // Ensure the last column fills the remaining space
                appetizerGridView.Columns[appetizerGridView.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                // Show error if the data load fails
                MessageBox.Show("Error loading appetizer data: " + ex.Message);
            }
        }



        private void LoadMenu()
        {
            // Clear existing controls
            flowLayoutPanel1.Controls.Clear();

            // Enable AutoScroll for the FlowLayoutPanel
            flowLayoutPanel1.AutoScroll = true;

            // Query to join Food and Categories and filter by "Appetizer" category
            string query = @"
SELECT 
    Food.Id, 
    Food.foodname, 
    Food.image, 
    Food.price, 
    Categories.category 
FROM Food
INNER JOIN Categories ON Food.category_id = Categories.Id
WHERE Categories.category = 'Drinks'";

            // Get data from the database
            DataTable menuData = DbHelper.ExecuteQuery(query);

            foreach (DataRow row in menuData.Rows)
            {
                // Create Panel
                Panel panel = new Panel
                {
                    Size = new Size(150, 200),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10) // Add some space between items
                };

                // Add Image
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(130, 100),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                if (row["image"] != DBNull.Value)
                {
                    pictureBox.Image = Image.FromFile(row["image"].ToString());
                }
                panel.Controls.Add(pictureBox);

                // Add Label for Name
                Label lblName = new Label
                {
                    Text = row["foodname"].ToString(),
                    Location = new Point(10, 120),
                    AutoSize = true
                };
                panel.Controls.Add(lblName);

                // Add Label for Price
                Label lblPrice = new Label
                {
                    Text = "Php " + row["price"].ToString(),
                    Location = new Point(10, 140),
                    AutoSize = true
                };
                panel.Controls.Add(lblPrice);

                // Add Button
                Button btnAdd = new Button
                {
                    Text = "Add",
                    Size = new Size(130, 30),
                    Location = new Point(10, 160)
                };
                btnAdd.Click += (sender, e) => AddToOrder(row["Id"].ToString(), row["foodname"].ToString());
                panel.Controls.Add(btnAdd);

                // Add panel to FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void AddToOrder(string foodId, string foodName)
        {
            try
            {
                int userId = 1; // Replace with the actual logged-in user's ID
                int quantityToAdd = 1; // Quantity to add (default is 1)
                decimal foodPrice = GetFoodPrice(foodId);

                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    // First, check if the order already exists for this user and food item
                    string checkQuery = @"SELECT Quantity, TotalAmount 
                                  FROM Orders 
                                  WHERE UserId = @UserId AND FoodId = @FoodId";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@UserId", userId);
                        checkCmd.Parameters.AddWithValue("@FoodId", foodId);

                        using (SqlDataReader reader = checkCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Order already exists, update the quantity and total amount
                                int existingQuantity = reader.GetInt32(0);
                                decimal existingTotal = reader.GetDecimal(1);

                                int newQuantity = existingQuantity + quantityToAdd;
                                decimal newTotal = newQuantity * foodPrice;

                                // Update the existing order
                                UpdateOrder(conn, userId, foodId, newQuantity, newTotal, foodName);
                            }
                            else
                            {
                                // Order does not exist, insert a new record
                                decimal totalAmount = quantityToAdd * foodPrice;
                                InsertOrder(conn, userId, foodId, quantityToAdd, totalAmount, foodName);
                            }
                        }
                    }

                    // After inserting or updating, refresh the DataGrid and total values
                    LoadAppetizerData();  // Reload DataGrid with updated data
                    getTotalItem();       // Refresh total item count
                    getTotalPrice();      // Refresh total price
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item to order: " + ex.Message);
            }
        }




        private void InsertOrder(SqlConnection conn, int userId, string foodId, int quantity, decimal totalAmount, string foodName)
        {
            string insertQuery = @"INSERT INTO Orders (OrderDate, UserId, FoodId, Quantity, TotalAmount) 
                           VALUES (@OrderDate, @UserId, @FoodId, @Quantity, @TotalAmount)";

            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@FoodId", foodId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Item {foodName} added to order!");
                }
                else
                {
                    MessageBox.Show("Failed to add item to order.");
                }
            }
        }

        private void UpdateOrder(SqlConnection conn, int userId, string foodId, int newQuantity, decimal newTotal, string foodName)
        {
            string updateQuery = @"UPDATE Orders 
                           SET Quantity = @Quantity, TotalAmount = @TotalAmount 
                           WHERE UserId = @UserId AND FoodId = @FoodId";

            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                cmd.Parameters.AddWithValue("@TotalAmount", newTotal);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@FoodId", foodId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Order updated: {newQuantity} of item {foodName}.");
                }
                else
                {
                    MessageBox.Show("Failed to update order.");
                }
            }
        }




        private decimal GetFoodPrice(string foodId)
        {
            try
            {
                string query = "SELECT price FROM Food WHERE Id = @FoodId";

                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FoodId", foodId);

                        object result = cmd.ExecuteScalar();
                        if (result != null && decimal.TryParse(result.ToString(), out decimal price))
                        {
                            return price;
                        }
                        else
                        {
                            throw new Exception("Price not found for the selected food item.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching food price: " + ex.Message);
                return 0;
            }
        }

        private void getTotalItem()
        {
            try
            {
                // Query to calculate total quantity for the Appetizer category
                string query = @"
        SELECT SUM(Orders.Quantity) 
        FROM Orders
        INNER JOIN Food ON Orders.FoodId = Food.Id
        INNER JOIN Categories ON Food.category_id = Categories.Id
        WHERE Categories.category = 'Drinks'";

                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        // Set label text to show total item count
                        if (result != DBNull.Value && result != null)
                        {
                            int totalItems = Convert.ToInt32(result);
                            total.Text = $"{totalItems}";  // Update label with total items
                        }
                        else
                        {
                            total.Text = "0";  // Default value if no data is found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total items for appetizers: " + ex.Message);
            }
        }


        private void getTotalPrice()
        {
            try
            {
                // Query to calculate total price for the Appetizer category
                string query = @"
        SELECT SUM(Orders.TotalAmount) 
        FROM Orders
        INNER JOIN Food ON Orders.FoodId = Food.Id
        INNER JOIN Categories ON Food.category_id = Categories.Id
        WHERE Categories.category = 'Drinks'";

                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        // Set label text to show total price
                        if (result != DBNull.Value && result != null)
                        {
                            decimal total = Convert.ToDecimal(result);
                            totalPrice.Text = $"Php {total:F2}";  // Format total as currency with 2 decimal places
                        }
                        else
                        {
                            totalPrice.Text = "Php 0.00";  // Default value if no data is found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total price for appetizers: " + ex.Message);
            }
        }

        private void DeleteRowFromDatabase(string OrderId)
        {
            try
            {
                string query = "DELETE FROM Orders WHERE OrderId = @OrderId";

                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", OrderId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Item not found in the database.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting from database: " + ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (appetizerGridView.SelectedRows.Count > 0)
                {
                    // Get the ID of the selected row (assuming "Id" column holds the ID)
                    int selectedRowIndex = appetizerGridView.SelectedRows[0].Index;
                    string idToDelete = appetizerGridView.Rows[selectedRowIndex].Cells["OrderId"].Value.ToString();

                    // Confirm with the user before deleting
                    var confirmation = MessageBox.Show($"Are you sure you want to delete the item with ID {idToDelete}?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirmation == DialogResult.Yes)
                    {
                        // Perform database delete operation
                        DeleteRowFromDatabase(idToDelete);

                        // Remove the row from DataGridView
                        appetizerGridView.Rows.RemoveAt(selectedRowIndex);

                        MessageBox.Show("Item deleted successfully.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }

                getTotalItem();       // Refresh total item count
                getTotalPrice();      // Refresh total price
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting item: " + ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using connectState;

namespace RestaurantManagement
{
    public partial class adminFoodForm : Form
    {
        private SqlConnection connect;
        public adminFoodForm()
        {
            connect = DbHelper.GetConnection();
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDescrip_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblname_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadCategories()
        {
            try
            {
                // Query to fetch category Id and name
                string query = "SELECT Id, category FROM Categories";
                DataTable dt = new DataTable();

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connect))
                {
                    adapter.Fill(dt); // Fill the DataTable with category data
                }

                // Bind DataTable to ComboBox
                cbCategory.DataSource = dt;             // Set the data source of ComboBox
                cbCategory.DisplayMember = "category"; // Display category names
                cbCategory.ValueMember = "Id";         // Use Id as the value
                cbCategory.SelectedIndex = -1;         // Default to no selection
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadData()
        {
            try
            {
                // Query to retrieve data from the Food table with category name
                string query = @"
    SELECT 
        f.Id, 
        f.foodname, 
        c.category AS CategoryName, 
        f.price, 
        f.image, 
        f.description
    FROM 
        Food f
    INNER JOIN 
        Categories c ON f.category_id = c.Id";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Clear any previous data bindings 
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Add required columns to DataGridView
                dataGridView1.Columns.Add("Id", "ID");
                dataGridView1.Columns.Add("foodname", "Food Name");
                dataGridView1.Columns.Add("CategoryName", "Category");
                dataGridView1.Columns.Add("price", "Price");
                dataGridView1.Columns.Add("description", "Description");

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                {
                    Name = "Image",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dataGridView1.Columns.Add(imageColumn);

                // Populate the DataGridView rows
                foreach (DataRow row in dataTable.Rows)
                {
                    string imagePath = row["image"].ToString();
                    Image image = null;

                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        byte[] imageBytes = File.ReadAllBytes(imagePath);
                        image = Image.FromStream(new MemoryStream(imageBytes));
                    }

                    dataGridView1.Rows.Add(
                        row["Id"].ToString(),
                        row["foodname"].ToString(),
                        row["CategoryName"].ToString(), // Use category name instead of ID
                        row["price"].ToString(),
                        row["description"].ToString(),
                        image
                    );
                }

                // Set default styles
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying Food: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }


        private void SetUpDataGridView()
        {
            // Add a column for user input (e.g., Notes)
            DataGridViewTextBoxColumn inputColumn = new DataGridViewTextBoxColumn();
            inputColumn.Name = "InputColumn";
            inputColumn.HeaderText = "Notes";
            dataGridView1.Columns.Add(inputColumn);

            // Add a column for the Edit button
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditButton";
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true; // Ensure it's a button
            dataGridView1.Columns.Add(editButtonColumn);

            // Add a column for the Delete button
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButton";
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true; // Ensure it's a button
            dataGridView1.Columns.Add(deleteButtonColumn);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure we are clicking on a button (Edit or Delete)
            if (e.RowIndex >= 0)
            {
                // Clear all existing selections
                dataGridView1.ClearSelection();

                // Select and highlight the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                selectedRow.Selected = true;

                // Optionally, display a value from the selected row in a TextBox
                txtFoodName.Text = selectedRow.Cells[1].Value?.ToString();
                txtImage.Text = selectedRow.Cells[2].Value?.ToString();
                if (int.TryParse(selectedRow.Cells[3].Value?.ToString(), out int categoryId))
                {
                    cbCategory.SelectedValue = categoryId; // Set the ComboBox using category_id
                }
                else
                {
                    cbCategory.SelectedIndex = -1; // Clear selection if invalid
                }
                txtPrice.Text = selectedRow.Cells[4].Value?.ToString();
                txtDescription.Text = selectedRow.Cells[5].Value?.ToString();

            }
        }

        private void adminFoodForm_Load(object sender, EventArgs e)
        {
            lblname.ForeColor = Color.Black;
            btnUploadImage.ForeColor = Color.Black;
            lblcategory.ForeColor = Color.Black;
            lblPrice.ForeColor = Color.Black;
            lblDescrip.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;

            LoadCategories();
            loadData();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        { 
            if (txtFoodName.Text == "" || cbCategory.SelectedIndex == -1 || txtPrice.Text == "" || txtDescription.Text == "")
            {
                MessageBox.Show("Please fill all the empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connect.Open();
                string insertQuery = "INSERT INTO Food (foodname, image, category_id, price, description) VALUES (@foodname, @image, @category_id, @price, @description)";
                int categoryId = Convert.ToInt32(cbCategory.SelectedValue);
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connect))
                {
                    insertCmd.Parameters.AddWithValue("@foodname", txtFoodName.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@image", txtImage.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@category_id", categoryId);
                    insertCmd.Parameters.AddWithValue("@price", txtPrice.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                    

                    insertCmd.ExecuteNonQuery();
                    loadData();

                    MessageBox.Show("Food added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFoodName.Clear();
                    txtImage.Clear();
                    cbCategory.SelectedIndex = -1;
                    txtPrice.Clear();
                    txtDescription.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding food: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }


        private void btnUploadImage_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the selected image into the PictureBox
                    txtImage.Text = openFileDialog.FileName;
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Get the CategoryId from the selected row
                    int categoryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                    connect.Open();
                    string updateQuery = "UPDATE Food SET foodname = @foodname, image = @image, category_id = @category_id, price = @price, description = @description  WHERE id = @id";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, connect))
                    {
                        updateCmd.Parameters.AddWithValue("@foodname", txtFoodName.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@image", txtImage.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@category_id", cbCategory.SelectedValue);
                        updateCmd.Parameters.AddWithValue("@price", txtPrice.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@id", categoryId);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            loadData(); // Refresh the DataGridView
                            MessageBox.Show("Food updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFoodName.Clear();
                            txtImage.Clear();
                            cbCategory.SelectedIndex = -1;
                            txtPrice.Clear();
                            txtDescription.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No food found to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating food: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Get the CategoryId from the selected row
                    int categoryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                    connect.Open();
                    string deleteQuery = "DELETE FROM Food WHERE id = @id";

                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connect))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", categoryId); ;

                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            loadData(); // Refresh the DataGridView
                            MessageBox.Show("Food delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFoodName.Clear();
                            txtImage.Clear();
                            cbCategory.SelectedIndex = -1;
                            txtPrice.Clear();
                            txtDescription.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Removing food failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing food: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
       
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Clear all existing selections
                dataGridView1.ClearSelection();

                // Select and highlight the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                selectedRow.Selected = true;

                // Optionally, display a value from the selected row in a TextBox
                txtFoodName.Text = selectedRow.Cells[1].Value?.ToString();
                txtImage.Text = selectedRow.Cells[2].Value?.ToString();
                if (int.TryParse(selectedRow.Cells[3].Value?.ToString(), out int categoryId))
                {
                    cbCategory.SelectedValue = categoryId; // Set the ComboBox using category_id
                }
                else
                {
                    cbCategory.SelectedIndex = -1; // Clear selection if invalid
                }
                txtPrice.Text = selectedRow.Cells[4].Value?.ToString();
                txtDescription.Text = selectedRow.Cells[5].Value?.ToString();

            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

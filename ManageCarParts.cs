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

namespace ABC_Car_Traders
{
    public partial class ManageCarParts : Form
    {
        public ManageCarParts()
        {
            InitializeComponent();
        }

        

        private void ClearTextBoxes()
        {
            // Clear the text of all textboxes
            txtName.Text = "";
            txtManufacturer.Text = "";
            txtModel.Text = "";
            txtYear.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtPartIDToUpdate.Text = "";
            txtPartIDToDelete.Text = "";
        }

        private void InsertCarPartIntoDatabase(string partName, string partManufacturer, string carModel, int year, decimal partPrice, int quantityInStock)
        {
           
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

            // Define a SQL query for inserting a new car part
            string query = "INSERT INTO CarParts (PartName, Manufacturer, CarModel, Year, Price, Qty) VALUES (@PartName, @Manufacturer, @CarModel, @Year, @Price, @Qty)";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand using the SQL query and SqlConnection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@PartName", partName);
                    command.Parameters.AddWithValue("@Manufacturer", partManufacturer);
                    command.Parameters.AddWithValue("@CarModel", carModel);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Price", partPrice);
                    command.Parameters.AddWithValue("@Qty", quantityInStock);

                    // Execute the SQL query
                    command.ExecuteNonQuery();
                }
            }
        }

        

        private bool DeleteCarPartFromDatabase(int partIdToDelete)
{
    try
    {
        
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

        // Define a SQL query for deleting a car part based on PartID
        string query = "DELETE FROM CarParts WHERE PartID = @PartID";

        // Create a SqlConnection using the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open the connection
            connection.Open();

            // Create a SqlCommand using the SQL query and SqlConnection
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameter to the SqlCommand
                command.Parameters.AddWithValue("@PartID", partIdToDelete);

                // Execute the SQL query
                int rowsAffected = command.ExecuteNonQuery();

                // Return true if at least one row was affected (indicating success), otherwise return false
                return rowsAffected > 0;
            }
        }
    }
    catch (Exception)
    {
        throw; // Handle or log the exception as needed
    }
}





        private DataTable RetrieveCarPartsDataFromDatabase()
        {
            DataTable dataTable = new DataTable();

            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to select all columns from the CarParts table
                string query = "SELECT * FROM CarParts";

                // Create a SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlDataAdapter to fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Fill the DataTable with data from the database
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }


        private void BindCarPartsDataToDataGridView()
        {
            // Retrieve data from the CarParts table
            DataTable dataTable = RetrieveCarPartsDataFromDatabase();

            // Set the DataGridView's DataSource to the retrieved DataTable
            dataGridView1.DataSource = dataTable;
        }

       
        

        private void UpdateCarPartInDatabase(int partIdToUpdate, string partName, string partManufacturer, string carModel, int year, decimal partPrice, int quantityInStock)
        {
           
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

            // Define a SQL query to update a specific record in the CarParts table based on PartID
            string query = "UPDATE CarParts SET PartName = @PartName, Manufacturer = @Manufacturer, CarModel = @CarModel, Year = @Year, Price = @Price, Qty = @Qty WHERE PartID = @PartID";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand using the SQL query and SqlConnection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@PartID", partIdToUpdate);
                    command.Parameters.AddWithValue("@PartName", partName);
                    command.Parameters.AddWithValue("@Manufacturer", partManufacturer);
                    command.Parameters.AddWithValue("@CarModel", carModel);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Price", partPrice);
                    command.Parameters.AddWithValue("@Qty", quantityInStock);

                    // Execute the SQL query
                    command.ExecuteNonQuery();
                }
            }
        }

       

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            // Get user input from textboxes
            string name = txtName.Text;
            string manufacturer = txtManufacturer.Text;
            string model = txtModel.Text;
            int year = Convert.ToInt32(txtYear.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int qty = Convert.ToInt32(txtQty.Text);

            // Insert the new car part into the database
            InsertCarPartIntoDatabase(name, manufacturer, model, year, price, qty);

            // Show a success message
            MessageBox.Show("Car part added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the textboxes
            ClearTextBoxes();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int partIdToUpdate = Convert.ToInt32(txtPartIDToUpdate.Text);
                string partName = txtName.Text;
                string partManufacturer = txtManufacturer.Text;
                string carModel = txtModel.Text;
                int year = Convert.ToInt32(txtYear.Text);
                decimal partPrice = Convert.ToDecimal(txtPrice.Text);
                int quantityInStock = Convert.ToInt32(txtQty.Text);

                // Update the data in the database
                UpdateCarPartInDatabase(partIdToUpdate, partName, partManufacturer, carModel, year, partPrice, quantityInStock);

                // Show a success message
                MessageBox.Show("Car part updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            AdminDashboard newForm = new AdminDashboard();
            this.Hide();
            newForm.Show();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user input from textbox for the primary key (PartID) to delete
                int partIdToDelete = Convert.ToInt32(txtPartIDToDelete.Text);

                // Delete the car part from the database
                if (DeleteCarPartFromDatabase(partIdToDelete))
                {
                    // Show a success message
                    MessageBox.Show("Car part deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the textboxes
                    ClearTextBoxes();
                }
                else
                {
                    // Show an error message if the deletion fails
                    MessageBox.Show("Car part not found or deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            BindCarPartsDataToDataGridView();
        }

        private void ManageCarParts_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            // Get the search query from the TextBox
            string searchQuery = txtSearchParts.Text;

            // Perform the search and display results in a DataGridView 
            SearchCarPartsDetails(searchQuery);
        }

        private void SearchCarPartsDetails(string searchQuery)
        {
            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to search for car details
                string query = "SELECT * FROM CarParts WHERE PartName LIKE @SearchQuery OR Manufacturer LIKE @SearchQuery OR CarModel LIKE @SearchQuery OR Year LIKE @SearchQuery OR Price LIKE @SearchQuery OR Qty LIKE @SearchQuery";

                // Add sorting by Price in ascending order
                query += " ORDER BY Price ASC";

                // Create a SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlDataAdapter to fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Add a parameter for the search query
                        adapter.SelectCommand.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");

                        // Create a DataTable to store the search results
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with data from the database
                        adapter.Fill(dataTable);

                        // Set the DataGridView's DataSource to the retrieved DataTable
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

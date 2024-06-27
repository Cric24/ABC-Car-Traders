using Guna.UI.WinForms;
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
    public partial class ManageCarDetails : Form
    {
        public ManageCarDetails()
        {
            InitializeComponent();
        }

      

        

        private void InsertCarIntoDatabase(string model, string manufacturer, int year, string color, decimal price)
        {
           
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

            // SQL query for inserting a new car
            string query = "INSERT INTO Cars (Model, Manufacturer, Year, Color, Price) VALUES (@Model, @Manufacturer, @Year, @Color, @Price)";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand using the SQL query and SqlConnection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@Manufacturer", manufacturer);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Color", color);
                    command.Parameters.AddWithValue("@Price", price);

                    // Execute the SQL query
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ClearTextBoxes()
        {
            // Clear the text of all textboxes
            txtModel.Text = "";
            txtManufacturer.Text = "";
            txtYear.Text = "";
            txtColor.Text = "";
            txtPrice.Text = "";
            txtCarIDToUpdate.Text = "";
            txtCarIDToDelete.Text = "";
        }

       

        private bool DeleteCarFromDatabase(int carIdToDelete)
        {
            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // SQL query for deleting a car based on CarID
                string query = "DELETE FROM Cars WHERE CarID = @CarID";

                // Create a SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand using the SQL query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to the SqlCommand
                        command.Parameters.AddWithValue("@CarID", carIdToDelete);

                        // Execute the SQL query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Return true if at least one row was affected (indicating success), otherwise return false
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception)
            {
                throw; // Handle the exception as needed
            }



        }
        private DataTable RetrieveDataFromDatabase()
        {
            DataTable dataTable = new DataTable();

            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // SQL query to select all columns from the Cars table
                string query = "SELECT * FROM Cars";

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
                // Handle the exception as needed
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }


        private void BindDataToDataGridView()
        {
            // Retrieve data from the database
            DataTable dataTable = RetrieveDataFromDatabase();

            // Set the DataGridView's DataSource to the retrieved DataTable
            dataGridView1.DataSource = dataTable;
        }

        

       

            private void UpdateCarInDatabase(int carIdToUpdate, string model, string manufacturer, int year, string color, decimal price)
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to update a specific record in the Cars table based on CarID
                string query = "UPDATE Cars SET Model = @Model, Manufacturer = @Manufacturer, Year = @Year, Color = @Color, Price = @Price WHERE CarID = @CarID";

                // Create a SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand using the SQL query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@CarID", carIdToUpdate);
                        command.Parameters.AddWithValue("@Model", model);
                        command.Parameters.AddWithValue("@Manufacturer", manufacturer);
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@Color", color);
                        command.Parameters.AddWithValue("@Price", price);

                        // Execute the SQL query
                        command.ExecuteNonQuery();
                    }
                }
            }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            {
                // Get user input from textboxes
                string model = txtModel.Text;
                string manufacturer = txtManufacturer.Text;
                int year = Convert.ToInt32(txtYear.Text);
                string color = txtColor.Text;
                decimal price = Convert.ToDecimal(txtPrice.Text);

                // Insert the new car into the database
                InsertCarIntoDatabase(model, manufacturer, year, color, price);

                // Show a success message
                MessageBox.Show("Car added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                ClearTextBoxes();
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int carIdToUpdate = Convert.ToInt32(txtCarIDToUpdate.Text);
                string model = txtModel.Text;
                string manufacturer = txtManufacturer.Text;
                int year = Convert.ToInt32(txtYear.Text);
                string color = txtColor.Text;
                decimal price = Convert.ToDecimal(txtPrice.Text);

                // Update the data in the database
                UpdateCarInDatabase(carIdToUpdate, model, manufacturer, year, color, price);

                // Show a success message
                MessageBox.Show("Car updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            BindDataToDataGridView();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user input from textbox for the primary key (CarID) to delete
                int carIdToDelete = Convert.ToInt32(txtCarIDToDelete.Text);

                // Delete the car from the database
                if (DeleteCarFromDatabase(carIdToDelete))
                {
                    // Show a success message
                    MessageBox.Show("Car deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the textboxes
                    ClearTextBoxes();
                }
                else
                {
                    // Show an error message if the deletion fails
                    MessageBox.Show("Car not found or deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            // Get the search query from the TextBox
            string searchQuery = txtSearch.Text;

            // Perform the search and display results in a DataGridView 
            SearchCarDetails(searchQuery);
        }


        private void SearchCarDetails(string searchQuery)
        {
            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to search for car details
                string query = "SELECT * FROM Cars WHERE Model LIKE @SearchQuery OR Manufacturer LIKE @SearchQuery OR Year LIKE @SearchQuery OR Color LIKE @SearchQuery OR Price LIKE @SearchQuery";

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

 


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
    public partial class ManageCustomerDetails : Form
    {
        public ManageCustomerDetails()
        {
            InitializeComponent();
        }

        
        
            private void ClearCustomerTextBoxes()
            {
                // Clear the text of all customer-related textboxes
                txtName.Text = "";
                txtEmail.Text = "";
                txtTel.Text = "";
                txtAddress.Text = "";
                txtCusIDToDelete.Text = "";
                txtCusIDToUpdate.Text = "";
            }   

            private void InsertCustomerIntoDatabase(string customerName, string email, string telephone, string address)
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query for inserting a new customer
                string query = "INSERT INTO Customers (CustomerName, Email, Phone, Address) VALUES (@CustomerName, @Email, @Phone, @Address)";

                // Create a SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand using the SQL query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@CustomerName", customerName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", telephone);
                        command.Parameters.AddWithValue("@Address", address);

                        // Execute the SQL query
                        command.ExecuteNonQuery();
                    }
                }
            }

        

        private bool DeleteCustomerFromDatabase(int customerIdToDelete)
        {
            try
            {
               
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query for deleting a customer based on CustomerId
                string query = "DELETE FROM Customers WHERE CustomerId = @CustomerId";

                // Create a SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand using the SQL query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to the SqlCommand
                        command.Parameters.AddWithValue("@CustomerId", customerIdToDelete);

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


        private DataTable RetrieveDataFromDatabase()
        {
            DataTable dataTable = new DataTable();

            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to select all columns from the Customer table
                string query = "SELECT * FROM Customers";

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


        private void BindDataToDataGridView()
        {
            // Retrieve data from the database
            DataTable dataTable = RetrieveDataFromDatabase();

            // Set the DataGridView's DataSource to the retrieved DataTable
            dataGridView1.DataSource = dataTable;
        }

       
        

        private void UpdateCustomerInDatabase(int customerIdToUpdate, string customerName, string email, string telephone, string address)
        {
            
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

            // Define a SQL query to update a specific record in the Customers table based on CustomerId
            string query = "UPDATE Customers SET CustomerName = @CustomerName, Email = @Email, Phone = @Phone, Address = @Address WHERE CustomerId = @CustomerId";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand using the SQL query and SqlConnection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@CustomerId", customerIdToUpdate);
                    command.Parameters.AddWithValue("@CustomerName", customerName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", telephone);
                    command.Parameters.AddWithValue("@Address", address);

                    // Execute the SQL query
                    command.ExecuteNonQuery();
                }
            }


        }

        

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user input from textboxes
                string customerName = txtName.Text;
                string email = txtEmail.Text;
                string telephone = txtTel.Text;
                string address = txtAddress.Text;

                // Insert the new customer into the database
                InsertCustomerIntoDatabase(customerName, email, telephone, address);

                // Show a success message
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                ClearCustomerTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

            try
            {
                int customerIdToUpdate = Convert.ToInt32(txtCusIDToUpdate.Text);
                string customerName = txtName.Text;
                string email = txtEmail.Text;
                string telephone = txtTel.Text;
                string address = txtAddress.Text;

                // Update the data in the database
                UpdateCustomerInDatabase(customerIdToUpdate, customerName, email, telephone, address);

                // Show a success message
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                ClearCustomerTextBoxes();
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
                // Get user input from textbox for the primary key (CustomerId) to delete
                int customerIdToDelete = Convert.ToInt32(txtCusIDToDelete.Text);

                // Delete the customer from the database
                if (DeleteCustomerFromDatabase(customerIdToDelete))
                {
                    // Show a success message
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the textboxes
                    ClearCustomerTextBoxes();
                }
                else
                {
                    // Show an error message if the deletion fails
                    MessageBox.Show("Customer not found or deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            BindDataToDataGridView();
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            // Get the search query from the TextBox
            string searchQuery = txtSearchCustomers.Text;

            // Perform the search and display results in a DataGridView 
            SearchCustomerDetails(searchQuery);
        }

        private void SearchCustomerDetails(string searchQuery)
        {
            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to search for customer details
                string query = "SELECT * FROM Customers WHERE CustomerName LIKE @SearchQuery OR Email LIKE @SearchQuery OR Phone LIKE @SearchQuery OR Address LIKE @SearchQuery";

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

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            LoginManagement newForm = new LoginManagement();
            this.Hide();
            newForm.Show();
        }
    }
    }

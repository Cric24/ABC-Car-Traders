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
    public partial class ManageCustomerOrder : Form
    {
        public ManageCustomerOrder()
        {
            InitializeComponent();
        }

        

        private void ClearOrderTextBoxes()
        {
            // Clear the text of all order-related textboxes
            txtCusID.Text = "";
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
            txtStatus.Text = "";
            txtOrderIDToDelete.Text = "";
            txtOrderIDToUpdate.Text = "";
        }

        private void InsertOrderIntoDatabase(int customerId, DateTime orderDate, string productName, int quantity, decimal unitprice, string orderStatus)
        {
            
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

            // Define a SQL query for inserting a new order
            string query = "INSERT INTO CustomerOrders (CustomerID, OrderDate, ProductName, Quantity, UnitPrice, OrderStatus) VALUES (@CustomerID, @OrderDate, @ProductName, @Quantity, @UnitPrice, @OrderStatus)";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand using the SQL query and SqlConnection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.Parameters.AddWithValue("@OrderDate", orderDate);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@UnitPrice", unitprice);
                    command.Parameters.AddWithValue("@OrderStatus", orderStatus);

                    // Execute the SQL query
                    command.ExecuteNonQuery();
                }
            }




        }

        

        private bool DeleteOrderFromDatabase(int orderIdToDelete)
        {
            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query for deleting an order based on OrderID
                string query = "DELETE FROM CustomerOrders WHERE OrderID = @OrderID";

                // Create a SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand using the SQL query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to the SqlCommand
                        command.Parameters.AddWithValue("@OrderID", orderIdToDelete);

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

        

        private void UpdateOrderInDatabase(int orderIdToUpdate, int customerId, DateTime orderDate, string productName, int quantity, decimal unitprice, string orderStatus)
        {
           
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

            // Define a SQL query to update a specific record in the Orders table based on OrderID
            string query = "UPDATE CustomerOrders SET CustomerID = @CustomerID, OrderDate = @OrderDate, ProductName = @ProductName, Quantity = @Quantity, UnitPrice = @UnitPrice, OrderStatus = @OrderStatus WHERE OrderID = @OrderID";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand using the SQL query and SqlConnection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@OrderID", orderIdToUpdate);
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.Parameters.AddWithValue("@OrderDate", orderDate);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@UnitPrice", unitprice);
                    command.Parameters.AddWithValue("@OrderStatus", orderStatus);

                    // Execute the SQL query
                    command.ExecuteNonQuery();
                }
            }



        }



        


        private DataTable RetrieveCustomerDataFromDatabase1()
        {
            DataTable dataTable = new DataTable();

            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to select CustomerID and CustomerName from the Customers table
                string query = "SELECT CustomerID, CustomerName FROM Customers";

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



        private void BindCustomerOrderDataToDataGridView1()
        {
            // Retrieve customer data from the Customers table
            DataTable dataTable = RetrieveCustomerDataFromDatabase1();

            // Set the DataGridView's DataSource to the retrieved DataTable
            dataGridView2.DataSource = dataTable;
        }


        


        private void gunaButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int customerId = Convert.ToInt32(txtCusID.Text);
                DateTime orderDate = DateTime.Now; 
                string productName = txtProductName.Text;
                int quantity = Convert.ToInt32(txtQuantity.Text);
                decimal unitprice = Convert.ToDecimal(txtUnitPrice.Text);
                string orderStatus = txtStatus.Text;

                // Insert the new order into the database
                InsertOrderIntoDatabase(customerId, orderDate, productName, quantity, unitprice, orderStatus);

                // Show a success message
                MessageBox.Show("Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                ClearOrderTextBoxes();
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
                int orderIdToUpdate = Convert.ToInt32(txtOrderIDToUpdate.Text);
                int customerId = Convert.ToInt32(txtCusID.Text);
                DateTime orderDate = Convert.ToDateTime(txtOrderDate.Text);
                string productName = txtProductName.Text;
                int quantity = Convert.ToInt32(txtQuantity.Text);
                decimal unitprice = Convert.ToDecimal(txtUnitPrice.Text);
                string orderStatus = txtStatus.Text;

                // Update the data in the database
                UpdateOrderInDatabase(orderIdToUpdate, customerId, orderDate, productName, quantity, unitprice, orderStatus);

                // Show a success message
                MessageBox.Show("Order updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                ClearOrderTextBoxes();
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
                // Get user input from textbox for the primary key (OrderID) to delete
                int orderIdToDelete = Convert.ToInt32(txtOrderIDToDelete.Text);

                // Delete the order from the database
                if (DeleteOrderFromDatabase(orderIdToDelete))
                {
                    // Show a success message
                    MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the textboxes
                    ClearOrderTextBoxes();
                }
                else
                {
                    // Show an error message if the deletion fails
                    MessageBox.Show("Order not found or deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gunaButton6_Click(object sender, EventArgs e)
        {
            BindCustomerOrderDataToDataGridView1();
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            // Get the search query from the TextBox
            string searchQuery = txtSearchParts.Text;

            // Perform the search and display results in a DataGridView 
            SearchOrderDetails(searchQuery);
        }


        private void SearchOrderDetails(string searchQuery)
        {
            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to search for car details
                string query = "SELECT * FROM CustomerOrders WHERE CustomerID LIKE @SearchQuery ";

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

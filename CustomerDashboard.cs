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
    public partial class CustomerDashboard : Form
    {

        private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

        public CustomerDashboard(string customerName, int customerID)
        {
            InitializeComponent();

            lblCustomerName.Text = "Welcome, " + customerName;
            lblCustomerID.Text = "Customer ID: " + customerID;

            DisplayCustomerOrders(customerID);

            SetupDataGridView();
        }



        private void SetupDataGridView()
        {
           

            // Set DataGridView properties
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;
        }




        private void DisplayCustomerOrders(int customerID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT OrderID, OrderDate, ProductName, Quantity, UnitPrice, TotalAmount, OrderStatus FROM CustomerOrders WHERE CustomerID = @CustomerID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable ordersTable = new DataTable();
                        adapter.Fill(ordersTable);

                        // Bind the orders data to a DataGridView
                        dgvOrders.DataSource = ordersTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        


        private void SearchCarDetails(string searchQuery)
        {
            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to search for car details
                string query = "SELECT * FROM Cars WHERE Model LIKE @SearchQuery OR Manufacturer LIKE @SearchQuery OR Year LIKE @SearchQuery OR Color LIKE @SearchQuery OR Price LIKE @SearchQuery";

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
                        gunaDataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception 
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void SearchCarPartsDetails(string searchQuery)
        {
            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to search for car parts details
                string query = "SELECT * FROM CarParts WHERE PartName LIKE @SearchQuery OR Manufacturer LIKE @SearchQuery OR CarModel LIKE @SearchQuery OR Year LIKE @SearchQuery OR Price LIKE @SearchQuery OR Qty LIKE @SearchQuery";

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
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception 
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        



        private void ClearOrderTextBoxes()
        {
            // Clear the text of all order-related textboxes
            txtCusID.Text = "";
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
            txtOrderDate.Text = "";



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



        private int GetLastInsertedOrderId()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

            string query = "SELECT MAX(OrderID) FROM CustomerOrders;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Retrieve the generated OrderID
                    int orderId = Convert.ToInt32(command.ExecuteScalar());
                    return orderId;
                }
            }
        }





        private string GetOrderStatus(int orderId)
        {
            try
            {
                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query to select the order status based on OrderID
                string query = "SELECT OrderStatus FROM CustomerOrders WHERE OrderID = @OrderID";

                // Create a SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand using the SQL query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to the SqlCommand
                        command.Parameters.AddWithValue("@OrderID", orderId);

                        // Execute the SQL query
                        object result = command.ExecuteScalar();

                        // Check if the result is not null
                        if (result != null)
                        {
                            // Convert the result to a string and return
                            return result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show("Please enter a valid OrderID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return an empty string if there is an error
            return string.Empty;
        }



        private void DisplayOrderDetails(DataTable orderDetails)
        {
            // Display order details to the user 
            StringBuilder sb = new StringBuilder();
            foreach (DataRow row in orderDetails.Rows)
            {
                sb.AppendLine($"OrderID: {row["OrderID"]}");
                sb.AppendLine($"TotalAmount: {row["TotalAmount"]}");
               
            }

            MessageBox.Show(sb.ToString(), "Order Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            // Get the search query from the TextBox
            string searchQuery = txtSearchParts.Text;

            // Perform the search and display results in a DataGridView 
            SearchCarPartsDetails(searchQuery);
            
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            // Get the search query from the TextBox
            string searchQuery = txtSearch.Text;

            // Perform the search and display results in a DataGridView 
            SearchCarDetails(searchQuery);
        }

        

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            string orderIDInput = textOrderID.Text.Trim();

            if (string.IsNullOrEmpty(orderIDInput))
            {
                MessageBox.Show("Please enter an OrderID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(orderIDInput, out int orderID))
            {
                MessageBox.Show("Invalid OrderID. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DatabaseHelper dbHelper = new DatabaseHelper();

            DataTable orderDetails = dbHelper.RetrieveOrderDetails(orderID);

            if (orderDetails.Rows.Count > 0)
            {
                // Display order details proceed with checkout process
                DisplayOrderDetails(orderDetails);

                // Open the payment form
                CheckoutForm paymentForm = new CheckoutForm(orderID);
                paymentForm.ShowDialog();

                // Check if payment was successful
                if (paymentForm.PaymentSuccessful)
                {
                    // Update the order status to 'Paid' in the database
                    dbHelper.UpdateOrderStatus(orderID);

                    MessageBox.Show("Payment successful! Order has been processed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Payment failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Order not found. Please enter a valid OrderID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

            try
            {
                int customerId = Convert.ToInt32(txtCusID.Text);
                DateTime orderDate = DateTime.Now; 
                string productName = txtProductName.Text;
                int quantity = Convert.ToInt32(txtQuantity.Text);
                decimal unitprice = Convert.ToDecimal(txtUnitPrice.Text);
                string orderStatus = "Pending";

                // Insert the new order into the database
                InsertOrderIntoDatabase(customerId, orderDate, productName, quantity, unitprice, orderStatus);

                UpdateInventoryAndCars(productName, quantity);

                int orderId = GetLastInsertedOrderId();

                // Show a success message
                MessageBox.Show($"Order placed successfully! Your Order ID is: {orderId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textboxes
                ClearOrderTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateInventoryAndCars(string productName, int quantity)
        {
            // Update quantity in CarParts table
            string updateCarPartsQuery = "UPDATE CarParts SET Qty = Qty - @Quantity WHERE PartName = @ProductName";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(updateCarPartsQuery, connection))
                {
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.ExecuteNonQuery();
                }
            }
            
        }




        private void gunaButton2_Click(object sender, EventArgs e)
        {
            CustomerLogin newForm = new CustomerLogin();
            this.Hide();
            newForm.Show();
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            int customerID;
            if (int.TryParse(lblCustomerID.Text.Replace("Customer ID: ", ""), out customerID))
            {
                // Call the DisplayCustomerOrders method with the customerID
                DisplayCustomerOrders(customerID);
            }
            else
            {
                MessageBox.Show("Invalid customer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'aBC_Car_TradersDataSet.Cars' table. .
            this.carsTableAdapter.Fill(this.aBC_Car_TradersDataSet.Cars);

            // TODO: This line of code loads data into the 'aBC_Car_TradersDataSet.CustomerOrders' table.
            this.customerOrdersTableAdapter.Fill(this.aBC_Car_TradersDataSet.CustomerOrders);

        }
    }
}

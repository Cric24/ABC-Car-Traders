using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Car_Traders
{
    internal class DatabaseHelper
    {

        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

        public DataTable RetrieveOrderDetails(int orderID)
        {
            DataTable orderDetails = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM CustomerOrders WHERE OrderID = {orderID}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(orderDetails);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                Console.WriteLine($"Error: {ex.Message}");
            }

            return orderDetails;
        }

        public bool UpdateOrderStatus(int orderID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"UPDATE CustomerOrders SET OrderStatus = 'Paid' WHERE OrderID = {orderID}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


    }
}

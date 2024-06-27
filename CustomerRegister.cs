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
    public partial class CustomerRegister : Form
    {
        public CustomerRegister()
        {
            InitializeComponent();
        }




        private void RegisterUser(string username, string password)
        {
            try
            {
                // Hash the password before storing it in the database
                string hashedPassword = password;

                
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                // Define a SQL query for inserting a new user into the CustomerAuthentication table
                string query = "INSERT INTO CustomerAuthentication (Username, Password) VALUES (@Username, @Password)";

                // Create a SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand using the SQL query and SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPassword);

                        // Execute the SQL query
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





      

        private void gunaButton1_Click(object sender, EventArgs e)
        {

            // Get user input from textboxes
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password are required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Call the RegisterUser method to add the user to the database
            RegisterUser(username, password);

            // Clear the textboxes after registration
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            CustomerLogin newForm = new CustomerLogin();
            this.Hide();
            newForm.Show();
        }

        
    }
}

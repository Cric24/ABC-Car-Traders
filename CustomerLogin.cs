using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class CustomerLogin : Form
    {

        private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

        public CustomerLogin()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;

        }


       

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            // Connect to the database
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Check if the entered credentials are valid
                    string query = "SELECT COUNT(*) FROM CustomerAuthentication WHERE Username=@Username AND Password=@Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", enteredUsername);
                        command.Parameters.AddWithValue("@Password", enteredPassword);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            // Successful login
                            MessageBox.Show("Login successful!  Welcome " + enteredUsername, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Retrieve customer details from the database
                            DataTable customerData = RetrieveCustomerData(enteredUsername);


                            if (customerData.Rows.Count > 0)
                            {
                                // Get customer name and ID from the retrieved data
                                string customerName = customerData.Rows[0]["CustomerName"].ToString();
                                int customerID = Convert.ToInt32(customerData.Rows[0]["CustomerID"]);



                                // Redirect to a new form 
                                CustomerDashboard newForm = new CustomerDashboard(customerName, customerID);
                                this.Hide();
                                newForm.Show();
                            }


                            else
                            {
                                MessageBox.Show("Failed to retrieve customer data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            }
                        else
                        {
                            // Failed login
                            MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private DataTable RetrieveCustomerData(string username)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT CustomerID, CustomerName FROM Customers WHERE CustomerName = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }



        private void gunaButton1_Click(object sender, EventArgs e)
        {
            CustomerRegister newForm = new CustomerRegister();
            this.Hide();
            newForm.Show();
        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            this.Hide();
            newForm.Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
    
}

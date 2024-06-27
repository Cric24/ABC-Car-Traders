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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }



        

        // Method to retrieve data for the report 
        private DataTable RetrieveReportData()
        {
           
            string query = "SELECT * FROM CustomerOrders";
            DataTable reportData = ExecuteQuery(query);

            return reportData;
        }

        // method to execute a SQL query and return a DataTable
        private DataTable ExecuteQuery(string query)
        {
            
            DataTable result = new DataTable();

            
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                }
            }

            return result;
        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            ManageCarDetails newForm = new ManageCarDetails();
            this.Hide();
            newForm.Show();
        }

        private void gunaAdvenceTileButton6_Click(object sender, EventArgs e)
        {
            ManageCarParts newForm = new ManageCarParts();
            this.Hide();
            newForm.Show();
        }

        private void gunaAdvenceTileButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve data for the report 
                DataTable reportData = RetrieveReportData();

                // Create an instance of the ReportForm
                Report reportForm = new Report();

                // Show the report using the ShowReport method
                reportForm.ShowReport(reportData);

                // Display the report form
                reportForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaAdvenceTileButton3_Click(object sender, EventArgs e)
        {
            ManageCustomerDetails newForm = new ManageCustomerDetails();
            this.Hide();
            newForm.Show();
        }

        private void gunaAdvenceTileButton4_Click(object sender, EventArgs e)
        {
            ManageCustomerOrder newForm = new ManageCustomerOrder();
            this.Hide();
            newForm.Show();
        }

        private void gunaAdvenceTileButton5_Click(object sender, EventArgs e)
        {
            AdminLogin newForm = new AdminLogin();
            this.Hide();
            newForm.Show();
        }
    }
    
}

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
using System.Windows.Forms.DataVisualization.Charting;

namespace ABC_Car_Traders
{
    public partial class PieChartForm : Form
    {
        public PieChartForm()
        {
            InitializeComponent();

            ShowProductSalesPieChart();


        }



        private void ShowProductSalesPieChart()
        {
            // Retrieve data from the CustomerOrders table
            DataTable customerOrdersData = RetrieveCustomerOrderDataFromDatabase();

            // Check if there is data to display
            if (customerOrdersData.Rows.Count > 0)
            {
                // Create a new instance of the Chart control
                Chart pieChart = new Chart();

                // Set the chart area
                ChartArea chartArea = new ChartArea();
                pieChart.ChartAreas.Add(chartArea);

                // Set the series
                Series series = new Series();
                series.ChartType = SeriesChartType.Pie;

                // Add data points to the series
                foreach (DataRow row in customerOrdersData.Rows)
                {
                    string productName = row["ProductName"].ToString();
                    decimal totalAmount = Convert.ToDecimal(row["TotalAmount"]);

                    series.Points.AddXY(productName, totalAmount);
                }

                // Add the series to the chart
                pieChart.Series.Add(series);

                // Add the chart to the form or another container control
                Controls.Add(pieChart);

                
                pieChart.Dock = DockStyle.Fill;
                pieChart.Titles.Add("Pie Chart Total Sales by Product");

                // Display the legend
                Legend legend = new Legend();
                pieChart.Legends.Add(legend);
            }
            else
            {
                MessageBox.Show("No data available to display.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private DataTable RetrieveCustomerOrderDataFromDatabase()
        {
            DataTable dataTable = new DataTable();

            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string selectQuery = "SELECT ProductName, TotalAmount FROM CustomerOrders";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
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





        private void gunaButton4_Click(object sender, EventArgs e)
        {
            Report newForm = new Report();
            this.Hide();
            newForm.Show();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to specify the location to save the image
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpeg|BMP Image|*.bmp";
            saveFileDialog.Title = "Save Chart Image";
            saveFileDialog.ShowDialog();

            // If the user selected a file and clicked OK
            if (saveFileDialog.FileName != "")
            {
                // Get the file extension selected by the user
                string fileExtension = System.IO.Path.GetExtension(saveFileDialog.FileName);

                // Get the chart instance from the form's controls
                Chart chart = Controls.OfType<Chart>().FirstOrDefault();

                // Check if the chart instance is not null
                if (chart != null)
                {
                    // Save the chart image based on the selected file extension
                    switch (fileExtension)
                    {
                        case ".png":
                            chart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                            break;
                        case ".jpeg":
                            chart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                            break;
                        case ".bmp":
                            chart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Bmp);
                            break;
                        default:
                            MessageBox.Show("Invalid file extension.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Chart control not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

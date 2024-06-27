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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace ABC_Car_Traders
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
           
            BindSalesDataToChart();

            BindSalesDataToChart1();

        }



     

    private void BindSalesDataToChart()
        {
            // Retrieve data from the database 
            DataTable salesData = RetrieveSalesDataFromDatabase();

            // Clear any existing series in the chart
            chartSales.Series.Clear();

            // Add a new series for sales data
            Series series = new Series("Sales");
            series.ChartType = SeriesChartType.Column;

            // Add data points to the series
            foreach (DataRow row in salesData.Rows)
            {
                DateTime orderDate = Convert.ToDateTime(row["OrderDate"]); 
                decimal totalAmount = Convert.ToDecimal(row["TotalAmount"]);

                // Add a data point with the order date and total amount
                series.Points.AddXY(orderDate, totalAmount);
            }

            // Add the series to the chart
            chartSales.Series.Add(series);

            

            // Refresh the chart
            chartSales.Invalidate();
        
        }




        private void BindSalesDataToChart1()
        {
            // Retrieve data from the database 
            DataTable salesData = RetrieveSalesDataFromDatabase1();

            // Clear any existing series in the chart
            chartSales1.Series.Clear();

            // Iterate over the unique product names in the data
            foreach (string productName in salesData.AsEnumerable().Select(r => r.Field<string>("ProductName")).Distinct())
            {
                // Filter the data for the current product
                DataRow[] productRows = salesData.Select($"ProductName = '{productName}'");

                // Add a new series for the current product
                Series series = new Series(productName);
                series.ChartType = SeriesChartType.Column;

                // Add data points to the series
                foreach (DataRow row in productRows)
                {
                    DateTime orderDate = Convert.ToDateTime(row["OrderDate"]);
                    decimal totalAmount = Convert.ToDecimal(row["TotalAmount"]); 

                    // Add a data point with the order date and total amount
                    series.Points.AddXY(orderDate, totalAmount);
                }

                // Add the series to the chart
                chartSales1.Series.Add(series);
            }

           

            // Refresh the chart
            chartSales1.Invalidate();
        }



        private void SaveChartImage()
        {
            // Create a SaveFileDialog to choose the file location
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|All Files|*.*";
                saveFileDialog.Title = "Save Chart As Image";
                saveFileDialog.FileName = "SalesChart"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the chart as an image
                    chartSales1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    MessageBox.Show("Chart image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        private void SaveChartImage1()
        {
            // Create a SaveFileDialog to choose the file location
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|All Files|*.*";
                saveFileDialog.Title = "Save Chart As Image";
                saveFileDialog.FileName = "SalesChart"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the chart as an image
                    chartSales.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                    MessageBox.Show("Chart image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }




        private DataTable RetrieveSalesDataFromDatabase1()
        {
            DataTable salesData = new DataTable();

            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT OrderDate, ProductName, TotalAmount FROM CustomerOrders"; // Include ProductName in the query

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(salesData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return salesData;
        }





        private DataTable RetrieveSalesDataFromDatabase()
        {
            DataTable salesData = new DataTable();

            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\Visual Studio 2022\\ABC Car Traders\\ABC Car Traders\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT OrderDate, TotalAmount FROM CustomerOrders";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(salesData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return salesData;
        }










        public void ShowReport(DataTable reportData)
        {
            
            dataGridView1.DataSource = reportData;

            
        }

        
        

      
        private void gunaButton4_Click(object sender, EventArgs e)
        {
            SaveChartImage1();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            SaveChartImage();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            PieChartForm newForm = new PieChartForm();
            this.Hide();
            newForm.Show();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            DownloadDataTable();
            
        }



        private void DownloadDataTable()
        {
            try
            {
                // Create a SaveFileDialog to choose the file location
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV File|*.csv|Excel File|*.xlsx|All Files|*.*";
                    saveFileDialog.Title = "Save Data Table";
                    saveFileDialog.FileName = "DataTable"; // Default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Determine the selected file format and export accordingly
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 1: // CSV File
                                ExportDataTableToCSV(filePath);
                                break;
                            
                                
                        }

                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ExportDataTableToCSV(string filePath)
        {
            try
            {
                // Export data from dataGridView1 to a CSV file
                StringBuilder sb = new StringBuilder();

                // Get the column headers
                IEnumerable<string> columnHeaders = dataGridView1.Columns.Cast<DataGridViewColumn>().Select(column => column.HeaderText);
                sb.AppendLine(string.Join(",", columnHeaders));

                // Get the data rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    IEnumerable<string> rowData = row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString());
                    sb.AppendLine(string.Join(",", rowData));
                }

                // Write the CSV data to the file
                File.WriteAllText(filePath, sb.ToString());

                MessageBox.Show("Data table exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ExportDataTableToPNG(string filePath)
        {
            try
            {
                // Create a bitmap to hold the screenshot
                Bitmap bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);

                // Capture the DataGridView control as a bitmap
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));

                // Save the bitmap as a PNG file
                bitmap.Save(filePath, ImageFormat.Png);

                // Dispose the bitmap
                bitmap.Dispose();

                MessageBox.Show("Data table exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DownloadDataTableAsPNG()
        {
            try
            {
                // Create a SaveFileDialog to choose the file location
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG File|*.png|All Files|*.*";
                    saveFileDialog.Title = "Save Data Table";
                    saveFileDialog.FileName = "DataTable"; // Default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Export the data table as a PNG file
                        ExportDataTableToPNG(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            DownloadDataTableAsPNG();
        }


        private void PrintDataTable()
        {
            try
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            PrintDataTable();
        }
    }




}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin newForm = new AdminLogin();
            this.Hide();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerLogin newForm = new CustomerLogin();
            this.Hide();
            newForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLoginType = comboBox1.SelectedItem.ToString();

            // Navigate to the respective login form based on the selected item
            if (selectedLoginType == "Customer Login")
            {
                CustomerLogin customerLoginForm = new CustomerLogin();
                customerLoginForm.Show();

                this.Hide();
            }
            else if (selectedLoginType == "Admin Login")
            {
                AdminLogin adminLoginForm = new AdminLogin();
                adminLoginForm.Show();

                this.Hide();
            }
        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicks "Yes", close the application
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

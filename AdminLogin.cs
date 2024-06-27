using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class AdminLogin : Form
    {
        // Fixed admin credentials
        private const string AdminUsername = "admin";
        private const string AdminPassword = "admin123";

        //alternate
        private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ext\\Documents\\ABC Car Traders.mdf\";Integrated Security=True;Connect Timeout=30"; // Replace with your actual connection string

        public AdminLogin()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;

        }

       

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicks "Yes", close the application
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            // Check if the entered credentials match the fixed admin credentials
            if (enteredUsername == AdminUsername && enteredPassword == AdminPassword)
            {
                // Successful login
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to AdminDashboard form
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.Show();
                this.Hide(); // Hide the current login form
            }
            else
            {
                // Failed login
                MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            this.Hide();
            newForm.Show();
        }
    }
    }


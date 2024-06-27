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
    public partial class CheckoutForm : Form
    {
        private int orderID;
        public bool PaymentSuccessful { get; private set; }
        public CheckoutForm(int orderID)
        {
            InitializeComponent();
            this.orderID = orderID;

        }

        

        private void gunaButton1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCardHolderName.Text) || string.IsNullOrEmpty(txtCardNumber.Text) || string.IsNullOrEmpty(txtCVV.Text) || string.IsNullOrEmpty(gunaTextBox1.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Update the PaymentSuccessful property
            PaymentSuccessful = true;

            // Close the payment form
            this.Close();
        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox1.Checked)
            {
                gunaCheckBox2.Checked = false;
            }
        }

        private void gunaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox2.Checked)
            {
                gunaCheckBox1.Checked = false;
            }
        }
    }
    

        
}

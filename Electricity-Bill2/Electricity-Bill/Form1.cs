using CustomerData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Calculate the electricity bill from the kWh 
 * entered by the user
 * Author - Folu Edafe 
 * When - April 26,2021
 */

namespace Electricity_Bill
{
    public partial class Form1 : Form
    {
        //form level declarations
        List<Customer> customers = new List<Customer>();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtBillAmt.Text = "";
            txtNumberUsed.Text = "";
            txtFName.Focus();
        }
        //calling the keypress event to state keys that should not be allowed
        //by setting the e.Handled as true
        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating the only keys that the user can be able
            //to input into the firstName text field

            if (!char.IsLetter(e.KeyChar) && 
                e.KeyChar != '-' && 
                e.KeyChar != '\'' && 
                e.KeyChar != ' ' && 
                e.KeyChar != (char)Keys.Back 
                ) 
            {
                e.Handled = true; 
            }
        }
        //calling the keypress event to state keys that should not be allowed
        //by setting the e.Handled as true
        private void txtLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating the only keys that the user can be able
            //to input into the lastName text field

            if (!char.IsLetter(e.KeyChar) && 
                e.KeyChar != '-' && 
                e.KeyChar != '\'' && 
                e.KeyChar != ' ' && 
                e.KeyChar != (char)Keys.Back 
                ) //bad character
            {
                e.Handled = true; 
            }
        }
        // the parameters enters by the user is collected and placed
        // in a list created above and a new object is gradually added
        // with properties that has been stated fom the Class
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fname;
            string lname;
            decimal qty;
            decimal total;
            decimal totalQty;
            Customer newCustomer;

            if (Validator.IsPresent(txtFName, "FirstName") &&
                Validator.IsPresent(txtLName, "LastName") &&
                Validator.IsPresent(txtNumberUsed, "Name") &&
                Validator.IsNonNegativeDecimal(txtNumberUsed,"Quantity"))
            {
                
                fname = txtFName.Text;
                lname = txtLName.Text;
                qty = Convert.ToDecimal(txtNumberUsed.Text);
                total = 0;
                totalQty = 0;
                newCustomer = new Customer(fname, lname, qty, total);

                customers.Add(newCustomer);

                total = newCustomer.CalculateCharge(qty);
                txtBillAmt.Text = total.ToString("c2");
                DisplayProducts();
                foreach (Customer p in customers)
                    totalQty += p.Quantity;
                txtTotalKwhUsed.Text = totalQty.ToString();
            }
            

        }
        private void DisplayProducts()
        {
            lstCustomerData.Items.Clear(); //so that application runs with an empty listbox
            foreach (Customer p in customers)
                lstCustomerData.Items.Add(p);
                
            //display stats
            txtCustCount.Text = customers.Count.ToString();

            
            //displaying the average total bill for every customer added
            decimal avgTotal = CalculateBill();
            txtAverageBill.Text= avgTotal.ToString("c2");
        }
        
        //method refactored to calculate average total bills
        private decimal CalculateBill()
        {
            decimal qty;
            qty = 0;
            decimal avgTotal = 0;
            decimal total = 0;
            if (customers.Count > 0)
            {
                for (int i = 0; i < customers.Count; i++)
                    total += customers[i].CalculateCharge(qty);
                    avgTotal = total / customers.Count;
                
            }
            return avgTotal;
        }
        //everytime the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            
            DisplayProducts();
        }
    }
}

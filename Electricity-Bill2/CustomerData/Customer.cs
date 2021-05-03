using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerData
{
    public class Customer
    {
        //constant values
        const int ADMIN_CHARGE = 12;
        const decimal CHARGE = 0.07m;

        //private data
        private int accountNo;
        private decimal total;
        private decimal quantity;

        //static data 
        private static int nextAccountNo = 10000;

        //public properties that gives access to the data in a controlled way
     
        public int AccountNo { get { return accountNo; } }//read-only
        

        //auto-implemented property
        //private anonymous variable is created behind this property
        public string FName { get; set; } //auto-implementation is on
        public string LName { get; set; } 

        //the total can't be changed but can only be gotten from the
        //calculate charge method
        public decimal Total
        {
            get { return total; }            
        }
        public decimal Quantity
        {
            get { return quantity; }
            set
            {
                if (value >= 0)
                    quantity = value;
            }
        }

        //constructor with default values
        
        public Customer(string n = "unknown", string l = "unknown",
             decimal q = 0, decimal t = 0) //default unknown is declared
        {
            accountNo = nextAccountNo;
            nextAccountNo++;
            FName = n;
            LName = l;            
            quantity = q;
            total = t;
        }

        //public methods
        public decimal CalculateCharge(decimal quantity)
        {
           
            total = (quantity * CHARGE) + ADMIN_CHARGE;          
            return total;

        }

        //redefine ToString for product objects
        public override string ToString()
        {
            return accountNo.ToString() + ": " + FName + ", " + LName + " - "
                + quantity.ToString() +", "+ total.ToString("c2");
        }

        
    }
}

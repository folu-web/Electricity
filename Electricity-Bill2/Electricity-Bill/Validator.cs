using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electricity_Bill
{
    /// <summary>
    /// a repository of validation methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <param name="name">name for error message</param>
        /// <returns></returns>
        public static bool IsPresent(TextBox tb , string name)
        {
            bool isValid = true;
            if(tb.Text == "") //bad
            {
                isValid = false;
                MessageBox.Show(name + " is required", "Input error");
                tb.Focus();
                tb.BackColor = Color.Aqua;
            }
            else
            {
                tb.BackColor = Color.White;
            }
            return isValid;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <param name="name">name for error message</param>
        /// <returns></returns>
        public static bool IsNonNegativeDecimal(TextBox tb, string name)
        {
            bool isValid = true;
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value)) //bad
            {
                isValid = false;
                MessageBox.Show(name + " has to be a number", "Input error");
                tb.SelectAll();
                tb.Focus();
            }
            else if (value < 0)
            {
                isValid = false;
                MessageBox.Show(name + " has to be positive or Zero", "Input error");
                tb.SelectAll();
                tb.Focus();
            }
            return isValid;
        }
    }
}

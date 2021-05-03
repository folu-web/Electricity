using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerData.Tests
{
    [TestClass()]
    public class CustomerTests
    {
        [TestMethod()]
        public void PositiveQtyValueCalculateChargeTest()
        {
            //arrange
            Customer cust = new Customer();
            decimal quantity = 1.7m;
            decimal expectedTotal = 12.119m; //total should go through with a positive qty value
            
            decimal actualTotal;
            

            //act
            actualTotal = cust.CalculateCharge(quantity);
            
            //assert
            Assert.AreEqual(expectedTotal, actualTotal);
            
        }
        [TestMethod()]
        public void BigPositiveQtyValueCalculateChargeTest()
        {
            //arrange
            Customer cust = new Customer();
            decimal quantity = 158m;
            decimal expectedTotal = 23.06m; //total should be a zero with a negative qty value

            decimal actualTotal;


            //act
            actualTotal = cust.CalculateCharge(quantity);
            
            //assert
            Assert.AreEqual(expectedTotal, actualTotal);

        }
        [TestMethod()]
        public void ZeroQtyValueCalculateChargeTest()
        {
            //arrange
            Customer cust = new Customer();
            decimal quantity = 0;
            decimal expectedTotal = 12; //total should be a 12 with a 0 qty value

            decimal actualTotal;


            //act
            actualTotal = cust.CalculateCharge(quantity);

            //assert
            Assert.AreEqual(expectedTotal, actualTotal);

        }
    }
}
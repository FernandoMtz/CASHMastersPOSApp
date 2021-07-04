using NUnit.Framework;
using CashMastersPOS;
using System.Collections.Generic;
using System.Linq;

namespace POSChangeCalculatorTest
{
    public class Tests
    {

        [Test]
        public void TestBasicFuncitonallity()
        {
            decimal itemPrice = 50m;
            decimal[] cashProvided = new decimal[]{100m};
            POSChangeCalculator calculator = new POSChangeCalculator();
            
            List<decimal> result = calculator.ReturnOptimalChange(itemPrice,cashProvided);
            decimal expectedValue = 50.00m;
            decimal resultSum = result.Sum(x=> x);

            Assert.AreEqual(expectedValue,resultSum);
        }

        [Test]
        public void TestMultipleInputDenominations()
        {
            decimal itemPrice = 115m;
            decimal[] cashProvided = new decimal[]{100m,50m};
            POSChangeCalculator calculator = new POSChangeCalculator();
            
            List<decimal> result = calculator.ReturnOptimalChange(itemPrice,cashProvided);
            decimal expectedValue = 35.00m;
            decimal resultSum = result.Sum(x=> x);

            Assert.AreEqual(expectedValue,resultSum);
        }

        [Test]
        public void TestMultipleOutputDenominations()
        {
            decimal itemPrice = 92.05m;
            decimal[] cashProvided = new decimal[]{100m};
            POSChangeCalculator calculator = new POSChangeCalculator();
            
            List<decimal> result = calculator.ReturnOptimalChange(itemPrice,cashProvided);
            decimal expectedValue = 7.95m;
            decimal resultSum = result.Sum(x=> x);

            Assert.AreEqual(expectedValue,resultSum);
        }

         [Test]
        public void TestMultipleOutputInputDenominations()
        {
            decimal itemPrice = 162.25m;
            decimal[] cashProvided = new decimal[]{100m,100m};
            POSChangeCalculator calculator = new POSChangeCalculator();
            
            List<decimal> result = calculator.ReturnOptimalChange(itemPrice,cashProvided);
            decimal expectedValue = 37.75m;
            decimal resultSum = result.Sum(x=> x);

            Assert.AreEqual(expectedValue,resultSum);
        }

         [Test]
        public void TestEmptyInputArray()
        {
            decimal itemPrice = 192.05m;
            decimal[] cashProvided = new decimal[]{};
            POSChangeCalculator calculator = new POSChangeCalculator();
            
            List<decimal> result = calculator.ReturnOptimalChange(itemPrice,cashProvided);

            Assert.IsEmpty(result);
        }
    }
}
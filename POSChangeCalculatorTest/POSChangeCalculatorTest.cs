using NUnit.Framework;
using CashMastersPOS;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace POSChangeCalculatorTest
{
    public class Tests
    {

// Test basic functionallity by providing 1 bill and expecting 1 bill
        [Test]
        public void TestBasicFuncitonallity()
        {
            decimal itemPrice = 50m;
            decimal[] cashProvided = new decimal[]{100m};
            POSChangeCalculator calculator = new POSChangeCalculator();
            
            decimal[]result = calculator.ReturnOptimalChange(itemPrice,cashProvided);
            decimal expectedValue = 50.00m;
            decimal resultSum = result.Sum(x=> x);

            Assert.AreEqual(expectedValue,resultSum);
        }
// Test multiple denominations as input to pay the item. 
        [Test]
        public void TestMultipleInputDenominations()
        {
            decimal itemPrice = 115m;
            decimal[] cashProvided = new decimal[]{100m,50m};
            POSChangeCalculator calculator = new POSChangeCalculator();
            
            decimal[] result = calculator.ReturnOptimalChange(itemPrice,cashProvided);
            decimal expectedValue = 35.00m;
            decimal resultSum = result.Sum(x=> x);

            Assert.AreEqual(expectedValue,resultSum);
        }
//Test multiple denominations as outputs to make sure the result is optimal
        [Test]
        public void TestMultipleOutputDenominations()
        {
            decimal itemPrice = 92.05m;
            decimal[] cashProvided = new decimal[]{100m};
            POSChangeCalculator calculator = new POSChangeCalculator();
            
            decimal[] result = calculator.ReturnOptimalChange(itemPrice,cashProvided);
            decimal expectedValue = 7.95m;
            decimal resultSum = result.Sum(x=> x);
            decimal[] expectedResultArray = new decimal[]{ 5.00m, 2.00m, 0.50m, 0.20m, 0.20m, 0.05m };
            // Test that result array is the same
            Assert.AreEqual(result,expectedResultArray);
            // Test that the result sum is the same
            Assert.AreEqual(expectedValue,resultSum);
        }
//Test that input and output denominations are multiple
         [Test]
        public void TestMultipleOutputInputDenominations()
        {
            decimal itemPrice = 162.25m;
            decimal[] cashProvided = new decimal[]{100m,100m};
            POSChangeCalculator calculator = new POSChangeCalculator();
            
            decimal[] result = calculator.ReturnOptimalChange(itemPrice,cashProvided);
            decimal expectedValue = 37.75m;
            decimal resultSum = result.Sum(x=> x);

            Assert.AreEqual(expectedValue,resultSum);
        }
// Test that Empty input array is provided.
         [Test]
        public void TestEmptyInputArray()
        {
            decimal itemPrice = 192.05m;
            decimal[] cashProvided = new decimal[]{};
            POSChangeCalculator calculator = new POSChangeCalculator();
            
            decimal[] result = calculator.ReturnOptimalChange(itemPrice,cashProvided);

            Assert.IsNull(result);
        }
// Test when the change due has a value that cannot be returned exactly using the available denominations
           [Test]
        public void TestInexistingDenomination()
        {
            decimal itemPrice = 192.99m;
            decimal[] cashProvided = new decimal[]{200.00m};
            POSChangeCalculator calculator = new POSChangeCalculator();
            decimal[] result = calculator.ReturnOptimalChange(itemPrice,cashProvided);


            // Obtain configuration values from config file to obtain the current denomination configuration (country) that is used as a global setting. To change the country, it can be updated in the appconfig.json file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appconfig.json");
                var configuration = builder.Build();
                // Obtain current value in file with the Key (DenominationCountry)
                string denominationCountry = configuration["DenominationCountry"];
                // If denomination country is set to mexico the value should be null as there is no currently a denomination that handles 0.01
                if(denominationCountry == "Mexico")
                {
                     Assert.IsNull(result);
                }
                // If denomination country is set to US (which is currently the other denomination available) the value should be the expected because there is a denomination that returns 0.01 in the US
                else
                {           
                    decimal expectedValue = 7.01m;
                    decimal resultSum = result.Sum(x=> x);
                    Assert.AreEqual(expectedValue,resultSum);
                }
        }
    }
}
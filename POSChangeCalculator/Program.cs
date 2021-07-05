using System;
using System.Collections.Generic;
using System.Linq;

namespace CashMastersPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instructions
            Console.WriteLine("This is a testing application for the POS Change Calculator.");
            Console.WriteLine("In order to test the function, youll need to provide the following Inputs:");

            Console.WriteLine("1) Provide the price of the Item to be paid (Only numbers): ");
            // Read the price as an input string
            var priceText = Console.ReadLine();

            Console.WriteLine("2) Provide the bills and coins that will be used to pay the item in the following format (each bill or coin separated by comma): 100,50,0.10,0.50");
            // Read the array of bills and coins as a string in the specified format
            var billsAndCoins = Console.ReadLine();

            // Use Split to obtain the Array of bills and coins provided in the console
            string[] arrayOfbillsAndCoins = billsAndCoins.Split(",");

            //Convert the ItemPrice String to Decimal
            decimal itemPrice = Convert.ToDecimal(priceText);
            //Convert the bill and coins string array to a decimal array
            decimal[] cashProvided = Array.ConvertAll(arrayOfbillsAndCoins, x => Convert.ToDecimal(x));      

            // Create calculator object
            POSChangeCalculator calculator = new POSChangeCalculator();

            // Obtain the optimal change as an array of decimal and sort it by descending for readibility
            decimal[] changeReturned = 
                calculator.ReturnOptimalChange(itemPrice, cashProvided)
                .OrderByDescending(x=> x)
                .ToArray();

            // Display the output in an array format
            Console.WriteLine("The optimal change of Bills and coins should be the following: ");
            Console.WriteLine("["+ string.Join(",",changeReturned) + "]");
            Console.ReadLine();
        }

    }
}

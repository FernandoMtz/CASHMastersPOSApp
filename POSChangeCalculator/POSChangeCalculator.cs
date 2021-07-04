using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using NLog;
namespace CashMastersPOS
{
    public class POSChangeCalculator
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public List<decimal> ReturnOptimalChange(decimal itemPrice, decimal[] cash)
        {
            try
            {
            // Obtain configuration values from config file to obtain the current denomination configuration (country) that is used as a global setting. To change the country, it can be updated in the appconfig.json file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appconfig.json");
                var configuration = builder.Build();
                // Obtain current value in file with the Key (DenominationCountry)
                string denominationCountry = configuration["DenominationCountry"];
                //Obtain denomination Array from using configured country.
                decimal[] denominationArray = GlobalDenominations.ObtainDenominationsByCountry(denominationCountry);

                // Create a List to store the Bills and coins that will be the optimal change to return.
                List<decimal> changeList = new List<decimal>();
                // Calculate the cashAmount provided by customer;
                decimal cashAmount = CalculateCashAmount(cash);
                // Validate if the Cash provided is greater or equal than the price of the item being purchased.
                if(cashAmount >= itemPrice)
                {
                    //First step is to calculate the change to be returned to the customer.
                    decimal changeAmount =  cashAmount - itemPrice;
                    // Second is to obtain the list of denominations for the currency being used.
                    changeList = ObtainListOfBillsAndCoins(changeAmount,denominationArray);
                }
                else
                {
                    Exception exception = new Exception("The amount of cash given isn't greater or equal than the price of the item. Please provide a sufficient amount.");
                    logger.Error(exception, "Not enough money was provdied to pay for the Item");
                }
              
                return changeList;
            }
            catch(Exception ex)
            {
                logger.Error(ex, "An exception ocurred when trying to Calculate the Optimal Change.");
                Console.WriteLine("An exception ocurred when trying to Calculate the Optimal Change. The exception message is the following: " + ex.Message +", Stack Trace:  " + ex.StackTrace);
            }
            return null;
        }


        //Function used to calculate the total amount provided in cash.
        private decimal CalculateCashAmount(decimal[] cash)
        {
            decimal cashAmount = 0;
            foreach(decimal cashUnit in cash)
            {
                cashAmount += cashUnit;
            }
            return cashAmount;
        }

        private List<decimal> ObtainListOfBillsAndCoins(decimal amountToReturn, decimal[] denominations)
        {
            //Create List of bills and coins to be returned.
            List<decimal> listOfBillsAndCoins = new List<decimal>();
            //Create variable to count the amount currently being held by adding the bills and coins
            decimal sumOfBillsAndCoins = 0;
            //We repeat the procedure until the sum of the items in the list of bills and coins is the exact same amount to return to the customer.
            while(sumOfBillsAndCoins != amountToReturn)
            {
                // As denominations come in an array and go from lower values to higher values, we iterate the denominations from the end to the beginning.
                for(int i = denominations.Length - 1; i>= 0; i--)
                {
                    // Check if the current sum and the current denomination added will be less or equal than the expected amount to return.
                    if((sumOfBillsAndCoins + denominations[i]) <= amountToReturn)
                    {
                        //Add the current denomination (bill or coin) to the list and sum it to the amount counter to keep track of the value.
                        listOfBillsAndCoins.Add(denominations[i]);
                        sumOfBillsAndCoins += denominations[i];
                        break;
                    }
                }
            }
            // return the list of bills and coins used to match the right amount.
            return listOfBillsAndCoins;
        }
    }
}

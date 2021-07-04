using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;
using NLog;

namespace CashMastersPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal itemPrice = 192.05m;
            decimal[] cashProvided = new decimal[]{200m};       

            POSChangeCalculator calculator = new POSChangeCalculator();

            List<decimal> changeReturned = 
                calculator.ReturnOptimalChange(itemPrice, cashProvided)
                .OrderByDescending(x=> x)
                .ToList();

            Console.WriteLine("["+ string.Join(",",changeReturned) + "]");
        }

    }
}

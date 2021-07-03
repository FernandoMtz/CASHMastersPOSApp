using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using NLog;

namespace POSChangeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double itemPrice = 100;
            double[] cashProvided = new double[]{200};       

            POSChangeCalculator calculator = new POSChangeCalculator();
            List<double> changeReturned = calculator.ReturnOptimalChange(itemPrice, cashProvided);

            foreach(double c in changeReturned)
            {
                Console.WriteLine(c);
            }
        }

    }
}

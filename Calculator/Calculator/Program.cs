using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Calculator.Infrastructure;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            do
            {
                Console.WriteLine("Enter expression:");
                var input = Console.ReadLine();
                if(input=="q")
                    break;
                Console.WriteLine(calculator.Calculate(input));
                
            } while (true);
        }
    }
}
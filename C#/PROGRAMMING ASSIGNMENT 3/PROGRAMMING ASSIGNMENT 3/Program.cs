using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMING_ASSIGNMENT_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // three separate arrays for each separate item 
            long[] baseNumbers = new long[5];
            long[] exponents = new long[5];
            long[] results = new long[5];
            // random number generator 
            Random randomNumber = new Random();

            for (int i = 0; i <= 4; i++)//loop though the arrays
            {
                // assign a random number to each element of randomNumber and randomNumber
                baseNumbers[i] = randomNumber.Next(1, 51);
                exponents[i] = randomNumber.Next(1, 11);
            }
            for (int i = 0; i <= 4; i++)//loop though the arrays
            {
                //use C#'s built in power function to check my calculations 
                //results[i] = Convert.ToInt64(Math.Pow(Convert.ToDouble(baseNumbers[i]),Convert.ToDouble(exponents[i])));
                //call my power method 
                results[i] = Power(baseNumbers[i], exponents[i]);
            }
            //call my method for printing out 3 arrays 
            PrintArrays(baseNumbers, exponents, results);
            Console.Write("press enter to continue");
            Console.ReadLine();
        }

        //power method 
        private static long Power(long baseNumber, long exponent)
        {
            long result;
            if (exponent <= 1)//in the base case
            {
                result = baseNumber;//the result is the base number 
            }
            else//in other cases 
            {
                //the result is the base number x the power method with an exponent reduced by one 
                result = baseNumber * Power(baseNumber, exponent - 1);
            }
            return result;//return calculation 
        }

        //method for printing single arrays
        private static void PrintArray(long[] array) 
        {
            foreach (long number in array)
            {
                Console.Write(number + "    ");
            }
            Console.WriteLine();
        }

        private static void PrintArrays(long[] baseNumbers, long[] exponents, long[] results)
        {
            Console.WriteLine("Base Exponent Result");//print header 
            for (int i = 0; i <= baseNumbers.GetUpperBound(0) ; i++)//loop though arrays 
            {
                //print elements of arrays 
                Console.WriteLine(baseNumbers[i] + "    " + exponents[i] + "        " + results[i]);
            }
            Console.WriteLine();
        }
    }
}

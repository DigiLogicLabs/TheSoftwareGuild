using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        private static int GetNumberFromUser()
        {
            string prompt = "Input a number:";
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                int number;

                if (int.TryParse(input, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("That's not a number");
                }
            }
        }

        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>
        }
    }

public class Calculator
{
    private static int count;

    /// <summary>
    /// Given a number, print the factors per the specification
    /// </summary>
    public static void PrintFactors(int number)
    {
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
            {
                Console.WriteLine(i);
            }
        }
    }

    /// <summary>
    /// Given a number, print if it is perfect or not
    /// </summary>

    public static void IsPerfectNumber(int number)
    {
        int sum = 0;
        for (int i = 1; i < number; i++)
        {

            if (number % i == 0)
            {
                sum = sum + i;
                Console.WriteLine(i);
            }
        }
        if (sum == number)
        {
            Console.WriteLine("Entered a number that's perfect");
        }
    }

    /// <summary>
    /// Given a number, print if it is prime or not
    /// </summary>
    public static void IsPrimeNumber(int number)
    {
        for (int i = 1; i < number; i++)
        {

            int count = 0;
            if (number % i == 0)
            {
                count = count + i;
            }
            {

                Console.WriteLine("Entered a Prime number");
                Console.ReadLine();
            }


        }
        if (count = 1)
        {
            return number; 
        }
    }

}
    


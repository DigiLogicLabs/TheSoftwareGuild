using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
                Console.ReadLine();
        }

        static void Execute()
        {

            for (int i = 1; i <= 100; i++)

            {
                bool fizz = i % 3 == 0;
                bool buzz = i % 5 == 0;

                if (fizz && buzz)

                    Console.WriteLine(i + " FizzBuzz ");

                else if (fizz)

                    Console.WriteLine(i + " Fizz ");

                else if (buzz)
                 Console.WriteLine(i + " Buzz ");

                else
                        Console.WriteLine(i); 
            }
 
            //TODO:  Implement FizzBuzz
        }
    }
}

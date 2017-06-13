using System;
using FloorMastery.Models.Helpers;

namespace FloorMastery.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            ConsoleIO.PrintRemoveHeader();


            var orderRemove = Console.ReadLine();

            DateTime result;

            if (DateTime.TryParse(orderRemove, out result))
            {
                return;
            }
            if (orderRemove == "")
            {
                Console.WriteLine("Can't convert a blank string to a Date!");
                Console.ReadKey();
                Console.Clear();
                Menu.Start();
            }
            else
            {
                Console.WriteLine("Please enter an order date in SimpleDateFormat (MM-dd-yyyy) ");
                Console.WriteLine();
                Console.WriteLine("Press Enter to try again...");
                Console.ReadLine();
                Execute();
            }
            Console.Clear();
        }
    }
}
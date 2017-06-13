using System;
using FloorMastery.Models.Helpers;

namespace FloorMastery.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();


            ConsoleIO.PrintEditHeader();
            
            var orderEdit = Console.ReadLine();

            DateTime result;

            if (DateTime.TryParse(orderEdit, out result))
            {
                return;
            }
            if (orderEdit == "")
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
using System;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;

namespace FloorMastery.UI.Wokflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("     ╔═══════════════════════════════╗");
            Console.WriteLine("     ║           Add Orders          ║");
            Console.WriteLine("     ╚═══════════════════════════════╝");
            Console.WriteLine("           Press Enter To Start:      ");
            Console.ReadLine();
            Console.Write("Enter Date of Order (SimpleDateFormat (MM-dd-yyyy)): ");

            Order newOrder = new Order();
            var orderAdd = Console.ReadLine();

            DateTime result;

            if (DateTime.TryParse(orderAdd, out result))
            {
                return;
            }
            if (orderAdd == "")
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
            return;
            


            //            newOrder.OrdersDateTime = ConsoleIO.GetRequiredIntegerFromUser("Orders Date: ");
            //            newOrder.OrdersNumber = ConsoleIO.GetRequiredIntegerFromUser();
            //            newOrder.CustomersName = ConsoleIO.GetRequiredStringFromUser("Customer Name: ");




        }
    }
}
using System;
using System.Collections.Generic;
using FloorMastery.Data.Interfaces;
using FloorMastery.Data.Repos;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;

namespace FloorMastery.UI.Workflows
{
    public class AddOrderWorkflow
    {
        private string userinputFilePath =
            @"C:\Users\Csharpener\Desktop\Repos\conner-soligny-individual-work\FloorMastery.UI\Orders_";

        public void Execute()
        {
            List<Order> orders = new List<Order>();
            
            Order newOrder = new Order();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("     ╔═══════════════════════════════╗");
            Console.WriteLine("     ║           Add Orders          ║");
            Console.WriteLine("     ╚═══════════════════════════════╝");
            Console.WriteLine("           Press Enter To Start:      ");
            Console.ReadLine();
            Console.Write("Enter a Date you'd like to Order for (MMddyyyy): ");
            var orderDateInput = Console.ReadLine();

           


            string orderDateSymbolRemoved;
            var transformedFilePath = "";

            //convert the date with "\" or "-" inbetween, filters through and then compares it to a .txt file path
            //if there isn't one, I need to allow the creation of one that can store data
            if (orderDateInput.Contains("/"))
            {
                orderDateSymbolRemoved = orderDateInput.Replace("/", "");
                transformedFilePath = orderDateSymbolRemoved;

            }
            else if (orderDateInput.Contains("-"))
            {
                orderDateSymbolRemoved = orderDateInput.Replace("-", "");
                transformedFilePath = orderDateSymbolRemoved;
            }
            else
            {
                transformedFilePath = orderDateInput;
            }



            //May have to add a string of ".txt" after the transformedFilePath. if it doesn't match the file path, I could edit the insides of the file
            // or I could create a new text document that will take the name of the users input 
            if (userinputFilePath + transformedFilePath != Settings._filepathOrders)
            {
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("That order doesn't exist!");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.ReadLine();
                Console.WriteLine("Add a new Order?");

                if (ConsoleIO.GetYesNoAnswerFromUser("Verify adding a new Order:  ") == "Y")
                {
                    OrdersProdRepo repo = new OrdersProdRepo(Settings._filepathOrders);
                    repo.AddOrder(newOrder);
                    Console.WriteLine("Order's been Added!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("Add has been Cancelled!");
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu.Start();
                }
                newOrder.OrdersDateTime = DateTime.Parse(transformedFilePath);
                newOrder.CustomersName = ConsoleIO.GetRequiredStringFromUser("Customer Name:");
                newOrder.State = ConsoleIO.GetRequiredStringFromUser("State Abbreviation:");
                newOrder.ProductsType = ConsoleIO.GetRequiredStringFromUser("Product:");
                newOrder.Area = ConsoleIO.GetRequiredDecimalFromUser("Area");


                


                

                Console.WriteLine("Return to the main menu to Add a new Order.");
                var addOrderLink = Console.ReadLine();

                Console.Clear();
                Menu.Start();

            }


           

            // Checking for an empty string input, will return to menu if so
            if (orderDateInput == "")
            {
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("Can't convert a blank string to a Date!");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.ReadKey();
                Console.Clear();
                Execute();
            }


            //If it doesn't equal the file path.. in this case (06012013) file path exists, so it will skip it
            


            //Instead, call factory method to call the right type of manager - creates the right repo to instantiate
            //workflow calls factory for right manager
            //Manager makes calls to whatever repo it was created with - has interface object that it






            ConsoleIO.PrintOrdersListHeader();

            foreach (var order in orders)
            {
                Console.WriteLine($" #{order.OrdersNumber},    {order.CustomersName},     {order.State},  {order.TaxRate}%," +
                                  $"   {order.ProductsType},    {order.Area},    ${order.CostPerSquareFoot},    ${order.LaborCostsPerSquareFoot}," +
                                  $"    ${order.MaterialCost},     ${order.LaborCost},    ${order.Tax},     ${order.Total}");

                Console.ReadLine();
            }
            Console.Clear();

        }
    }
}
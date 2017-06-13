using System;
using System.Collections.Generic;
using FloorMastery.Data.Repos;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;
using FloorMastery.BLL.Factories;
using FloorMastery.Models.Responses;

namespace FloorMastery.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        private string userinputFilePath =
            @"C:\Users\Csharpener\Desktop\Repos\conner-soligny-individual-work\FloorMastery.UI\Orders_";
        //Have the string input from user decide what filepath to read (\Orders_06012013.txt) example.

        public void Execute()
        {
            Console.Clear();
            ConsoleIO.PrintDisplayHeader();
            var orderDateInput = ConsoleIO.GetOrderDate();


            var manager = OrderManagerFactory.Create();
            DisplayOrdersResponse response = manager.GetOrdersFromDate(orderDateInput);

            if (response.Success == true)
            {
                Console.WriteLine(response.Message);

                ConsoleIO.DisplayTheOrder(response.Orders);
               
            }
            else
            {
                Console.WriteLine(response.Message);
            }

            var transformedFilePath = "";

            //convert the date with "\" or "-" inbetween, filters through and then compares it to a .txt file path
            //if there isn't one, I need to allow the creation of one that can store data


            // comparing the string input to the file path itself..

            

            //If it doesn't equal the file path.. in this case (06012013) file path exists, so it will skip it
            if (userinputFilePath + transformedFilePath != Settings._filepathOrders)
            {
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("That order doesn't exist!");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("Return to the main menu to Add a new Order.");
                Console.ReadKey();

                Console.Clear();
                     Menu.Start();

            }


            //Instead, call factory method to call the right type of manager - creates the right repo to instantiate
            //workflow calls factory for right manager
            //Manager makes calls to whatever repo it was created with - has interface object that it

            ConsoleIO.PrintOrdersListHeader();

            foreach (var order in response.Orders)
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
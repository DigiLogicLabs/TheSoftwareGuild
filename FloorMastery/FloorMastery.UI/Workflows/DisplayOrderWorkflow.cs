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

        public void Execute()
        {
            Console.Clear();
            ConsoleIO.PrintDisplayHeader();
            var manager = OrderManagerFactory.Create();

            var orderDateInput = ConsoleIO.GetOrderDate("Please enter your order's date: ");

            DisplayOrdersResponse response = manager.LookUpAccount(orderDateInput);

            if (response.Success)
            {
                Console.WriteLine(response.Message);
                ConsoleIO.DisplayTheOrder(response.Orders);             
            }
            else
                Console.WriteLine("An Error has occured: ");
                Console.WriteLine(response.Message);


            Console.ReadKey();

            //Instead, call factory method to call the right type of manager - creates the right repo to instantiate
            //workflow calls factory for right manager
            //Manager makes calls to whatever repo it was created with - has interface object that it

//            ConsoleIO.PrintOrdersListHeader();
//
//            foreach (var order in response.Orders)
//            {
//                Console.WriteLine($" #{order.OrdersNumber},    {order.CustomersName},     {order.State},  {order.TaxRate}%," +
//                                  $"   {order.GetProductByName},    {order.Area},    ${order.CostPerSquareFoot},    ${order.LaborCostsPerSquareFoot}," +
//                                  $"    ${order.MaterialCost},     ${order.LaborCost},    ${order.Tax},     ${order.Total}");
//
//                Console.ReadLine();
//            }
//            Console.Clear();

        }
    }
}
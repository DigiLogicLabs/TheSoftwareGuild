using System;
using System.Collections.Generic;
using FloorMastery.BLL.Factories;
using FloorMastery.Data.Interfaces;
using FloorMastery.Data.Repos;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;
using FloorMastery.Models.Responses;

namespace FloorMastery.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {

            Console.Clear();
            ConsoleIO.PrintAddHeader();

            var manager = OrderManagerFactory.Create();

            Order newOrder = new Order();

            newOrder.CreationDateTime = ConsoleIO.AddOrderDate("Please input a date to Add order: ");
            newOrder.CustomersName = ConsoleIO.GetRequiredStringFromUser("Please enter customer name: ");
            newOrder.TaxData.StatesName = ConsoleIO.GetRequiredStringFromUser("Please enter your State: ");
            newOrder.ProductData.ProductsType = ConsoleIO.GetRequiredStringFromUser("Please enter the Products type: ");
            
            newOrder.Area = ConsoleIO.GetRequiredDecimalFromUser("Please enter your Area: ");


            Console.WriteLine("Add this new Order?");
            Console.WriteLine(newOrder.CreationDateTime);
            Console.WriteLine(newOrder.CustomersName);
            Console.WriteLine(newOrder.TaxData.StatesName);
            Console.WriteLine(newOrder.ProductData.ProductsType);
            Console.WriteLine(newOrder.Area);
            var confirmInput = ConsoleIO.GetYesNoAnswerFromUser("Confirm: Y/N");

            var response = manager.AddOrder(newOrder);
            if (response.Success == true)
            {
                
            }
            else
            {
                response.Success = false;
            }





        }
    }
}
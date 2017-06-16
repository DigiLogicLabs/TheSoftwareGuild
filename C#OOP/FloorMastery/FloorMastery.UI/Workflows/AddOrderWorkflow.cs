using System;
using System.Collections.Generic;
using FloorMastery.BLL;
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
            var dateInput = ConsoleIO.GetOrderDateTime();
            DateTime orderDate = Convert.ToDateTime(dateInput);

            string customerInput = ConsoleIO.EditCustomerName();
            newOrder.CustomersName = customerInput;

            string stateInput = ConsoleIO.EditStateName();
            TaxesManager stateTaxManager = TaxesFactory.Create();

            FindingStateResponse stateResponse = stateTaxManager.StateTaxDate(stateInput);

         
            if (stateResponse.Success == true)
            {
                newOrder.TaxData = stateResponse.StateTaxData;
            }
            else
            {
                stateResponse.Success = false;
            }
            string productInput = ConsoleIO.EditProductType();
            ProductManager productManager = ProductFactory.Create();
            FindingProductTypeResponse productResponse = productManager.ProductTypeData(productInput);
            if (productResponse.Success)
            {
                newOrder.ProductData = productResponse.ProductData;
            }
            else
            {
                productResponse.Success = false;
            }

            decimal areaIn = ConsoleIO.EditArea();
            newOrder.Area = areaIn;

            manager.SaveNewOrder(newOrder);
            Console.ReadKey();



            //            newOrder.CreationDateTime = ConsoleIO.AddOrderDate("Please input a date to Add order: ");
            //            newOrder.CustomersName = ConsoleIO.GetRequiredStringFromUser("Please enter customer name: ");
            //            newOrder.StatesName = ConsoleIO.GetRequiredStringFromUser("Please enter your State: ");
            //            newOrder.ProductsType = ConsoleIO.RequiredStringForProductList("Please enter the Products type: ");
            //            
            //            newOrder.Area = ConsoleIO.GetRequiredDecimalFromUser("Please enter your Area: ");
            //
            //
            //            Console.WriteLine("Add this new Order?");
            //            Console.WriteLine(newOrder.CreationDateTime);
            //            Console.WriteLine(newOrder.CustomersName);
            //            Console.WriteLine(newOrder.StatesName);
            //            Console.WriteLine(newOrder.ProductsType);
            //            Console.WriteLine(newOrder.Area);
            //            var confirmInput = ConsoleIO.GetYesNoAnswerFromUser("Confirm: Y/N");


        }
    }
}
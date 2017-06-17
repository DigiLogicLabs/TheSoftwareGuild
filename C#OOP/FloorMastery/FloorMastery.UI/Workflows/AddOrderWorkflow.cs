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
            ProductManager productManager = ProductFactory.Create();

            List<ProductData> productsList = productManager.GetAllProducts();

            string productInput = ConsoleIO.AddProductType(productsList);
           
            FindingProductTypeResponse productResponse = productManager.ProductTypeData(productInput);
            if (productResponse.Success)
            {
                newOrder.Product = productResponse.ProductData;
            }
            else
            {
                productResponse.Success = false;
            }

            decimal areaIn = ConsoleIO.EditArea();
            newOrder.Area = areaIn;

            manager.SaveNewOrder(newOrder);
            Console.ReadKey();

        }
    }
}
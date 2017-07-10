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

           

            var dateInput = ConsoleIO.GetOrderDateTime();
            DateTime orderDate = Convert.ToDateTime(dateInput);

            string customerInput = ConsoleIO.EditCustomerName();
            
            

          
            TaxesManager stateTaxManager = TaxesFactory.Create();

            List<StateTaxData> allTaxData = stateTaxManager.GetAllTaxInfo();

            string stateInput = ConsoleIO.EditStateName(allTaxData);


            FindingStateResponse stateResponse = stateTaxManager.StateTaxDate(stateInput);

         
            
            ProductManager productManager = ProductFactory.Create();

            List<ProductData> productsList = productManager.GetAllProducts();

            string productInput = ConsoleIO.AddProductType(productsList);
           
            FindingProductTypeResponse productResponse = productManager.ProductTypeData(productInput);
            

            decimal areaIn = ConsoleIO.EditArea();
            


            Order newOrder = new Order(orderDate, manager.GetNextID(orderDate),customerInput, 
                productResponse.ProductData, stateResponse.StateTaxData,areaIn);


            manager.SaveNewOrder(newOrder);
            Console.ReadKey();

        }
    }
}
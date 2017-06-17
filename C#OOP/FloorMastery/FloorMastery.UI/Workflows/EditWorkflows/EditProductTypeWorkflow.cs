using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.BLL;
using FloorMastery.BLL.Factories;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;
using FloorMastery.Models.Responses;

namespace FloorMastery.UI.Workflows.EditWorkflows
{
    public class EditProductTypeWorkflow
    {

        public void EditProductType(Order order)
        {
            OrderManager orderMan = OrderManagerFactory.Create();

            ProductManager productMan = ProductFactory.Create();


            FindingProductTypeResponse response = productMan.ProductTypeData(ConsoleIO.AddProductType(productMan.GetAllProducts()));
            

            
            if (response.Success)
            {
                order.Product = response.ProductData;

                orderMan.AddOrder(order);
                ConsoleIO.DisplaySingleOrderDetails(order);
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                response.Success = false;
            }
        }

    }
}

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

            order.Product.ProductsType = ConsoleIO.AddProductType(productMan.GetAllProducts());

            FindingProductTypeResponse response = productMan.ProductTypeData(order.Product.ProductsType);
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

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

            var newProductType = ConsoleIO.EditProductType();

//            FindingProductTypeResponse response = productMan.
        }

    }
}

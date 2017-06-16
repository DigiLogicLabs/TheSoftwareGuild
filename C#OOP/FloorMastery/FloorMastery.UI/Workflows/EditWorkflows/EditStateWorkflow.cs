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
    public class EditStateWorkflow
    {
        public void EditState(Order order)
        {
            OrderManager orderManager = OrderManagerFactory.Create();

            TaxesManager taxManager = TaxesFactory.Create();

            var newState = ConsoleIO.EditStateName();

//            FindingStateResponse response = taxManager
        }
    }
}

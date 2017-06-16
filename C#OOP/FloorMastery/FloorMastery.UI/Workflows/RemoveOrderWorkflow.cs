using System;
using FloorMastery.BLL;
using FloorMastery.BLL.Factories;
using FloorMastery.Models.Helpers;
using FloorMastery.Models.Responses;

namespace FloorMastery.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            ConsoleIO.PrintRemoveHeader();
            OrderManager manager = OrderManagerFactory.Create();

            string dateInput = ConsoleIO.AskOrderDate();
            DateTime orderDate = Convert.ToDateTime(dateInput);

            int orderNumberInput = ConsoleIO.AskOrderNumber();

            LookupOrderResponse response = manager.AccountByNumberAndDate(orderDate, orderNumberInput);

            if (response.Success)
            {
                manager.DeleteOrder(response.Order);
                Console.WriteLine("Order has been deleted. ");
            }
            else
            {
                Console.WriteLine("An error has occured: ");
                Console.WriteLine(response.Message);
            }
            Console.ReadKey();

        }
    }
}
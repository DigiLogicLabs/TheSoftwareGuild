using System;
using FloorMastery.BLL;
using FloorMastery.BLL.Factories;
using FloorMastery.Models.Helpers;
using FloorMastery.Models.Responses;

namespace FloorMastery.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();


            ConsoleIO.PrintEditHeader();
            
            OrderManager manager = OrderManagerFactory.Create();

            string dateInput = ConsoleIO.AskOrderDate();
            DateTime orderDate = Convert.ToDateTime(dateInput);

            int orderNumInput = ConsoleIO.AskOrderNumber();

            LookupOrderResponse response = manager.AccountByNumberAndDate(orderDate, orderNumInput);

            if (response.Success)
            {
                ConsoleIO.DisplaySingleOrderDetails(response.Order);
                Console.ReadKey();
                ConsoleIO.EditMenu(response.Order);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine("An error occured: ");
            }
            Console.ReadKey();

        }
    }
}
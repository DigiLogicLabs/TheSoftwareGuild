using System;
using System.Collections.Generic;
using FloorMastery.Data.Repos;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;
using FloorMastery.BLL.Factories;
using FloorMastery.Models.Responses;

namespace FloorMastery.UI.Workflows
{
    public class DisplayOrderWorkflow
    {

        public void Execute()
        {
            Console.Clear();
            ConsoleIO.PrintDisplayHeader();


            var manager = OrderManagerFactory.Create();

            var orderDateInput = ConsoleIO.DisplayOrderDate();

                        DisplayOrdersResponse response = manager.LookUpAccount(orderDateInput);

            if (response.Success)
            {
                Console.WriteLine(response.Message);
                ConsoleIO.DisplayOrderDetails(response.Orders);
            }
            else
                Console.WriteLine("An Error has occured: ");
            Console.WriteLine(response.Message);

            
            Console.ReadKey();
            Console.Clear();



        }
    }
}
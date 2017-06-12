using System;
using System.Collections.Generic;
using FloorMastery.Data.Repos;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;

namespace FloorMastery.UI.Wokflows
{
    public class DisplayOrderWorkflow
    {
        private string userinputFilePath =
            @"C:\Users\Csharpener\Desktop\Repos\conner-soligny-individual-work\FloorMastery.UI\Orders_";
        //Have the string input from user decide what filepath to read (\Orders_06012013.txt) example.

        public void Execute()
        {
            OrdersProdRepo repo = new OrdersProdRepo(Settings._filepathOrders);// public ListingOrders method which will read the file, skipping the first line, and split it on
            //the commas,has 12 properties that were asigned to each split comma section
            
            List<Order> orders = repo.ListingOrders();//has about 15 properties that the order can provide


            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("     ╔═══════════════════════════════╗");
            Console.WriteLine("     ║        Display Orders         ║");
            Console.WriteLine("     ╚═══════════════════════════════╝");
            Console.WriteLine("           Press Enter To Start:      ");
            Console.ReadLine();
            Console.Write("Enter Date of Order (MMddyyyy): ");
            var orderDateInput = Console.ReadLine();
            bool trueinput = true;




            string orderDateSymbolRemoved;
            var transformedFilePath = "";

            //convert the date with "\" or "-" inbetween, filters through and then compares it to a .txt file path
            //if there isn't one, I need to allow the creation of one that can store data
            if (orderDateInput.Contains("/"))
            {
                orderDateSymbolRemoved = orderDateInput.Replace("/", "");
                transformedFilePath = orderDateSymbolRemoved + ".txt";

            }
            else if (orderDateInput.Contains("-"))
            {
                orderDateSymbolRemoved = orderDateInput.Replace("-", "");
                transformedFilePath = orderDateSymbolRemoved + ".txt";
            }
            else
            {
                transformedFilePath = orderDateInput + ".txt";
            }


            // comparing the string input to the file path itself..

            if (orderDateInput == "")
            {
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("Can't convert a blank string to a Date!");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.ReadKey();
                Console.Clear();
                Execute();
            }

            //If it doesn't equal the file path.. in this case (06012013) file path exists, so it will skip it
            if (userinputFilePath + transformedFilePath != Settings._filepathOrders)
            {
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("That order doesn't exist!");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("Return to the main menu to Add a new Order.");
                var addOrderLink = Console.ReadLine();

                Console.Clear();
                     Menu.Start();

            }


            //Instead, call factory method to call the right type of manager - creates the right repo to instantiate
            //workflow calls factory for right manager
            //Manager makes calls to whatever repo it was created with - has interface object that it

            

            


            ConsoleIO.PrintOrdersListHeader();

            foreach (var order in orders)
            {
                Console.WriteLine($" #{order.OrdersNumber},    {order.CustomersName},     {order.State},  {order.TaxRate}%," +
                                  $"   {order.ProductsType},    {order.Area},    ${order.CostPerSquareFoot},    ${order.LaborCostsPerSquareFoot}," +
                                  $"    ${order.MaterialCost},     ${order.LaborCost},    ${order.Tax},     ${order.Total}");

                Console.ReadLine();
            }
            Console.Clear();

        }

        //                Console.WriteLine(ConsoleIO.ProductInfoLineFormat, order.OrdersNumber,
        //                    order.CustomersName, order.State, order.TaxRate,
        //                    order.ProductsType, order.Area, order.CostPerSquareFoot,
        //                    order.LaborCostsPerSquareFoot, order.MaterialCost, order.LaborCost,
        //                    order.Tax, order.Total);

            //What I used initally for printing the names, had a format but kept getting an index error so I made it easier on myself

        //was going to have some sort of switch statement to grab the Yes or No response from user when 
        // an order doesn't exist, and they want to add it. wanted a direct linked to AddOrderWorkflow somehow.


        //                if (addOrderLink == ConsoleIO.GetYesNoAnswerFromUser(addOrderLink))
        //                {
        //                    switch (addOrderLink)
        //                    {
        //                        case "Y":
        //                        case "y":
        //                            Console.WriteLine("You've chosen yes");
        //                          AddOrderWorkflow(Execute());
        //
        //                            
        //                            
        //                            
        //                            break;
        //                    }
        //                    Console.WriteLine();
        //                   
        //                }




        //                AccountManager accountManager = AccountManagerFactory.Create();
        //
        //                Console.Write("Enter an account number: ");
        //                string accountNumber = Console.ReadLine();
        //
        //                Console.Write("Enter a deposit amount: ");
        //                decimal amount = decimal.Parse(Console.ReadLine()); //User validation for if they enter a decimal

        //                AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);
        //
        //                if (response.Success)
        //                {
        //                    Console.WriteLine("Deposit completed!");
        //                    Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
        //                    Console.WriteLine($"Old Balance: {response.OldBalance:C}");
        //                    Console.WriteLine($"Amount Deposited: {response.Amount:C}");
        //                    Console.WriteLine($"New Balance: {response.Account.Balance:C}");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("An error occurred: ");
        //                    Console.WriteLine(response.Message);
        //                }
    }
}
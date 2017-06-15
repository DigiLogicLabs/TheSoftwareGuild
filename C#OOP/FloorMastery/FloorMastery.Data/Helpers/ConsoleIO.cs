using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Models.TestRepos;

namespace FloorMastery.Models.Helpers
{
    public class ConsoleIO
    {
        public static Order order = new Order();
        public const string SeparatorBar = "===================================================================================================";
        public const string OrderLineFormat = "{1,10} {1,10} {2,20} {3, 10} {4, 20} {5,30} {6,40} {7,50} {8,60} {9,70} {10,80} {11,90} {12,100}";
        public const string PickOrderLineFormat = "{0,2} {1,-20} {2,-15} {3, 5}";
        public const string ProductInfoLineFormat = "{1,10} {1,10} {2,20} {3, 10} {4, 20} {5,30} {6,40} {7,50} {8,60} {9,70} {10,80} {11,90} {12,100}";
         
        public static void PrintOrdersListHeader()
        {
            Console.WriteLine(SeparatorBar);
           Console.WriteLine("Ordr# | CtName | St. | Tax% | Product | Area | Cost/Sq.ft | Labor/Sq.ft | MatsCost | LaborCost | Tax | Total");
            Console.WriteLine(SeparatorBar);
//            foreach (var order in )
//            {
//                Console.WriteLine($" #{order.OrdersNumber},    {order.CustomersName},     {order.State},  {order.TaxRate}%," +
//                                  $"   {order.GetProductByName},    {order.Area},    ${order.CostPerSquareFoot},    ${order.LaborCostsPerSquareFoot}," +
//                                  $"    ${order.MaterialCost},     ${order.LaborCost},    ${order.Tax},     ${order.Total}");
//
//                Console.ReadLine();
//            }
//            Console.Clear();
        }
        public static void PrintAddListHeader()
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine("Order Date | Customer Name | State | Product | Area |");
            Console.WriteLine(SeparatorBar);
        }

        public static string GetRequiredStringFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }

//        public static string ConfirmInput()
//        {
//            
//        }

        public static Product ListofProducts(Product product)
        {
            while (true)
            {
                Console.Write("Here's a list of the available products: ");
                string input = Console.ReadLine();

                

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return product;
                }
            }
        }


        public static string GetRequiredIntegerFromUser(int prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                int userInput;

                if (!int.TryParse(input , out userInput))
                {
                    Console.WriteLine("You must enter valid integer.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }

        public static void PrintListOfOrdersGeneral(List<Order> orders)
        {
            Console.WriteLine();
            Console.WriteLine(PickOrderLineFormat, "", "OrdersDate", "OrdersNumber", "CustomerName");
            Console.WriteLine(SeparatorBar);

            for (int i = 0; i < orders.Count(); i++)
            {
                Console.WriteLine(PickOrderLineFormat, i + 1, orders[i].CreationDateTime + ", " + orders[i].OrdersNumber,
                    orders[i].CustomersName);
            }

            Console.WriteLine();
            Console.WriteLine(SeparatorBar);
        }

        public static void PrintListOfStateInfo(List<Order> orders)
        {

            Console.WriteLine();
            Console.WriteLine(PickOrderLineFormat, "", "StateAbbreviation", "State", "TaxRate");
            Console.WriteLine(SeparatorBar);

            for (int i = 0; i < orders.Count(); i++)
            {
                Console.WriteLine(PickOrderLineFormat, i +1, orders[i].StateAbbreviation + "," + orders[i].State, orders[i].TaxRate);
            }
            Console.WriteLine();
            Console.WriteLine(SeparatorBar);
        }

        public static void PrintListOfProductInfo(List<Order> orders)
        {
            Console.WriteLine();
            Console.WriteLine(ProductInfoLineFormat, "", "ProductType", "Area", "CostPerSquareFoot", "LaborCostPerSquareFoot", "MaterialCost", "LaborCost", "Tax", "Total");
            Console.WriteLine(SeparatorBar);
            for (int i = 0; i < orders.Count(); i++)
            {
                Console.WriteLine(ProductInfoLineFormat, i+1, orders[i].ProductsType + "," +  orders[i].Area, orders[i].CostPerSquareFoot, orders[i].LaborCostsPerSquareFoot,
                    orders[i].MaterialCost, orders[i].LaborCost, orders[i].Tax, orders[i].Total);
            }
            Console.WriteLine();
            Console.WriteLine(SeparatorBar);
        }

        public static string GetYesNoAnswerFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Y":
                    case "y":
                        Console.WriteLine("You've chosen yes");
                        
                        Console.ReadKey();
                        Console.Clear();



                        break;
                    case "N":
                    case "n":
                        Console.WriteLine("You've chosen no");
                        
                        Console.ReadKey();
                        

                        break;
                }


                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue...");
                    
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue...");
                        
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    
                    return input;
                }

            }
        }

        public static decimal GetRequiredDecimalFromUser(string prompt)
        {
            decimal output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid decimal.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (output < 100)
                    {
                        Console.WriteLine("Order Area must be at least 100 Sq./Ft.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    return output;
                }
            }
        }

        public static DateTime AddOrderDate(string prompt)


        {
            Console.WriteLine(prompt);
            string userInput = Console.ReadLine();

            if (userInput == "")
            {
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("Can't convert a blank string to a Date!");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.ReadKey();
                Console.Clear();
                AddOrderDate("Try again!: ");

            }
            DateTime orderDate = DateTime.Parse(userInput);
            if (orderDate < DateTime.Now)
            {
                Console.WriteLine("New Order's Date must be in the future!");
                Console.ReadKey();
                Console.Clear();
                AddOrderDate("Enter a future date for the Order: ");
               
            }
                return orderDate;
        }

        public static DateTime GetOrderDateTime(string prompt)
        {
            Console.WriteLine(prompt);
            var userInput = Console.ReadLine();
            if (userInput == "")
            {
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("Empty string - Not Valid Date");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.ReadKey();
                Console.Clear();
                GetOrderDateTime("Enter a new Date: ");
            }
            DateTime orderDate = DateTime.Parse(userInput);

            return orderDate;
        }


        public static void DisplayTheOrder(List<Order> orders)
        {
            Console.WriteLine("Here is your current Order:  ");
            Console.WriteLine();

            foreach (var order in orders)
            {
                Console.WriteLine($"Order Number:           #{order.OrdersNumber}");
                Console.WriteLine($"Customer Name:       {order.CustomersName}");
                Console.WriteLine($"State:                 {order.State}");
                Console.WriteLine($"Tax Rate:             {order.TaxRate}%");
                Console.WriteLine($"Product Type:        {order.ProductsType}");
                Console.WriteLine($"Area:                {order.Area}Sq/Ft");
                Console.WriteLine($"Cost/Sq. Foot:       ${order.CostPerSquareFoot}");
                Console.WriteLine($"LaborCost/Sq. Foot:  ${order.LaborCostsPerSquareFoot}");
                Console.WriteLine($"Material Cost:       ${order.MaterialCost}");
                Console.WriteLine($"Labor Cost:          ${order.LaborCost}");
                Console.WriteLine($"Tax:                 ${order.Tax}");
                Console.WriteLine($"Total:               ${order.Total}");
            }
            
        }

        public static void PrintDisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("     ╔═══════════════════════════════╗");
            Console.WriteLine("     ║        Display Orders         ║");
            Console.WriteLine("     ╚═══════════════════════════════╝");
            Console.WriteLine("           Press Enter To Start:      ");
            Console.ReadLine();
            Console.WriteLine();
        }

        public static void PrintAddHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("     ╔═══════════════════════════════╗");
            Console.WriteLine("     ║           Add Orders          ║");
            Console.WriteLine("     ╚═══════════════════════════════╝");
            Console.WriteLine("           Press Enter To Start:      ");
            Console.ReadLine();
            Console.WriteLine();
        }

        public static void PrintEditHeader()
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("     ╔═══════════════════════════════╗");
            Console.WriteLine("     ║           Edit Orders         ║");
            Console.WriteLine("     ╚═══════════════════════════════╝");
            Console.WriteLine("           Press Enter To Start:      ");
            Console.ReadLine();
            Console.WriteLine();
        }

        public static void PrintRemoveHeader()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("     ╔═══════════════════════════════╗");
            Console.WriteLine("     ║          Remove Orders        ║");
            Console.WriteLine("     ╚═══════════════════════════════╝");
            Console.WriteLine("           Press Enter To Start:      ");
            Console.ReadLine();
            Console.WriteLine();
        }

        public static void PrintMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("********************************************");
            Console.WriteLine("     ╔═══════════════════════════════╗");
            Console.WriteLine("     ║        Flooring Program       ║");
            Console.WriteLine("     ╚═══════════════════════════════╝");
            Console.WriteLine(" * ");
            Console.WriteLine(" * 1. Display Orders");
            Console.WriteLine(" * 2. Add an Order");
            Console.WriteLine(" * 3. Edit an Order");
            Console.WriteLine(" * 4. Remove an Order");
            Console.WriteLine(" * 5/Q. Quit");
            Console.WriteLine(" * ");
            Console.WriteLine("********************************************");
            Console.Write("          Enter selection:                ");
            Console.ResetColor();
        }

        

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine(PickOrderLineFormat, i + 1, orders[i].OrdersDateTime + ", " + orders[i].OrdersNumber,
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
                    if (output < 0 || output > 4)
                    {
                        Console.WriteLine("GPA must be between 0 and 4.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    return output;
                }
            }
        }

        public static DateTime GetOrderDate()
        {
            Console.WriteLine("Please enter date for order: ");
            string userInput = Console.ReadLine();

            DateTime orderDate = Convert.ToDateTime(userInput);

            return orderDate;
        }

        public static void DisplayTheOrder(List<Order> orders)
        {
            Console.WriteLine("Here is your current Order:  ");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order Number: {order.OrdersNumber}");
                Console.WriteLine($"Customer Name: {order.CustomersName}");
                Console.WriteLine($"State: {order.State}");
                Console.WriteLine($"Tax Rate: {order.TaxRate}");
                Console.WriteLine($"Product Type: {order.ProductsType}");
                Console.WriteLine($"Area: {order.Area}");
                Console.WriteLine($"Cost/Sq. Foot: {order.CostPerSquareFoot}");
                Console.WriteLine($"LaborCost/Sq. Foot: {order.LaborCostsPerSquareFoot}");
                Console.WriteLine($"Material Cost: {order.MaterialCost}");
                Console.WriteLine($"Labor Cost: {order.LaborCost}");
                Console.WriteLine($"Tax: {order.Tax}");
                Console.WriteLine($"Total: {order.Total}");
            }
        }
    }
}

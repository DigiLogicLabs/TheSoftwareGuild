using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Models.Helpers
{
    public class ConsoleIO
    {
        public const string SeparatorBar = "===================================================================================================";
        public const string OrderLineFormat = "{0,-20} {1,-15} {2, 5}";
        public const string PickOrderLineFormat = "{0,2} {1,-20} {2,-15} {3, 5}";
        public const string ProductInfoLineFormat = "{0,2} {1,-20} {2,-15} {3, 5} {4, 10} {5,15} {6,20} {7,25} {8,30} {9,35} {10,40} {11,45} {12,50}";

        public static void PrintOrdersListHeader()
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine(OrderLineFormat, "OrdersDate", "OrdersNumber", "CustomerName", "Area");
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

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
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


    }
}

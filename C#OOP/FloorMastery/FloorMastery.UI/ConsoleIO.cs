using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Models.TestRepos;
using FloorMastery.UI.Workflows.EditWorkflows;

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
           Console.WriteLine("Ordr# | CtName | St. | Tax% | ProductData | Area | Cost/Sq.ft | Labor/Sq.ft | MatsCost | LaborCost | Tax | Total");
            Console.WriteLine(SeparatorBar);
//            foreach (var order in )
//            {
//                Console.WriteLine($" #{order.OrdersNumber},    {order.CustomersName},     {order.State},  {order.TaxRate}%," +
//                                  $"   {order.GetProductDataForType},    {order.Area},    ${order.CostPerSquareFoot},    ${order.LaborCostsPerSquareFoot}," +
//                                  $"    ${order.MaterialCost},     ${order.LaborCost},    ${order.Tax},     ${order.Total}");
//
//                Console.ReadLine();
//            }
//            Console.Clear();
        }
        public static void PrintAddListHeader()
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine("Order Date | Customer Name | State | ProductData | Area |");
            Console.WriteLine(SeparatorBar);
        }

        public static string AskOrderDate()
        {
            Console.WriteLine("Please enter an Order date: ");
            string userInput = Console.ReadLine();

            return userInput;
        }

        public static int AskOrderNumber()
        {
            Console.WriteLine("Please enter an order number: ");
            string orderNumbInput = Console.ReadLine();

            return int.Parse(orderNumbInput);
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

        public static string RequiredStringForProductList(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                switch (input)
                {
                    case "Wood":
                        break;
                    case "Tile":
                        break;
                    case "Laminate":
                        break;
                    case "Carpet":
                        break;
                }
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



        public static ProductData ListofProducts(ProductData productData)
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
                    return productData;
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
                Console.WriteLine(PickOrderLineFormat, i +1, orders[i].TaxData.StatesAbbreviation + "," + orders[i].TaxData.StatesName, orders[i].TaxData.TaxRate);
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
                Console.WriteLine(ProductInfoLineFormat, i+1, orders[i].ProductData.ProductsType + "," +  orders[i].Area, orders[i].ProductData.CostPerSquareFoot, orders[i].ProductData.LaborCostPerSquareFoot,
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

        public static DateTime GetOrderDateTime()
        {
            
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("Enter the Orders Date: ");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            var userInput = Console.ReadLine();
            if (userInput == "")
            {
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("Empty string - Not Valid Date");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("Try again!");
                Console.ReadKey();
                Console.Clear();
                GetOrderDateTime();
            }
            DateTime orderDate = DateTime.Parse(userInput);
            if (orderDate == DateTime.Now.AddDays(1))
            {
                Console.WriteLine("Sorry, has to be at least be 1 day prior to booking");
                Console.ReadKey();
                GetOrderDateTime();

            }

            return orderDate;
        }

        public static void DisplaySingleOrderDetails(Order order)
        {
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("Orders Details: ");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine($"Order Number:           #{order.OrdersNumber}");
            Console.WriteLine($"Customer Name:       {order.CustomersName}");
            Console.WriteLine($"State:                 {order.StatesName}");
            Console.WriteLine($"Tax Rate:             {order.TaxRate}%");
            Console.WriteLine($"ProductData Type:        {order.ProductsType}");
            Console.WriteLine($"Area:                {order.Area}Sq/Ft");
            Console.WriteLine($"Cost/Sq. Foot:       ${order.CostPerSquareFoot}");
            Console.WriteLine($"LaborCost/Sq. Foot:  ${order.LaborCostPerSquareFoot}");
            Console.WriteLine($"Material Cost:       ${order.MaterialCost}");
            Console.WriteLine($"Labor Cost:          ${order.LaborCost}");
            Console.WriteLine($"Tax:                 ${order.Tax}");
            Console.WriteLine($"Total:               ${order.Total}");
        }

        public static void DisplayOrderDetails(List<Order> orders)
        {
            Console.WriteLine("Here is your current Order:  ");
            Console.WriteLine();

            foreach (var order in orders)
            {
                Console.WriteLine($"Order Number:           #{order.OrdersNumber}");
                Console.WriteLine($"Customer Name:       {order.CustomersName}");
                Console.WriteLine($"State:                 {order.StatesName}");
                Console.WriteLine($"Tax Rate:             {order.TaxRate}%");
                Console.WriteLine($"ProductData Type:        {order.ProductsType}");
                Console.WriteLine($"Area:                {order.Area}Sq/Ft");
                Console.WriteLine($"Cost/Sq. Foot:       ${order.CostPerSquareFoot}");
                Console.WriteLine($"LaborCost/Sq. Foot:  ${order.LaborCostPerSquareFoot}");
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

            Console.ForegroundColor = ConsoleColor.Magenta;
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

        public static void EditMenu(Order order)
        {
            bool isTrue = false;

            while (!isTrue)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("Edit Menu: Select what you'd like to edit: ");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("1. Customer Name ");
                Console.WriteLine("2. State ");
                Console.WriteLine("3.  ProductData Type ");
                Console.WriteLine("4. Area ");
                Console.WriteLine();

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        isTrue = true;
                        EditCustomerNameWorkflow editCustomerNameWorkflow = new EditCustomerNameWorkflow();
                        editCustomerNameWorkflow.EditCustomerName(order);
                        break;
                    case "2":
                        isTrue = true;
                        EditStateWorkflow editStateWorkflow = new EditStateWorkflow();
                        editStateWorkflow.EditState(order);
                        
                        break;
                    case "3":
                        isTrue = true;
                        EditProductTypeWorkflow editProductTypeWorkflow = new EditProductTypeWorkflow();
                        editProductTypeWorkflow.EditProductType(order);
                        break;
                    case "4":
                        isTrue = true;
                        EditAreaWorkflow editAreaWorkflow = new EditAreaWorkflow();
                        editAreaWorkflow.EditArea(order);
                        break;
                    default:
                        break;
                }

            }          
        }

        public static decimal EditArea()
        {
            Console.WriteLine("Enter a new Area: ");
            var userInput = decimal.Parse(Console.ReadLine());

            return userInput;
        }

        public static string EditCustomerName()
        {
            Console.WriteLine("Enter a new Name for your Order: ");
            var userInput = Console.ReadLine();
            if (userInput =="")
            {
                Console.WriteLine("Names can't be blank!");
                EditCustomerName();
            }

            return userInput;
        }

        public static string EditProductType()
        {
            Console.WriteLine("Enter a new ProductData for your Order: ");
            var userInput = Console.ReadLine();

            return userInput;
        }

        public static string EditStateName()
        {
            Console.WriteLine("Enter a new State: ");
            string userInput = Console.ReadLine();

            return userInput;
        }

        public static string SaveTheEdit()
        {
            Console.WriteLine("Do you wish to save your changes?");
            Console.WriteLine(ConsoleIO.GetYesNoAnswerFromUser("Y/N"));
            var newSave = ConsoleIO.GetYesNoAnswerFromUser(Console.ReadLine());

            return newSave;
        }

        public static void DisplayEdittedOrder(Order order)
        {
            Console.WriteLine();
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine(" Updated Details: ");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine($"Order #: {order.OrdersNumber}");
            Console.WriteLine($"Customer Name: {order.CustomersName}");
            Console.WriteLine($"State: {order.TaxData.StatesName}");
            Console.WriteLine($"Tax Rate: {order.TaxData.TaxRate}");
            Console.WriteLine($"Product Type: {order.ProductData.ProductsType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost/ Sq.Foot: {order.ProductData.CostPerSquareFoot}");
            Console.WriteLine($"Material Cost: {order.MaterialCost}");
            Console.WriteLine($"Labor Cost: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total}");
        }

        
    }
}

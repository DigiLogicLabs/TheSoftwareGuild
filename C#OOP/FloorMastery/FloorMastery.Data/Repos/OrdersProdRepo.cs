using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;

namespace FloorMastery.Data.Repos
{
    public class OrdersProdRepo :IOrderRepository
    {


        public const string _directoryPath = @"C:\Users\Csharpener\Desktop\Repos\conner-soligny-individual-work\C#OOP\FloorMastery\TextFiles";

        

       
        TaxesProdRepo _stateTaxRepo = new TaxesProdRepo();
        ProductsProdRepo _productTypeRepo = new ProductsProdRepo();

        public OrdersProdRepo(TaxesProdRepo stateTaxRepo, ProductsProdRepo productTypeRepo)
        {
            _stateTaxRepo = stateTaxRepo;
            _productTypeRepo = productTypeRepo;
        }



        public List<Order> ListingOrders(DateTime orderDate)
        {
            List<Order> ordersList = new List<Order>();

            string orderString = "Orders_";

            string userInput = _directoryPath + orderString + String.Format(orderDate.ToString("MMddyyyy")) + ".txt";

            if (File.Exists(userInput))
            {
                using (StreamReader sr = new StreamReader(userInput))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        

                        string[] columns = line.Split(',');


                        Order newOrder = new Order(
                            orderDate, 
                            int.Parse(columns[0]), 
                            columns[1], 
                            _productTypeRepo.GetProductDataForType(columns[4]), //may have to change the index location for the columns after refactoring
                            _stateTaxRepo.GetTaxDataForState(columns[2]),
                            decimal.Parse(columns[5]));

                        ordersList.Add(newOrder);

                    }
                }
            }
            return ordersList;
        }

        public string FilePathCreated(DateTime orderDate)
        {
            string orderString = "Orders_";

            string userInput = _directoryPath + orderString + String.Format(orderDate.ToString("MMddyyyy")) + ".txt";

            return userInput;
        }

        private string CreateCsvForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", order.CreationDateTime,
                order.CustomersName, order.TaxData.StatesName, order.Product.ProductsType, order.Area);
        }

        private void CreateOrdersFile(List<Order> orders)
        {
            if (File.Exists(_directoryPath))
                File.Delete(_directoryPath);
            using (StreamWriter sr = new StreamWriter(_directoryPath))
            {
                sr.WriteLine("CreationDateTime,CustomersName,State,GetProductDataForType,Area");
                foreach (var order in orders)
                {
                    sr.WriteLine(CreateCsvForOrder(order));
                }
            }
        }


        public Order OrdersDateAndNumber(DateTime orderDate, int orderNumber)
        {
            throw new NotImplementedException();
        }

     

        public List<Order> OrdersByDateList(DateTime orderDateTime)
        {
            List<Order> orders = new List<Order>();
            if (orderDateTime.ToString() == _directoryPath)
            {
                Console.WriteLine("Not an order: ");

            }
            else
            {

                using (StreamReader sr = new StreamReader(_directoryPath))
                {

                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');

                        Order newOrder = new Order(
                            orderDateTime,
                            int.Parse(columns[0]),
                            columns[1],
                            _productTypeRepo.GetProductDataForType(columns[4]), //may have to change the index location for the columns after refactoring
                            _stateTaxRepo.GetTaxDataForState(columns[2]),
                            decimal.Parse(columns[5]));


                        orders.Add(newOrder);

                    }
                }
            }
            return orders;
        }


        //Edit Orders looked up by Date - shows order number and what's in the order
        public bool EditOrder(Order order, DateTime orderDate, int orderNumber)
        {
            var orders = ListingOrders(orderDate);
            orders[orderNumber] = order;

            CreateOrdersFile(orders);
            throw new NotImplementedException();
        }

     


        //Removes an order, grab the order number and information - confirm if they want to remove this item from the orders list
        public bool RemoveOrder(Order order)
        {
            string topLine = "Order#,CustomerName,State,TaxRate,ProductType,Area,Cost/Sq.Foot,LaborCost/Sq.Foot, MaterialCost,LaborCost,Tax,Total";

            List<Order> orderList = ListingOrders(order.CreationDateTime);
            orderList.Remove(order);

            string orderString = "Orders_";

            string userInput = _directoryPath + orderString + String.Format(order.CreationDateTime.ToString("MMddyyyy")) + ".txt";

            using (StreamWriter sw = new StreamWriter(userInput))
            {
                sw.WriteLine(topLine);

                foreach (var singleOrder in orderList)
                {
                    if (singleOrder.OrdersNumber == order.OrdersNumber)
                    {
                       
                    }
                    else
                    {
                        string row = $"{singleOrder.OrdersNumber}{singleOrder.CustomersName}{singleOrder.TaxData.StatesName}{singleOrder.TaxData.TaxRate}{singleOrder.Product.ProductsType}{singleOrder.Area}{singleOrder.Product.CostPerSquareFoot}" +
                                     $"{singleOrder.Product.LaborCostPerSquareFoot}{singleOrder.MaterialCost}{singleOrder.LaborCost}{singleOrder.Tax}{singleOrder.Total}";
                        sw.WriteLine(row);
                    }
                }
            }


            return true;
        }
        


        //Adding a new order, should be a date that's greater than todays DateTime.. if the order exists, prompt for re-entry
        public bool AddOrder(Order order)
        {
            List<Order> orderList = new List<Order>();


            using (StreamWriter sw = new StreamWriter(_directoryPath, true))
            {
                string line = CreateCsvForOrder(order);

                sw.WriteLine(line);
            }
            return true;
        }


        public Order LoadOrder(DateTime date, int orderNumber)
        {
            var dailyOrders = ListingOrders(date);
            var selectedOrder = dailyOrders.SingleOrDefault(s => s.OrdersNumber == orderNumber);
            return selectedOrder;
        }

        public bool SaveExistingOrder(Order order)
        {
            string topLine = "Order#,CustomerName,State,TaxRate,ProductType,Area,Cost/Sq.Foot,LaborCost/Sq.Foot, MaterialCost,LaborCost,Tax,Total";
            string orderString = "Orders_";

            List<Order> orderList = ListingOrders(order.CreationDateTime);

            string userInput = _directoryPath + orderString + String.Format(order.CreationDateTime.ToString("MMddyyyy")) + ".txt";

            using (StreamWriter sw = new StreamWriter(userInput))
            {
                sw.WriteLine(topLine);
                foreach (var orderO in orderList)
                {
                    Order orderSave = orderO;
                    if (orderO.OrdersNumber == order.OrdersNumber)
                    {
                        orderSave = order;
                    }
                    string row = $"{orderSave.OrdersNumber}{orderSave.CustomersName}{orderSave.TaxData.StatesName}{orderSave.TaxData.TaxRate}{orderSave.Product.ProductsType}{orderSave.Area}{orderSave.Product.CostPerSquareFoot}" +
                                 $"{orderSave.Product.LaborCostPerSquareFoot}{orderSave.MaterialCost}{orderSave.LaborCost}{orderSave.Tax}{orderSave.Total}";
                    sw.WriteLine(row);
                }
            }
            return true;
        }

        public bool SavingBrandNewOrder(Order order)
        {
            List<Order> orderList = ListingOrders(order.CreationDateTime);
            order.OrdersNumber = (orderList.Count > 0) ? orderList.Max(m => m.OrdersNumber) + 1 : 1;
            orderList.Add(order);

            string topLine = "Order#,CustomerName,State,TaxRate,ProductType,Area,Cost/Sq.Foot,LaborCost/Sq.Foot, MaterialCost,LaborCost,Tax,Total";
            string orderString = "Orders_";

            string userInput = _directoryPath + orderString + String.Format(order.CreationDateTime.ToString("MMddyyyy")) + ".txt";

            using (StreamWriter sw = new StreamWriter(userInput))
            {
                sw.WriteLine(topLine);
                foreach (var indivOrder in orderList)
                {
                    Order orderSave = indivOrder;

                    string row = $"{orderSave.OrdersNumber}{orderSave.CustomersName}{orderSave.TaxData.StatesName}{orderSave.TaxData.TaxRate}{orderSave.Product.ProductsType}{orderSave.Area}{orderSave.Product.CostPerSquareFoot}" +
                                 $"{orderSave.Product.LaborCostPerSquareFoot}{orderSave.MaterialCost}{orderSave.LaborCost}{orderSave.Tax}{orderSave.Total}";
                    sw.WriteLine(row);
                }
            }
            return true;
        }
    }
}
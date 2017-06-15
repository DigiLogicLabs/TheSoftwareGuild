using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Remoting.Messaging;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;

namespace FloorMastery.Data.Repos
{
    public class OrdersProdRepo :IOrderRepository
    {
        

        private string _filePathOrders = Settings._filepathOrders;

        public OrdersProdRepo(string filePathOrders)
        {
            _filePathOrders = filePathOrders;
        }



        public List<Order> ListingOrders()
        {
            List<Order> orders = new List<Order>();

            using (StreamReader sr = new StreamReader(_filePathOrders))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Order newOrder = new Order();

                    string[] columns = line.Split(',');

                   
                    newOrder.OrdersNumber = int.Parse(columns[0]);
                    newOrder.CustomersName = columns[1];
                    newOrder.TaxData.StatesName = columns[2];
                    newOrder.TaxData.TaxRate = decimal.Parse(columns[3]);
                    newOrder.ProductData.ProductsType = columns[4];
                    newOrder.Area = decimal.Parse(columns[5]);
                    newOrder.ProductData.CostPerSquareFoot = decimal.Parse(columns[6]);
                    newOrder.ProductData.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    newOrder.MaterialCost = decimal.Parse(columns[8]);
                    newOrder.LaborCost = decimal.Parse(columns[9]);
                    newOrder.Tax = decimal.Parse(columns[10]);
                    newOrder.Total = decimal.Parse(columns[11]);

                    orders.Add(newOrder);

                }
            }
                                return orders;
        }

        private string CreateCsvForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", order.CreationDateTime,
                order.CustomersName, order.TaxData.StatesName, order.ProductData.ProductsType, order.Area);
        }

        private void CreateOrdersFile(List<Order> orders)
        {
            if (File.Exists(_filePathOrders))
                File.Delete(_filePathOrders);
            using (StreamWriter sr = new StreamWriter(_filePathOrders))
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
            if (orderDateTime.ToString() == _filePathOrders)
            {
                Console.WriteLine("Not an order: ");

            }
            else
            {

                using (StreamReader sr = new StreamReader(_filePathOrders))
                {

                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Order newOrder = new Order();

                        string[] columns = line.Split(',');


                        newOrder.OrdersNumber = int.Parse(columns[0]);
                        newOrder.CustomersName = columns[1];
                        newOrder.TaxData.StatesName = columns[2];
                        newOrder.TaxData.TaxRate = decimal.Parse(columns[3]);
                        newOrder.ProductData.ProductsType = columns[4];
                        newOrder.Area = decimal.Parse(columns[5]);
                        newOrder.ProductData.CostPerSquareFoot = decimal.Parse(columns[6]);
                        newOrder.ProductData.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                        newOrder.MaterialCost = decimal.Parse(columns[8]);
                        newOrder.LaborCost = decimal.Parse(columns[9]);
                        newOrder.Tax = decimal.Parse(columns[10]);
                        newOrder.Total = decimal.Parse(columns[11]);

                        orders.Add(newOrder);

                    }
                }
            }
            return orders;
        }


        //Edit Orders looked up by Date - shows order number and what's in the order
        public bool EditOrder(Order order, DateTime orderDate, int orderNumber)
        {
            var orders = ListingOrders();
            orders[orderNumber] = order;

            CreateOrdersFile(orders);
            throw new NotImplementedException();
        }


        //Removes an order, grab the order number and information - confirm if they want to remove this item from the orders list
        public bool RemoveOrder(Order order, int orderNumber)
        {
            var orders = ListingOrders();
            orders.RemoveAt(orderNumber);



            CreateOrdersFile(orders);
            throw new NotImplementedException();
        }
        


        //Adding a new order, should be a date that's greater than todays DateTime.. if the order exists, prompt for re-entry
        public bool AddOrder(Order order)
        {
            List<Order> orderList = new List<Order>();


            using (StreamWriter sw = new StreamWriter(_filePathOrders, true))
            {
                string line = CreateCsvForOrder(order);

                sw.WriteLine(line);
            }
            return true;
        }

        public Order LoadOrder(DateTime date, int orderNumber)
        {
            throw new NotImplementedException();
        }
    }
}
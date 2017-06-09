using System;
using System.Collections.Generic;
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

        //ListingOrders uses the file reading path to split the different order segments on the comma, grabbing all 13 properties -- All of the orders information

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

                    newOrder.OrdersDateTime = DateTime.Parse(columns[0]);
                    newOrder.OrdersNumber = int.Parse(columns[2]);
                    newOrder.CustomersName = columns[3];
                    newOrder.State = columns[4];
                    newOrder.TaxRate = decimal.Parse(columns[5]);
                    newOrder.ProductsType = columns[6];
                    newOrder.Area = decimal.Parse(columns[7]);
                    newOrder.CostPerSquareFoot = decimal.Parse(columns[8]);
                    newOrder.LaborCostsPerSquareFoot = decimal.Parse(columns[9]);
                    newOrder.MaterialCost = decimal.Parse(columns[10]);
                    newOrder.LaborCost = decimal.Parse(columns[11]);
                    newOrder.Tax = decimal.Parse(columns[12]);
                    newOrder.Total = decimal.Parse(columns[13]);

                    orders.Add(newOrder);

                }
            }
                                return orders;
        }


        //Format adding Order - needs verification for future date
        private string CreateCsvForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", order.OrdersDateTime,
                order.CustomersName, order.State, order.ProductsType, order.Area.ToString());
        }

        private void CreateOrdersFile(List<Order> orders)
        {
            if (File.Exists(_filePathOrders))
                File.Delete(_filePathOrders);
            using (StreamWriter sr = new StreamWriter(_filePathOrders))
            {
                sr.WriteLine("OrdersDateTime,CustomersName,State,ProductsType,Area");
                foreach (var order in orders)
                {
                    sr.WriteLine(CreateCsvForOrder(order));
                }
            }
        }

        //Can use the orders Date and number to make a comparison to existing orders, if OrdersDateAndNumber is already existent, promt user for a new entry
        public Order OrdersDateAndNumber(DateTime orderDate, int orderNumber)
        {
            throw new NotImplementedException();
        }


        //List all the orders on the specified date. 
        public List<Order> OrdersByDateList(DateTime orderDateTime)
        {
            throw new NotImplementedException();
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

            using (StreamWriter sw = new StreamWriter(_filePathOrders, true))
            {
                string line = CreateCsvForOrder(order);

                sw.WriteLine(line);
            }
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models;

namespace FloorMastery.Data.Repos
{
    public class OrdersTestRepo
    {
        private string _filePath;

        public OrdersTestRepo(string filePath)
        {
            _filePath = filePath;
        }

        //orders, add ,edit ,delete

        public List<Order> ListingOrders()
        {
            List<Order> orders = new List<Order>();

            using (StreamReader sr = new StreamReader(_filePath))
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

        //Adding
        public void Add(Order order)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                string line = CreateCsvForOrder(order);

                sw.WriteLine(line);
            }
        }
        //Edit
        public void Edit(Order order, int index)
        {
            var orders = ListingOrders();
            orders[index] = order;

            CreateOrdersFile(orders);
        }

        public void Delete(int index)
        {
            var orders = ListingOrders();
            orders.RemoveAt(index);

            CreateOrdersFile(orders);
        }

        //Format adding Order - needs verification for future date
        private string CreateCsvForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", order.OrdersDateTime,
                order.CustomersName, order.State, order.ProductsType, order.Area.ToString());
        }

        private void CreateOrdersFile(List<Order> orders)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);
            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("OrdersDateTime,CustomersName,State,ProductsType,Area");
                foreach (var order in orders)
                {
                    sr.WriteLine(CreateCsvForOrder(order));
                }
            }
        }
    }
}
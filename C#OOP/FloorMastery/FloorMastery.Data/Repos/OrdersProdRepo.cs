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



//        public List<Order> ListingOrders(DateTime orderDate)
//        {
//            List<Order> ordersList = new List<Order>();
//
//            string orderString = "Orders_";
//
//            string userInput = _directoryPath + orderString + String.Format(orderDate.ToString("MMddyyyy")) + ".txt";
//
//            if (File.Exists(userInput))
//            {
//                using (StreamReader sr = new StreamReader(userInput))
//                {
//                    sr.ReadLine();
//                    string line;
//
//                    while ((line = sr.ReadLine()) != null)
//                    {
//                        
//
//                        string[] columns = line.Split(',');
//
//
//                        Order newOrder = new Order(
//                            orderDate, 
//                            int.Parse(columns[0]), 
//                            columns[1], 
//                            _productTypeRepo.GetProductDataForType(columns[4]), //may have to change the index location for the columns after refactoring
//                            _stateTaxRepo.GetTaxDataForState(columns[2]),
//                            decimal.Parse(columns[5]));
//
//                        ordersList.Add(newOrder);
//
//                    }
//                }
//            }
//            return ordersList;
//        }

        public string FilePathCreated(DateTime orderDate)
        {
            string orderString = "Orders_";

            string userInput =Path.Combine( _directoryPath, orderString + String.Format(orderDate.ToString("MMddyyyy")) + ".txt");

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



        public List<Order> LoadOrders(DateTime orderDateTime)
        {
            List<Order> orders = new List<Order>();

            var path = FilePathCreated(orderDateTime);

            if (File.Exists(path))
            {



                using (StreamReader sr = new StreamReader(path))
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
                            _productTypeRepo
                                .GetProductDataForType(
                                    columns[
                                        4]), //may have to change the index location for the columns after refactoring
                            _stateTaxRepo.GetTaxDataForState(columns[2]),
                            decimal.Parse(columns[5]));


                        orders.Add(newOrder);

                    }
                }
            }

            return orders;
        }


        //Edit Orders looked up by Date - shows updatedOrder number and what's in the updatedOrder
        public bool EditOrder(Order order, DateTime orderDate, int orderNumber)
        {
            var orders = LoadOrders(orderDate);
            orders[orderNumber] = order;

            CreateOrdersFile(orders);
            throw new NotImplementedException();
        }

     


        //Removes an updatedOrder, grab the updatedOrder number and information - confirm if they want to remove this item from the orders list
        public bool RemoveOrder(Order order)
        {
            

            List<Order> orderList = LoadOrders(order.CreationDateTime)
                .Where(m => m.OrdersNumber != order.OrdersNumber).ToList();
            



            SpitOutInfo(orderList, order.CreationDateTime);
            return true;
        }
        


        //Adding a new updatedOrder, should be a date that's greater than todays DateTime.. if the updatedOrder exists, prompt for re-entry
        


        public Order LoadOrder(DateTime date, int orderNumber)
        {
            var dailyOrders = LoadOrders(date);
            var selectedOrder = dailyOrders.SingleOrDefault(s => s.OrdersNumber == orderNumber);
            return selectedOrder;
        }

        public bool SaveExistingOrder(Order updatedOrder)
        {
           


            List<Order> orderList = LoadOrders(updatedOrder.CreationDateTime)
                .Where(m => m.OrdersNumber != updatedOrder.OrdersNumber).ToList();

                        orderList.Add(updatedOrder);

            SpitOutInfo(orderList, updatedOrder.CreationDateTime);
            return true;
        }

        public bool SavingBrandNewOrder(Order order)
        {
            List<Order> orderList = LoadOrders(order.CreationDateTime);
            order.OrdersNumber = (orderList.Count > 0) ? orderList.Max(m => m.OrdersNumber) + 1 : 1;
            orderList.Add(order);

            SpitOutInfo(orderList, order.CreationDateTime);

            return true;
        }

        public void SpitOutInfo(List<Order> orders, DateTime date)
        {
            string userInput = FilePathCreated(date);

            if (orders.Count > 0)
            {


                string topLine =
                    "Order#,CustomerName,State,TaxRate,ProductType,Area,Cost/Sq.Foot,LaborCost/Sq.Foot, MaterialCost,LaborCost,Tax,Total";


                

                using (StreamWriter sw = new StreamWriter(userInput))
                {
                    sw.WriteLine(topLine);
                    foreach (var indivOrder in orders)
                    {
                        Order orderSave = indivOrder;

                        string row =
                            $"{orderSave.OrdersNumber},{orderSave.CustomersName},{orderSave.TaxData.StatesAbbreviation}," +
                            $"{orderSave.TaxData.TaxRate},{orderSave.Product.ProductsType},{orderSave.Area},{orderSave.Product.CostPerSquareFoot}," +
                            $"{orderSave.Product.LaborCostPerSquareFoot},{orderSave.MaterialCost},{orderSave.LaborCost},{orderSave.Tax},{orderSave.Total}";
                        sw.WriteLine(row);
                    }
                }
            }
            else
            {
                File.Delete(userInput);
            }
        }
    }
}
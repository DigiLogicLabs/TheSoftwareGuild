using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models.Helpers;

namespace FloorMastery.Models.TestRepos
{

    //OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total
//    1,Wise,OH,6.25,Wood,100.00,5.15,4.75,515.00,475.00,61.88,1051.88
    public class OrdersTestRepo : IOrderRepository
    {
        private static readonly List<Order> _orders = new List<Order>
        {
            new Order
            {

                //Errors once I changed the structure of my properties in the classes. TaxRate now belongs to the TaxData Class
                CreationDateTime = DateTime.Parse("06/01/2013"),
                OrdersNumber = 1,
                CustomersName = "Wise",
                StatesName = "OH",
                TaxRate = 6.25M,
                ProductsType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                Tax = 61.88M,
                Total = 1051.88M


            },
            new Order
            {
                CreationDateTime = DateTime.Parse("05/22/1995"),
                OrdersNumber = 2,
                CustomersName = "Soligny",
                StatesName = "MN",
                TaxRate = 5.25M,
                ProductsType = "Metal",
                Area = 100.00M,
                CostPerSquareFoot = 6.15M,
                LaborCostPerSquareFoot = 4.00M,
                MaterialCost = 615.00M,
                LaborCost = 400.00M,
                Tax = 53.29M,
                Total = 1068.9M
            },
            new Order
            {
                CreationDateTime = DateTime.Parse("01/01/1337"),
                OrdersNumber = 3,
                CustomersName = "Jack",
                StatesName = "WI",
                TaxRate = 7.25M,
                ProductsType = "Cheese",
                Area = 100.00M,
                CostPerSquareFoot = 6.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 615.00M,
                LaborCost = 475.00M,
                Tax = 79.03M,
                Total = 1169.03M
            },
            new Order
            {
                CreationDateTime = DateTime.Parse("04/20/2010"),
                OrdersNumber = 4,
                CustomersName = "BradPitt",
                StatesName = "CA",
                TaxRate = 8.25M,
                ProductsType = "Life",
                Area = 100.00M,
                CostPerSquareFoot = 9.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 915.00M,
                LaborCost = 475.00M,
                Tax = 114.68M,
                Total = 1504.68M
            }
            
        };

//        private static _orders _order = new _orders
//        {
//            CreationDateTime = DateTime.Parse("06/01/2013"),
//            OrdersNumber = 1,
//            CustomersName = "Wise",
//            State = "OH",
//            TaxRate = 6.25M,
//            ProductsType = "Wood",
//            Area = 100.00M,
//            CostPerSquareFoot = 5.15M,
//            LaborCostsPerSquareFoot = 4.75M,
//            MaterialCost = 515.00M,
//            LaborCost = 475.00M,
//            Tax = 61.88M,
//            Total = 1051.88M
//        };



        public Order OrdersDateAndNumber(DateTime orderDate, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public List<Order> OrdersByDateList(DateTime orderDateTime)
        {
            List<Order> result = new List<Order>();

            foreach (var order in _orders)
            {
                if (order.CreationDateTime == orderDateTime)
                {
                    result.Add(order);
                }
            }
            return result;
        }



        public bool EditOrder(Order order, DateTime orderDate, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public bool RemoveOrder(Order order)
        {
//            List<Order> orderList = OrdersByDateList(order.CreationDateTime);
            _orders.Remove(order);

//            foreach (var singleOrder in orderList)
//            {
//                if (singleOrder.OrdersNumber == order.OrdersNumber)
//                {
//
//                }
//                else
//                {
//                    string row =
//                        $"{singleOrder.OrdersNumber}{singleOrder.CustomersName}{singleOrder.StatesName}{singleOrder.TaxRate}{singleOrder.ProductsType}{singleOrder.Area}{singleOrder.CostPerSquareFoot}" +
//                        $"{singleOrder.LaborCostPerSquareFoot}{singleOrder.MaterialCost}{singleOrder.LaborCost}{singleOrder.Tax}{singleOrder.Total}";
//                    Console.WriteLine(row);
//                }
//            }



            return true;
        }

        public bool AddOrder(Order orderAdd)
        {
//            if (b)
            {
                List<Order> result = new List<Order>
                {
                    new Order
                    {
//                    CreationDateTime = 
                    }
                };
            }
            throw new NotImplementedException();
        }

        public bool SavingBrandNewOrder(Order order)
        {
           _orders.Add(order);
            return true;
        }


        public bool SaveExistingOrder(Order order)
        {
          _orders.Add(order);
            return true;
        }


        public Order LoadOrder(DateTime date, int orderNumber)
        {
            var dailyOrders = OrdersByDateList(date);
            var selectedOrder = dailyOrders.SingleOrDefault(s => s.OrdersNumber == orderNumber);
            return selectedOrder;
        }
    }
}

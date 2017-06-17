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
                CreationDateTime = DateTime.Parse("06/01/2018"),
                OrdersNumber = 1,
                CustomersName = "Wise",
                TaxData = new StateTaxData()
                {
                    StatesName = "Ohio",
                    StatesAbbreviation = "OH",
                    TaxRate = 6.25M,
                },
                Product = new ProductData()
                {
                    ProductsType = "Wood",
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M
                },
                Area = 100.00M
                },
            new Order
            {
                CreationDateTime = DateTime.Parse("05/22/1995"),
                OrdersNumber = 3,
                CustomersName = "Soligny",
                TaxData = new StateTaxData()
                {
                    StatesName = "Minnesota",
                    StatesAbbreviation = "MN",
                    TaxRate = 5.25M,
                },
                Product = new ProductData()
                {
                    ProductsType = "Metal",
                    CostPerSquareFoot = 6.15M,
                    LaborCostPerSquareFoot = 4.00M
                },


                Area = 100.00M,

            },
            new Order
            {
                CreationDateTime = DateTime.Parse("06/01/2018"),
                OrdersNumber = 2,
                CustomersName = "Jack",
                TaxData = new StateTaxData()
                {
                    StatesName = "Wisconsin",
                    StatesAbbreviation = "WI",
                    TaxRate = 7.25M,
                },
                Product = new ProductData()
                {
                    ProductsType = "Cheese",
                    CostPerSquareFoot = 6.15M,
                    LaborCostPerSquareFoot = 4.75M
                },


                Area = 100.00M,
            },
            new Order
            {
                CreationDateTime = DateTime.Parse("04/20/2018"),
                OrdersNumber = 4,
                CustomersName = "BradPitt",
                TaxData = new StateTaxData()
                {
                    StatesName = "California",
                    StatesAbbreviation = "CA",
                    TaxRate = 8.25M,
                },
                Product = new ProductData()
                {
                    ProductsType = "Life",
                    CostPerSquareFoot = 9.15M,
                    LaborCostPerSquareFoot = 4.75M
                },


                Area = 100.00M,
            }
            
        };


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
            _orders.Remove(order);

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

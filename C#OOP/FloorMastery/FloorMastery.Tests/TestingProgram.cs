using System;
using System.Collections.Generic;
using FloorMastery.Models;

namespace FloorMastery.Tests
{
    public class TestingProgram
    {
       

            private static Order _order = new Order
            {
                OrdersNumber = 1337,
                CustomersName = "Soligny",
                State = "MN",
                TaxRate = 3.5M,
                ProductsType = "Brains",
                Area = 110.00M,
                CostPerSquareFoot = 3.2M,
                LaborCostsPerSquareFoot = 2.5M,
                MaterialCost = 352M,
                LaborCost = 275M,
                Tax = 21.95M, //(MaterialCost+LaborCost) * TaxRate
                Total = 648.95M //MaterialCost + LaborCost + Tax


            };


            public Order OrdersDateAndNumber(DateTime orderDate, int orderNumber)
            {
                if (orderDate != _order.CreationDateTime)
                {
                    return null;
                }
                else if (orderNumber != _order.OrdersNumber)
                {
                    return null;
                }
                return _order;
            }

            public List<Order> OrdersByDateList(DateTime orderDateTime)
            {
                throw new NotImplementedException();
                //            orderDateTime.CompareTo(_order.CreationDateTime);

            }

            public bool EditOrder(Order order, DateTime orderDate, int orderNumber)
            {
                throw new NotImplementedException();
            }

            public bool RemoveOrder(Order order, int orderNumber)
            {
                throw new NotImplementedException();
            }

            public bool AddOrder(Order order)
            {
                throw new NotImplementedException();
            }
        
    }
}
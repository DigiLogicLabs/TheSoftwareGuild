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

            new Order( 
                DateTime.Parse("06/01/2018"),
                1, 
                "Wise", 
                new ProductData(){ProductsType = "Wood", CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M},
                new StateTaxData(){StatesName = "Ohio" , StatesAbbreviation = "OH", TaxRate = 6.25M}, 100M)
            { },
            new Order(
                    DateTime.Parse("05/22/1995"),
                    3,
                    "Soligny",
                    new ProductData(){ProductsType = "Metal", CostPerSquareFoot = 6.15M, LaborCostPerSquareFoot = 4.00M},
                    new StateTaxData(){StatesName = "Minnesota" , StatesAbbreviation = "MN", TaxRate = 5.25M}, 100M)
                { },
            new Order(
                    DateTime.Parse("06/01/2018"),
                    2,
                    "Rick",
                    new ProductData(){ProductsType = "Cheese", CostPerSquareFoot = 6.15M, LaborCostPerSquareFoot = 4.75M},
                    new StateTaxData(){StatesName = "Wisconsin" , StatesAbbreviation = "WI", TaxRate = 7.25M}, 100M)
                { },
            new Order(
                    DateTime.Parse("04/20/2018"),
                    4,
                    "BradPitt",
                    new ProductData(){ProductsType = "Life", CostPerSquareFoot = 9.15M, LaborCostPerSquareFoot = 4.75M},
                    new StateTaxData(){StatesName = "California" , StatesAbbreviation = "CA", TaxRate = 8.25M}, 100M)
                { },         

            
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

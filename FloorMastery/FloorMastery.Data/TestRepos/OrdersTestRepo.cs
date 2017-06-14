using System;
using System.Collections.Generic;
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
        private List<Order> _orders = new List<Order>
        {
            new Order
            {
               
                OrdersNumber = 1,
                CustomersName = "Wise",
                State = "OH",
                TaxRate = 6.25M,
                ProductsType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostsPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                Tax = 61.88M,
                Total = 1051.88M


            },
            new Order
            {
                OrdersNumber = 2,
                CustomersName = "Soligny",
                State = "MN",
                TaxRate = 5.25M,
                ProductsType = "Metal",
                Area = 100.00M,
                CostPerSquareFoot = 6.15M,
                LaborCostsPerSquareFoot = 4.00M,
                MaterialCost = 615.00M,
                LaborCost = 400.00M,
                Tax = 53.29M,
                Total = 1068.9M
            },
            new Order
            {
                OrdersNumber = 3,
                CustomersName = "Jack",
                State = "WI",
                TaxRate = 7.25M,
                ProductsType = "Cheese",
                Area = 100.00M,
                CostPerSquareFoot = 6.15M,
                LaborCostsPerSquareFoot = 4.75M,
                MaterialCost = 615.00M,
                LaborCost = 475.00M,
                Tax = 79.03M,
                Total = 1169.03M
            },
            new Order
            {
                OrdersNumber = 4,
                CustomersName = "BradPitt",
                State = "CA",
                TaxRate = 8.25M,
                ProductsType = "Life",
                Area = 100.00M,
                CostPerSquareFoot = 9.15M,
                LaborCostsPerSquareFoot = 4.75M,
                MaterialCost = 915.00M,
                LaborCost = 475.00M,
                Tax = 114.68M,
                Total = 1504.68M
            }
            
        };


        public OrdersTestRepo()
        {
            var orders = _orders;
            
        }

//        public OrdersTestRepo(Order order)
//        {
//            var orders = _orders;
//
//        }

        public Order OrdersDateAndNumber(DateTime orderDate, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public List<Order> OrdersByDateList(DateTime orderDateTime)
        {
            throw new NotImplementedException();
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

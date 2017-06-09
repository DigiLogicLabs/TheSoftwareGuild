using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models.Helpers;

namespace FloorMastery.Models.TestRepos
{
    public class OrdersTestRepo : IOrderRepository
    {
        private string _filePathOrders = Settings._filepathOrders;

        public OrdersTestRepo(string filePathOrders)
        {
            _filePathOrders = filePathOrders;
        }

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

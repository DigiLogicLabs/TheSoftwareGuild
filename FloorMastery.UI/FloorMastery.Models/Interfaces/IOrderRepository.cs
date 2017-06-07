using System;
using System.Collections.Generic;
using FloorMastery.Models;

namespace FloorMastery.Data.Interfaces
{
    public interface IOrderRepository
    {
        Order OrdersDateAndNumber(DateTime orderDate, int orderNumber);

        List<Order> OrdersByDateList(DateTime orderDateTime);

        bool EditOrder(Order order, DateTime orderDate, int orderNumber);

        bool RemoveOrder(Order order, int orderNumber);

        bool AddOrder(Order order);
    }
}
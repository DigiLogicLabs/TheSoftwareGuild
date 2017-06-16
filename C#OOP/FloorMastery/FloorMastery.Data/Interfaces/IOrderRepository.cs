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

        bool RemoveOrder(Order order);

        bool AddOrder(Order order);
        bool SavingBrandNewOrder(Order order);
        bool SaveExistingOrder(Order order);

        Order LoadOrder(DateTime date, int orderNumber);
    }
}
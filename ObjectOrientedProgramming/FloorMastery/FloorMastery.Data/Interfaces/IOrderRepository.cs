using System;
using System.Collections.Generic;
using FloorMastery.Models;

namespace FloorMastery.Data.Interfaces
{
    public interface IOrderRepository
    {
        Order OrdersDateAndNumber(DateTime orderDate, int orderNumber);

        List<Order> LoadOrders(DateTime orderDateTime);

        bool EditOrder(Order order, DateTime orderDate, int orderNumber);

        bool RemoveOrder(Order order);

        
        bool SavingBrandNewOrder(Order order);
        bool SaveExistingOrder(Order updatedOrder);



        Order LoadOrder(DateTime date, int orderNumber);
    }
}
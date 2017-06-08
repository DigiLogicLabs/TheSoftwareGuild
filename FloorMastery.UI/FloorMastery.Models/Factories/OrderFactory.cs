using System;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using FloorMastery.Data.Interfaces;
using FloorMastery.Data.Repos;

namespace FloorMastery.Data.Factories
{
    public class OrderFactory
    {
        public static IOrderRepository CreateOrderRepository()
        {
           // IOrderRepository repository;

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    break;
                    
                case "Prod":
//                    return new OrdersManager;
                default:
                    throw new Exception("Mode doesn't exist.");
            }
//            return repository;
            throw new NotImplementedException();
        }
        
    }
}
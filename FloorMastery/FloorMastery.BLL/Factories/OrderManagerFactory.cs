using System;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using FloorMastery.Data.Interfaces;
using FloorMastery.Data.Repos;
using FloorMastery.Models.Helpers;
using FloorMastery.Models.TestRepos;


namespace FloorMastery.BLL.Factories
{
    public class OrderManagerFactory
    {

        public static OrderManager Create()
        {
            OrderManager orderMan = null;
             

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            

            switch (mode)
            {
                case "Test":
                   orderMan = new OrderManager(new OrdersTestRepo());
                    break;

                case "Prod":
                    orderMan = new OrderManager(new OrdersProdRepo(Settings._filepathOrders));
                    break;

                    default:
                    throw new Exception("Mode doesn't exist.");
            }
            return orderMan;

        }

    }
}
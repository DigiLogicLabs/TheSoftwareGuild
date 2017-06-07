using System;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using FloorMastery.Data.Interfaces;
using FloorMastery.Data.Repos;

namespace FloorMastery.Data.Factories
{
    public class OrderFactory
    {
        public const string _filepathProducts = @"C:\Users\Csharpener\Desktop\Repos\conner-soligny-individual-work\FloorMastery\results\Products.txt";
        public const string _filepathTaxes = @"C:\Users\Csharpener\Desktop\Repos\conner-soligny-individual-work\FloorMastery\results\Taxes.txt";
        public const string _filepathOrders = @"C:\Users\Csharpener\Desktop\Repos\conner-soligny-individual-work\FloorMastery\results";


        public static IOrderRepository CreateOrderRepository()
        {
           // IOrderRepository repository;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "PROD":
//                    repository = new OrdersTestRepo();
                    break;
                default:
                    throw new Exception("Mode doesn't exist.");
            }
//            return repository;
            throw new NotImplementedException();
        }
        
    }
}
using System;
using System.Configuration;
using FloorMastery.Data.Repos;
using FloorMastery.Models.Helpers;
using FloorMastery.Models.TestRepos;

namespace FloorMastery.BLL.Factories
{


    public class ProductFactory
    {

        public static ProductManager CreateOrderRepository()
        {
            ProductManager productMan = null;


            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    productMan = new ProductManager(new ProductsTestRepo(Settings._filepathProducts));
                    break;

                case "Prod":
                    productMan = new ProductManager(new ProductsProdRepo(Settings._filepathProducts));
                    break;

                default:
                    throw new Exception("Mode doesn't exist.");
            }
            return productMan;

        }

    }

}
using System;
using System.Configuration;
using FloorMastery.Data.Repos;
using FloorMastery.Models.Helpers;
using FloorMastery.Models.TestRepos;

namespace FloorMastery.BLL.Factories
{


    public class ProductFactory
    {

        public static ProductManager Create()
        {
           


            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                throw new Exception("Mode value in app config isn't valid");

                case "Prod":
                    return new ProductManager(new ProductsProdRepo());
                default:
                    throw new Exception("Mode doesn't exist.");
            }

        }

    }

}
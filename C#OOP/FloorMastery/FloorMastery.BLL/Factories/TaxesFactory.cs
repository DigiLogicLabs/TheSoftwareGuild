using System;
using System.Configuration;
using FloorMastery.Data.Repos;
using FloorMastery.Models.Helpers;
using FloorMastery.Models.TestRepos;

namespace FloorMastery.BLL.Factories
{
    public class TaxesFactory
    {

        public static TaxesManager Create()
        {
           


            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    throw new Exception("Mode value in app config is not valid");

                case "Prod":
                return new TaxesManager(new TaxesProdRepo());
                default:
                    throw new Exception("Mode doesn't exist.");
            }

        }
    }
}
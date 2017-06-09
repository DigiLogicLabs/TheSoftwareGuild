using System;
using System.Configuration;
using FloorMastery.Data.Repos;
using FloorMastery.Models.Helpers;
using FloorMastery.Models.TestRepos;

namespace FloorMastery.BLL.Factories
{
    public class TaxesFactory
    {

        public static TaxesManager CreateOrderRepository()
        {
            TaxesManager taxesMan = null;


            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    taxesMan = new TaxesManager(new TaxesTestRepo(Settings._filepathTaxes));
                    break;

                case "Prod":
                    taxesMan = new TaxesManager(new TaxesProdRepo(Settings._filepathTaxes));
                    break;

                default:
                    throw new Exception("Mode doesn't exist.");
            }
            return taxesMan;

        }
    }
}
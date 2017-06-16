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
            TaxesManager taxesMan = null;


            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    taxesMan= new TaxesManager( new TaxesTestRepo());
                    break;
                case "Prod":
                taxesMan = new TaxesManager(new TaxesProdRepo());
                break;
                    
                    
            }
            return taxesMan;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models.Helpers;

namespace FloorMastery.Models.TestRepos
{
//    StateAbbreviation,StateName,TaxRate
//    OH, Ohio,6.25
//    PA,Pennsylvania,6.75
//    MI,Michigan,5.75
//    IN,Indiana,6.00


    public class TaxesTestRepo : ITaxesRepository
    {
        private static readonly List<StateTaxData> StateTaxs = new List<StateTaxData>()
        {
            new StateTaxData
            {
                StatesAbbreviation = "OH",
                StatesName = "Ohio",
                TaxRate = 6.25M
            },
            new StateTaxData
            {
                StatesAbbreviation = "PA",
                StatesName = "Pennsylvania",
                TaxRate = 6.75M
            },
            new StateTaxData
            {
                StatesAbbreviation = "MI",
                StatesName = "Michigan",
                TaxRate = 5.75M
            },
            new StateTaxData
            {
                StatesAbbreviation = "IN",
                StatesName = "Indiana",
                TaxRate = 6.00M

            }
            
        };
        public TaxesTestRepo()
        {

           
        }
        public StateTaxData TheState(string stateInput)
        {
            
            List<StateTaxData> result = new List<StateTaxData>();

            foreach (var taxData in StateTaxs)
            {
                if (taxData.StatesName == stateInput)
                {
                    result.Add(taxData);
                }
            }
            return new StateTaxData();
        }

        public List<StateTaxData> List()
        {
            throw new NotImplementedException();
        }
    }
}

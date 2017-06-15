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
        private static readonly List<StateTax> StateTaxs = new List<StateTax>()
        {
            new StateTax
            {
                StatesAbbreviation = "OH",
                StatesName = "Ohio",
                TaxRate = 6.25M
            },
            new StateTax
            {
                StatesAbbreviation = "PA",
                StatesName = "Pennsylvania",
                TaxRate = 6.75M
            },
            new StateTax
            {
                StatesAbbreviation = "MI",
                StatesName = "Michigan",
                TaxRate = 5.75M
            },
            new StateTax
            {
                StatesAbbreviation = "IN",
                StatesName = "Indiana",
                TaxRate = 6.00M

            }
            
        };
        public TaxesTestRepo()
        {

           
        }
        public StateTax TheState(string stateInput)
        {
            throw new NotImplementedException();
        }
    }
}

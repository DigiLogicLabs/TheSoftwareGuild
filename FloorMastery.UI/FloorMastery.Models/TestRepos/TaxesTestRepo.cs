using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models.Helpers;

namespace FloorMastery.Models.TestRepos
{
    public class TaxesTestRepo : ITaxesRepository
    {
        private string _filepathTaxes = Settings._filepathTaxes;


        public TaxesTestRepo(string filePathTaxes)
        {

            _filepathTaxes = filePathTaxes;
        }

        public StateInfo TheState(string stateInput)
        {
            throw new NotImplementedException();
        }
    }
}

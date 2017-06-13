using FloorMastery.Data.Interfaces;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;

namespace FloorMastery.Data.Repos
{
    public class TaxesProdRepo : ITaxesRepository
    {
        private string _filepathTaxes = Settings._filepathTaxes;


        public TaxesProdRepo(string filePathTaxes)
        {

            _filepathTaxes = filePathTaxes;
        }

        public StateInfo TheState(string stateInput)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Data.Interfaces;
using FloorMastery.Data.Repos;
using FloorMastery.Models;
using FloorMastery.Models.Responses;

namespace FloorMastery.BLL
{
    public class TaxesManager
    {
        public ITaxesRepository _stateTaxRepo;

        public TaxesManager(ITaxesRepository stateTaxRepo)
        {
            _stateTaxRepo = stateTaxRepo;
        }

        public StateTaxData TheState(string stateInput)
        {
            throw new System.NotImplementedException();
        }

        public FindingStateResponse StateTaxDate(string state)
        {
            FindingStateResponse response = new FindingStateResponse();

            response.StateTaxData = _stateTaxRepo.TheState(state);

            if (response.StateTaxData == null)
            {
                response.Success = false;
                response.Message = $"{state} not valid";

            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public List<StateTaxData> GetAllTaxInfo()
        {
            return _stateTaxRepo.List();
        }
    }
}

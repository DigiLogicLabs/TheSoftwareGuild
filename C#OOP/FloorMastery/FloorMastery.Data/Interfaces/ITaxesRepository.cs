using System.Collections.Generic;
using FloorMastery.Models;

namespace FloorMastery.Data.Interfaces
{
    public interface ITaxesRepository
    {
        StateTaxData TheState(string stateInput);

        List<StateTaxData> LoadStateTaxData();
    }
}
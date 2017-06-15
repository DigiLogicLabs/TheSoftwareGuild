using FloorMastery.Models;

namespace FloorMastery.Data.Interfaces
{
    public interface ITaxesRepository
    {
        StateTaxData TheState(string stateInput);
    }
}
using FloorMastery.Models;

namespace FloorMastery.Data.Interfaces
{
    public interface ITaxesRepository
    {
        StateTax TheState(string stateInput);
    }
}
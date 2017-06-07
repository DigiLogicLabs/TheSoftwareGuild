using FloorMastery.Models;

namespace FloorMastery.Data.Interfaces
{
    public interface ITaxesRepository
    {
        StateInfo TheState(string stateInput);
    }
}
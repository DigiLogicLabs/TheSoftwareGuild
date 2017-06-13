using FloorMastery.Models;

namespace FloorMastery.Data.Interfaces
{
    public interface IProductRepository
    {
        Order ProductsType(string productType);

    }
}
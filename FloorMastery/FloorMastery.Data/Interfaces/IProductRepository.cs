using System.Collections.Generic;
using FloorMastery.Models;

namespace FloorMastery.Data.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductByName(string productType);

        List<Product> List();

    }
}
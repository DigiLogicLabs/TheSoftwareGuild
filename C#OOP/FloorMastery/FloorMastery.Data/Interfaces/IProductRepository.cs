using System.Collections.Generic;
using FloorMastery.Models;

namespace FloorMastery.Data.Interfaces
{
    public interface IProductRepository
    {
        ProductData GetProductDataForType(string productType);

        List<ProductData> LoadProductData();

    }
}
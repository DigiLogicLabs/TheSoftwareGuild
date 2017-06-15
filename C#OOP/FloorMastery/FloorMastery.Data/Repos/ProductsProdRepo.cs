using System;
using System.Collections.Generic;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;

namespace FloorMastery.Data.Repos
{
    public class ProductsProdRepo : IProductRepository
    {
        private string _filePathProducts = Settings._filepathProducts;

        public ProductsProdRepo(string filePathProducts)
        {
            _filePathProducts = filePathProducts;
        }

        public Order ProductsType(string productType)
        {
            throw new System.NotImplementedException();
        }


        public ProductData GetProductDataForType(string productType)
        {
            throw new NotImplementedException();
        }

        public List<ProductData> List()
        {
            throw new System.NotImplementedException();
        }
    }
}
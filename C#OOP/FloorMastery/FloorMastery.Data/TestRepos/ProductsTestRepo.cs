using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models.Helpers;

namespace FloorMastery.Models.TestRepos
{
    public class ProductsTestRepo : IProductRepository
    {
//        ProductType,CostPerSquareFoot,LaborCostPerSquareFoot
//            Carpet,2.25,2.10
//        Laminate,1.75,2.10
//        Tile,3.50,4.15
//        Wood,5.15,4.75

        private static readonly List<ProductData> Products = new List<ProductData>()
        {
            new ProductData
            {
                ProductsType = "Wood",
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M

            },
            new ProductData
            {
                ProductsType = "Tile",
                CostPerSquareFoot = 3.5M,
                LaborCostPerSquareFoot = 4.15M
            },
            new ProductData
            {
                ProductsType = "Laminate",
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M
            },
            new ProductData
            {
                ProductsType = "Carpet",
                CostPerSquareFoot = 2.25M,
                LaborCostPerSquareFoot = 2.10M
            }

        };   
        
        public ProductData GetProductDataForType(string productType)
        {
            return Products.SingleOrDefault(m => m.ProductsType == productType);
        }

        public List<ProductData> GetAllProducts()
        {
            return Products;
        }
    }
}

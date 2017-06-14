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

        private List<Product> _products = new List<Product>()
        {
            new Product
            {
                ProductsType = "Wood",
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M

            },
            new Product
            {
                ProductsType = "Tile",
                CostPerSquareFoot = 3.5M,
                LaborCostPerSquareFoot = 4.15M
            },
            new Product
            {
                ProductsType = "Laminate",
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M
            },
            new Product
            {
                ProductsType = "Carpet",
                CostPerSquareFoot = 2.25M,
                LaborCostPerSquareFoot = 2.10M
            }
            
            
   
        };








              
        public Product GetProductByName(string productType)
        {
            throw new NotImplementedException();
        }

        public List<Product> List()
        {
            throw new NotImplementedException();
        }
    }
}

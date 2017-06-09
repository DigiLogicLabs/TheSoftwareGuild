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
        private string _filepathProducts = Settings._filepathProducts;


        public ProductsTestRepo(string filePathProducts)
        {

            _filepathProducts = filePathProducts;
        }
        public Order ProductsType(string productType)
        {
            throw new NotImplementedException();
        }
    }
}

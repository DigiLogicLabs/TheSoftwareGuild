using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Data.Interfaces;

namespace FloorMastery.BLL
{
    public class ProductManager
    {
        //factory method returns one of these
        private IProductRepository _productRepository = null;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Data.Interfaces;
using FloorMastery.Data.Repos;
using FloorMastery.Models.Responses;

namespace FloorMastery.BLL
{
    public class ProductManager
    {
        
        private IProductRepository _productTypeRepo;

        public ProductManager(IProductRepository productRepo)
        {
            _productTypeRepo = productRepo;
        }

        public FindingProductTypeResponse ProductTypeData(string productType)
        {
            FindingProductTypeResponse response = new FindingProductTypeResponse();

            response.ProductData = _productTypeRepo.GetProductDataForType(productType);
            if (response.ProductData == null)
            {
                response.Success = false;
                response.Message = $"{productType} is not valid";

            }
            else
            {
                response.Success = true;
            }
            return response;
        }

    }
}

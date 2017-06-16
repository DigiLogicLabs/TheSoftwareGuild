using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models;
using FloorMastery.Models.Helpers;

namespace FloorMastery.Data.Repos
{
    public class ProductsProdRepo
    {
        private Dictionary<string, ProductData> _productDictionary;

        public const string _productPath = @"C:\Users\Csharpener\Desktop\Repos\conner-soligny-individual-work\C#OOP\FloorMastery\TextFiles\Products.txt";

        public ProductsProdRepo()
        {
            _productDictionary = LoadProductData().ToDictionary(l => l.ProductsType);
        }

        private List<ProductData> LoadProductData()
        {
            List<ProductData> productDataList = new List<ProductData>();

            using (StreamReader sr = new StreamReader(_productPath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    ProductData productData = new ProductData();

                    string[] columns = line.Split(',');

                    productData.ProductsType = columns[0];
                    productData.CostPerSquareFoot = decimal.Parse(columns[1]);
                    productData.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                    productDataList.Add(productData);
                }
            }
            return productDataList;
        }
        public Order ProductsType(string productType)
        {
            throw new System.NotImplementedException();
        }


        public ProductData GetProductDataForType(string productType)
        {
            if (_productDictionary.ContainsKey(productType))
            {
                return _productDictionary[productType];
            }
            else
            {
                return null;
            }
        }

        public List<ProductData> List()
        {
            throw new System.NotImplementedException();
        }
    }
}
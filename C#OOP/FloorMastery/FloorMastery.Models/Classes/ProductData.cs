namespace FloorMastery.Models
{
    public class ProductData
    {
        public string ProductsType { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public override string ToString()
        {
            return ProductsType;
        }
    }
}
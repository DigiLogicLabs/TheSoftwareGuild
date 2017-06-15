using System;

namespace FloorMastery.Models
{
    public class Order
    {
        public DateTime CreationDateTime { get; set; }
        public int OrdersNumber { get; set; }
        public string CustomersName { get; set; }

        public string StateAbbreviation { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }

        public string ProductsType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostsPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

       
    }
}
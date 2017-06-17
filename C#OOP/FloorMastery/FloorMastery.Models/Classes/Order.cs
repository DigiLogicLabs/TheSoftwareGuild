using System;

namespace FloorMastery.Models
{
    public class Order
    {


        public DateTime CreationDateTime { get; set; }
        public int OrdersNumber { get; set; }
        public string CustomersName { get; set; }


        public ProductData Product { get; set; }
        public StateTaxData TaxData { get; set; }
        public decimal Area { get; set; }

        public Order()
        {
            
        }

        public Order(
            DateTime date,
            int ordernumber,
            string customername,
            ProductData proddata,
            StateTaxData stateTax,
            decimal area)
        {
            CreationDateTime = date;
            OrdersNumber = ordernumber;
            CustomersName = customername;
            Product = proddata;
            TaxData = stateTax;
            Area = area;
        }

        public decimal MaterialCost => Area * Product.CostPerSquareFoot;
        public decimal LaborCost => Area * Product.LaborCostPerSquareFoot;
        public decimal Tax => ((MaterialCost + LaborCost) * (Tax / 100));
        public decimal Total => (MaterialCost + LaborCost + Tax);


    }
}
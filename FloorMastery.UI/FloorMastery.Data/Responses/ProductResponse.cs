using FloorMastery.Models.Responses;
using System.Collections.Generic;


namespace FloorMastery.Models.Responses
{
    public class ProductResponse : Response
    {
        public Order ProductInformation { get; set; }
        public List<Order> ProductList { get; set; }
        public decimal ProductDecimal { get; set; }
    }
}
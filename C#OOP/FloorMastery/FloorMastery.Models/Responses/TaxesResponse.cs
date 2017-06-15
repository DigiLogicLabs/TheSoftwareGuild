using FloorMastery.Models.Responses;
using System.Collections.Generic;


namespace FloorMastery.Models.Responses
{
    public class TaxesResponse : Response
    {
        public StateTax TaxTax { get; set; }
        public List<Order> TaxList { get; set; }
    }
}
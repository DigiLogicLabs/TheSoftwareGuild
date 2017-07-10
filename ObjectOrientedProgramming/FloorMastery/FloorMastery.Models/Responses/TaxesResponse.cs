using FloorMastery.Models.Responses;
using System.Collections.Generic;


namespace FloorMastery.Models.Responses
{
    public class TaxesResponse : Response
    {
        public StateTaxData TaxDataTaxData { get; set; }
        public List<Order> TaxList { get; set; }
    }
}
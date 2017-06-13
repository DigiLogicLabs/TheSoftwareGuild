using FloorMastery.Models.Responses;
using System.Collections.Generic;


namespace FloorMastery.Models.Responses
{
    public class DisplayOrdersResponse : Response
    {     
        public List<Order> Orders { get; set; }
    }
}
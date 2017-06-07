using FloorMastery.Models.Responses;
using System.Collections.Generic;


namespace FloorMastery.Models.Responses
{
    public class OrderResponse : Response
    {
        public Order OrdersInfo { get; set; }
        public List<Order> OrderList { get; set; }
    }
}
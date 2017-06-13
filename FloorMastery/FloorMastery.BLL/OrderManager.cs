using System;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models.Responses;

namespace FloorMastery.BLL
{
    public class OrderManager
    {
        //factory method returns one of these
        private IOrderRepository _orderRepository = null;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public DisplayOrdersResponse GetOrdersFromDate(DateTime orderDateInput)
        {
            DisplayOrdersResponse response = new DisplayOrdersResponse();

            response.Orders = _orderRepository.OrdersByDateList(orderDateInput);

            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = $"{orderDateInput} isn't valid";
                
            }


            return response;

        }
    }
}
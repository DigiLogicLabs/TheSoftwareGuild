using System;
using System.Collections.Generic;
using FloorMastery.Data.Interfaces;
using FloorMastery.Models;
using FloorMastery.Models.Responses;
using FloorMastery.Models.TestRepos;

namespace FloorMastery.BLL
{
    public class OrderManager
    {
       //Have one of each repo inside of it, Menu should hold OrderManager in the broad scope.

        private  IOrderRepository _orderRepository;
        
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public DisplayOrdersResponse LookUpAccount(DateTime orderDateInput)
        {
            DisplayOrdersResponse response = new DisplayOrdersResponse();

            response.Orders = _orderRepository.OrdersByDateList(orderDateInput);

            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = $"{orderDateInput} isn't valid";
                
            }
            else
            {
                response.Success = true;
            }
            return response;
        }



        public AddOrderResponse AddOrder(Order order)
        {
            //Will need to take the Product & State to look up the full product and tax objects -- then we can do calculations on them

            AddOrderResponse response = new AddOrderResponse();
            if (response.Success == false)
            {
                response.Message = "Can't add the Order: ";
            }
            else
            {
                response.order = order;
                    _orderRepository.AddOrder(order);
            }
           

            return new AddOrderResponse();
        }
    }

     
}
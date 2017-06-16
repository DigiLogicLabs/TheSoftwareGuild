﻿using System;
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
            //Will need to take the ProductData & State to look up the full productData and tax objects -- then we can do calculations on them

            AddOrderResponse response = new AddOrderResponse();
            if (response.Success == false)
            {
                response.Message = "Can't add the Order: ";
            }
            else
            {
                response.Order = order;
                    _orderRepository.AddOrder(order);
            }
           

            return new AddOrderResponse();
        }

        public AddOrderResponse AccountByNumberAndDate(DateTime date, int orderNumber)
        {
            AddOrderResponse response = new AddOrderResponse();

            response.Order = _orderRepository.LoadOrder(date, orderNumber);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"{date} is not a valid order";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public AddOrderResponse SaveExistingOrder(Order order)
        {
            AddOrderResponse response = new AddOrderResponse();

            response.Order = order;
            response.Success = _orderRepository.SaveExistingOrder(order);

            return response;
        }
        public AddOrderResponse SaveNewOrder(Order order)
        {
            AddOrderResponse response = new AddOrderResponse();

            response.Order = order;
            response.Success = _orderRepository.SavingBrandNewOrder(order);

            return response;
        }

        public DeleteOrderResponse DeleteOrder(Order order)
        {
            DeleteOrderResponse response = new DeleteOrderResponse();

            response.Order = order;
            if (response.Order ==null)
            {
                response.Success = false;
                response.Message = $"{order} is not a valid order!";
            }
            else
            {
                response.Success = true;
                response.Success = _orderRepository.RemoveOrder(order);
            }
            return response;
        }

    }

     
}
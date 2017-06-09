using FloorMastery.Data.Interfaces;

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
    }
}
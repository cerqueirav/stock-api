using stock_api.Models;

namespace stock_api.Services
{
    public interface IOrderService
    {
        public IEnumerable<Order> GetOrderList();
        public Order? GetOrderById(int id);
        public Order AddOrder(Order Order);
        public Order UpdateOrder(Order Order);
        public bool DeleteOrder(int Id);
    }
}

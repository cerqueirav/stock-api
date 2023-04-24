using stock_api.Models;

namespace stock_api.Services
{
    public interface IOrderService
    {
        public IEnumerable<Order> GetAll();
        public Order? GetById(int id);
        public Order Create(Order Order);
        public Order Update(int id, Order Order);
        public bool Delete(int id);
    }
}

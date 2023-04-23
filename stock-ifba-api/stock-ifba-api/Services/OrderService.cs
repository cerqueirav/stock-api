using stock_api.Context;
using stock_api.Models;

namespace stock_api.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderContext _dbContext;
        public OrderService(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Order> GetOrderList()
        {
            return _dbContext.Orders.ToList();
        }
        public Order? GetOrderById(int id)
        {
            return _dbContext.Orders.Where(x => x.Id == id).FirstOrDefault();
        }
        public Order AddOrder(Order Order)
        {
            var result = _dbContext.Orders.Add(Order);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public Order UpdateOrder(Order Order)
        {
            var result = _dbContext.Orders.Update(Order);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteOrder(int Id)
        {
            var filteredData = _dbContext.Orders.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}

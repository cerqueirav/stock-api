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

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order? GetById(int id)
        {
            return _dbContext.Orders.Where(x => x.Id == id).FirstOrDefault();
        }

        public Order Create(Order Order)
        {
            var result = _dbContext.Orders.Add(Order);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public Order Update(int id, Order Order)
        {
            var order = _dbContext.Orders.Where(x => x.Id == id).FirstOrDefault();
            var result = _dbContext.Orders.Update(Order);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool Delete(int id)
        {
            var order = _dbContext.Orders.Where(x => x.Id == id).FirstOrDefault();
            var result = _dbContext.Remove(order);
            _dbContext.SaveChanges();
            return result is not null;
        }
    }
}

using stock_api.Context;
using stock_api.Models;

namespace stock_api.Services
{
    public class OrderConfirmedService : IOrderConfirmedService
    {
        private readonly OrderContext _dbContext;
        public OrderConfirmedService(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<OrderConfirmed> GetAll()
        {
            return _dbContext.OrdersConfirmed.ToList();
        }

        public OrderConfirmed? GetById(int id)
        {
            return _dbContext.OrdersConfirmed.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

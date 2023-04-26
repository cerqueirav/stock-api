
using stock_api.Models;

namespace stock_api.Services
{
    public interface IOrderConfirmedService
    {
        public IEnumerable<OrderConfirmed> GetAll();
        public OrderConfirmed? GetById(int id);
    }
}

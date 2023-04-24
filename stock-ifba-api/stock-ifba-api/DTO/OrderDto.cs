using stock_api.Models;

namespace stock_api.DTO
{
    public class OrderDto
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public int ClientId { get; set; }
        public int SellerId { get; set; }

        public Order Convert()
        {
            return new Order
            {
                Description = this.Description,
                Amount = this.Amount,
                ClientId = this.ClientId,
                SellerId= this.SellerId,
                StateId = 1,
                CreationDate = DateTime.Now,
            };
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_api.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set;}
        public string Description { get; set; }
        public double Amount { get; set; }
        public int ClientId { get; set; }
        public DateTime CreationDate { get; set; }
        public int SellerId { get; set; }
    }
}

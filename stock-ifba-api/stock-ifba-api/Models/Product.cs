using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_api.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set;}
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }
}

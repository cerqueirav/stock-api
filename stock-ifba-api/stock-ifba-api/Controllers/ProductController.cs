using Microsoft.AspNetCore.Mvc;
using stock_api.Models;
using stock_api.RabbitMQ;
using stock_api.Services;

namespace stock_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IRabitMQProducer _rabitMQProducer;
        public ProductController(IProductService _productService, IRabitMQProducer rabitMQProducer)
        {
            productService = _productService;
            _rabitMQProducer = rabitMQProducer;
        }
        [HttpGet("Listar")]
        public IEnumerable<Product> ProductList()
        {
            var productList = productService.GetProductList();
            return productList;
        }
        [HttpGet("ListarPorId")]
        public Product GetProductById(int Id)
        {
            return productService.GetProductById(Id);
        }
        [HttpPost("Cadastrar")]
        public Product AddProduct(Product product)
        {
            var productData = productService.AddProduct(product);
            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabitMQProducer.SendProductMessage(productData);
            return productData;
        }
        [HttpPut("Atualizar")]
        public Product UpdateProduct(Product product)
        {
            return productService.UpdateProduct(product);
        }
        [HttpDelete("Deletar")]
        public bool DeleteProduct(int Id)
        {
            return productService.DeleteProduct(Id);
        }
    }
}
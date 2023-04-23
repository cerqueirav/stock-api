using Microsoft.AspNetCore.Mvc;
using stock_api.Models;
using stock_api.RabbitMQ;
using stock_api.Services;

namespace stock_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService OrderService;
        private readonly IRabitMQProducer _rabitMQProducer;
        public OrderController(IOrderService _OrderService, IRabitMQProducer rabitMQProducer)
        {
            OrderService = _OrderService;
            _rabitMQProducer = rabitMQProducer;
        }
        [HttpGet("Listar")]
        public IEnumerable<Order> OrderList()
        {
            var OrderList = OrderService.GetOrderList();
            return OrderList;
        }
        [HttpGet("ListarPorId")]
        public Order GetOrderById(int Id)
        {
            return OrderService.GetOrderById(Id);
        }
        [HttpPost("Cadastrar")]
        public Order AddOrder(Order Order)
        {
            var OrderData = OrderService.AddOrder(Order);
            //send the inserted Order data to the queue and consumer will listening this data from queue
            _rabitMQProducer.SendOrderMessage(OrderData);
            return OrderData;
        }
        [HttpPut("Atualizar")]
        public Order UpdateOrder(Order Order)
        {
            return OrderService.UpdateOrder(Order);
        }
        [HttpDelete("Deletar")]
        public bool DeleteOrder(int Id)
        {
            return OrderService.DeleteOrder(Id);
        }
    }
}
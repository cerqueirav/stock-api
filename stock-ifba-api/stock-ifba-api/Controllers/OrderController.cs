using Microsoft.AspNetCore.Mvc;
using stock_api.DTO;
using stock_api.Models;
using stock_api.RabbitMQ;
using stock_api.Services;

namespace stock_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IRabitMQProducer _rabitMQProducer;
        public OrderController(IOrderService orderService, IRabitMQProducer rabitMQProducer)
        {
            _orderService = orderService;
            _rabitMQProducer = rabitMQProducer;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var orderList = _orderService.GetAll();

                if (orderList is null)
                    return NotFound("Nenhum pedido encontrado!");

                return Ok(new { orders = orderList });
            }
            catch(Exception ex)
            {
                return BadRequest("Ocorreu um erro ao realizar a consulta!" + ex);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var order = _orderService.GetById(id);

                if (order is null)
                    return NotFound("O pedido não foi localizado!");

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao realizar a consulta!" + ex);
            }
        }

        [HttpPost]
        public IActionResult Create(OrderDto orderDto)
        {
            try
            {
                var orderData = _orderService.Create(orderDto.Convert());

                // Etapa de inserção na Fila do Rabbit MQ
                _rabitMQProducer.SendOrderMessage(orderData);

                return Ok(orderData);
            }
            catch(Exception ex)
            {
                return BadRequest("Não foi possível cadastrar o pedido!" + ex);
            } 
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Order Order)
        {
            try
            {
                var order = _orderService.Update(id, Order);

                return Ok(order);
            }
            catch(Exception ex)
            {
                return BadRequest("Não foi possível editar o pedido!" + ex);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try{
                var orderDeleted = _orderService.Delete(id);

                return Ok(orderDeleted);
            }
            catch(Exception ex)
            {
                return BadRequest("Não foi possível excluir o pedido!" + ex);
            }
        }
    }
}
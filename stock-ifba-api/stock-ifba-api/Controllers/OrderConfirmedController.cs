using Microsoft.AspNetCore.Mvc;
using stock_api.Services;

namespace stock_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderConfirmedController : ControllerBase
    {
        private readonly IOrderConfirmedService _orderConfirmedService;
        public OrderConfirmedController(IOrderConfirmedService orderConfirmedService)
        {
            _orderConfirmedService = orderConfirmedService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var orderList = _orderConfirmedService.GetAll();

                if (orderList is null)
                    return NotFound("Nenhum pedido confirmado encontrado!");

                return Ok(new { ordersConfirmed = orderList });
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
                var order = _orderConfirmedService.GetById(id);

                if (order is null)
                    return NotFound("O pedido não foi localizado!");

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao realizar a consulta!" + ex);
            }
        }
    }
}
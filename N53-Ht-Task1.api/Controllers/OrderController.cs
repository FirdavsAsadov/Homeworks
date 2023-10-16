using Microsoft.AspNetCore.Mvc;
using N53_Ht_Task1.api.Interfeys;
using N53_Ht_Task1.api.Models;

namespace N53_Ht_Task1.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService  _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _orderService.Get(order => true);
            return result.Any() ? Ok(result) : BadRequest();
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateOrder(Order order)
        {
            var result = _orderService.CreateAsync(order);
            return Ok(result);
        }
    }
}

using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [Route("api/user/{userId}/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderListItemDto>>> GetList([FromRoute] Guid userId)
        {
            var orders = await _service.GetListAsync(userId);

            return Ok(orders);
        }

        [HttpGet("{orderID}")]
        public async Task<ActionResult<OrderDetailsDto>> Get([FromRoute] Guid userId, [FromRoute] Guid orderID)
        {
            var orders = await _service.Get(userId, orderID);

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromRoute] Guid userId, [FromBody] OrderCreateDto dto)
        {
            var newOrderID = await _service.CreateOrderAsync(userId, dto.Tickets);

            return Created($"/order/{newOrderID}", newOrderID);
        }

        [HttpGet("{orderID}/payment")]
        public async Task<ActionResult<PaymentOrderDto>> GetForPaymentAsync([FromRoute] Guid userId, [FromRoute] Guid orderID)
        {
            PaymentOrderDto dto = await _service.GetPaymentOrderAsync(userId, orderID);

            return Ok(dto);
        }

        [HttpPost("{orderID}/payment")]
        public async Task<ActionResult> MakePaymentAsync([FromRoute] Guid userId, [FromBody] CreatePaymentDto createPaymentDto)
        {
            await _service.MakePaymentAsync(userId, createPaymentDto);
            return Ok();
        }
    }
}


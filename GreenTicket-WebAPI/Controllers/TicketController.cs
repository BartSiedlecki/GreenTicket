using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [Route("api/user/{userId}/order/{orderId}/ticket")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("print")]
        public async Task<ActionResult<OrderDetailsDto>> GetTicket([FromRoute] Guid userId, [FromRoute] Guid orderId)
        {
            var ticketPdf = await _ticketService.GetOrderTicketsAsync(userId, orderId);

            return File(ticketPdf, "application/pdf");
        }

        [HttpGet("{ticketId}/print")]
        public async Task<ActionResult<OrderDetailsDto>> GetOrderTickets([FromRoute] Guid userId, [FromRoute] Guid orderId, [FromRoute] Guid ticketId)
        {
            var ticketPdf = await _ticketService.GetTicketAsync(userId, orderId, ticketId);

            return File(ticketPdf, "application/pdf");
        }

    }
}

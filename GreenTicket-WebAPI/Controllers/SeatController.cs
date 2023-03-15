using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/event/{eventId}/section/{sectionId}/seat/")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _service;

        public SeatController(ISeatService service)
        {
            _service = service;
        }

        [HttpPut("{seatId}/reservation")]
        public async Task<ActionResult> ReserveSeat([FromRoute] int eventId, [FromRoute] int sectionId, [FromRoute] string seatId, [FromQuery] string session)
        {
            await _service.ReserveTicketAsync(eventId, sectionId, seatId, session);
            return NoContent();
        }

        [HttpPut("{seatId}/reservation/cancel")]
        public async Task<ActionResult> CancelReservation([FromRoute] int eventId, [FromRoute] int sectionId, [FromRoute] string seatId, [FromQuery] string session)
        {
            await _service.CancelTicketReservationAsync(eventId, sectionId, seatId, session);
            return NoContent();
        }
    }
}

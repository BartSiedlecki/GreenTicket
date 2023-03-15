using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/event")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<EventPageDto>> Get([FromQuery] QueryParamsFilter queryParams)
        {
            var events = await _service.GetFilteredEventsAsync(queryParams);
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventPageDto>> Get([FromRoute] int id)
        {
            var eventModel = await _service.GetEventPageModelAsync(id);
            return Ok(eventModel);
        }

        [HttpGet("navigation/search")]
        public async Task<ActionResult<IEnumerable<EventNavigationSearchResultItemDto>>> NavigationSearchAsync([FromQuery] string phrase)
        {
            var events = await _service.NavigationSearchAsync(phrase);
            return Ok(events);
        }

        [HttpGet("carousel")]
        public async Task<ActionResult<IEnumerable<EventCarouselDto>>> GetCarouselsAsync([FromQuery] int qty)
        {
            var carousels = await _service.GetCarouselModelsAsync(qty);
            
            return Ok(carousels);
        }

        [HttpGet("card/newest")]
        public async Task<ActionResult<IEnumerable<EventCardDto>>> GetEventCardsAsync([FromQuery] CardCategory category, [FromQuery] int qty)
        {
            var events = await _service.GetCardsAsync(category, qty);
            return Ok(events);
        }
    }
}

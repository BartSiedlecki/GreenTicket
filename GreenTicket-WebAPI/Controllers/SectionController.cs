using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/event/{eventId}/section")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _service;

        public SectionController(ISectionService service)
        {
            _service = service;
        }

        [HttpGet("{sectionId}")]
        public async Task<ActionResult<SectionDto>>Get([FromRoute] int eventId, [FromRoute] int sectionId, [FromQuery] string session) {
            var sectionDto = await _service.GetSectionPreviewAsync(eventId, sectionId, session);
            return Ok(sectionDto);
        }

    }
}

using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet("city/navigation")]
        public async Task<ActionResult<IEnumerable<string>>> NavigationCities()
        {
            var cities = await _service.GetNavigationCitiesAsync();
            return Ok(cities);
        }

    }
}

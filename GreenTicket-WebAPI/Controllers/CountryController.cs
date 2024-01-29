using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [Route("api/country")]
    [AllowAnonymous]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries()
        {
            var countries = await _service.GetCountriesAsync();
            return Ok(countries);
        }

       
    }
}

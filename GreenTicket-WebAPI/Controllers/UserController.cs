using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<BasketUserDetailsDto>> GetUserDetailsAsync([FromRoute] Guid id,[FromQuery] UserDataType datatype)
        {
            var basketUserDetails = await _service.GetUserDataAsync(id, datatype);
            return Ok(basketUserDetails);
        }
    }
}

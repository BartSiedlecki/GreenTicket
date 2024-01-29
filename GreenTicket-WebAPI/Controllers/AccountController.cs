// Ignore Spelling: dto

using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [Route("api/account")]
    [AllowAnonymous]    
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
             Guid newUserId =  await _service.RegisterUser(dto);
            return Created($"/api/account/{newUserId}", null);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoggedUserDto>> Login([FromBody] LoginUserDto dto)
        {
            LoggedUserDto loggedUser = await _service.Login(dto);
            return Ok(loggedUser);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutUserDto dto)
        {
            await _service.Logout(dto);
            return Ok();
        }

    }
}

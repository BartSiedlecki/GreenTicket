using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    //[ResponseCache(Duration = 1200, VaryByQueryKeys = new[] { "imgId" })]
    [Route("api/image")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _service;

        public ImageController(IImageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string fileName)
        {
            var bytes = await _service.GetImageAsync(fileName);

            return File(bytes, "image/jpeg");
        }
    }
}

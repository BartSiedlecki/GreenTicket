using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("navigation")]
        public async Task<ActionResult<IEnumerable<EventCategoryNavDto>>> NavigationCategories()
        {
            var categories = await _service.GetNavigationCategoriesAsync();
            return Ok(categories);
        }
    }
}

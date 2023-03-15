using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly GreenTicketDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(GreenTicketDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventCategoryNavDto>> GetNavigationCategoriesAsync()
        {
            var categories = await _context
                .EventCategories
                .AsNoTracking()
                .ProjectTo<EventCategoryNavDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return categories;
        }
    }
}

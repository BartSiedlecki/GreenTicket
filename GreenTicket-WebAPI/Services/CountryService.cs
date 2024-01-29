using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly GreenTicketDbContext _context;
        private readonly IMapper _mapper;

        public CountryService(GreenTicketDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
        {
            return await _context
                .Countries
                .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }


    }
}

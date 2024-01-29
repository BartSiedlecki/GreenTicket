using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Exceptions;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Services
{
    public class AddressService : IAddressService
    {
        private readonly GreenTicketDbContext _context;
        private readonly IMapper _mapper;

        public AddressService(GreenTicketDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> GetNavigationCitiesAsync()
        {
            var cities = await _context
                .Cities
                .OrderBy(x => x.Name)
                .Distinct()
                .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return cities;
        }
    }
}

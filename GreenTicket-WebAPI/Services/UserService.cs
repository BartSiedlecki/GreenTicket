using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Exceptions;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly GreenTicketDbContext _context;
        private readonly IMapper _mapper;

        public UserService(GreenTicketDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BasketUserDetailsDto> GetUserDataAsync(Guid userId, UserDataType userDataType)
        {

            switch (userDataType)
            {
                case UserDataType.basket:
                    var user = await _context
                        .Users
                        .Where(u => u.Id == userId)
                        .ProjectTo<BasketUserDetailsDto>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync();
                    if (user == null)
                    {
                        throw new NotFoundException("User not found.");
                    }


                    BasketUserDetailsDto basketUserDetails = _mapper.Map<BasketUserDetailsDto>(user);
                    return basketUserDetails;
                default:
                    throw new NotImplementedException();
            }
        }

    }
}

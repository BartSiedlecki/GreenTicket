using AutoMapper.QueryableExtensions;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Exceptions;
using GreenTicket_WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace GreenTicket_WebAPI.Services
{
    public interface IAccountService
    {
        Task<Guid> RegisterUser(RegisterUserDto dto);
        Task<LoggedUserDto> Login(LoginUserDto dto);
        Task Logout(LogoutUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly GreenTicketDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(GreenTicketDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User();
            newUser.Email = dto.Email;
            newUser.FirstName = dto.FirstName;
            newUser.LastName = dto.LastName;
            newUser.DateOfBirth = dto.DateOfBirth;

            var city = await _context
                .Cities
                .FirstOrDefaultAsync(x => x.Name == dto.City);

            if (city is null)
            {
                city = new City() { Name = dto.City };
                _context.Cities.Add(city);
            }

            var country = await _context
                .Countries
                .FirstOrDefaultAsync(x => x.Id == dto.CountryId);

            if (country is null)
                throw new NotFoundException("Country not found!");

            var address = await _context
                .Addresses
                .FirstOrDefaultAsync(
                x => x.PostalCode == dto.PostalCode &&
                x.Street == dto.Street &&
                x.StreetNo == dto.StreetNo &&
                x.City == city &&
                x.Country == country);

            if (address is null)
            {
                address = new Address()
                {
                    PostalCode = dto.PostalCode,
                    Street = dto.Street,
                    StreetNo = dto.StreetNo,
                    City = city,
                    Country = country
                };
                _context.Addresses.Add(address);
            }

            var userRole = await _context
                .Roles
                .FirstOrDefaultAsync(x => x.Name == "Customer");

            if (userRole is null)
                throw new NotFoundException("User role not found!");

            newUser.Address = address;
            newUser.Role = userRole;
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser.Id;
        }

        public async Task<LoggedUserDto> Login(LoginUserDto dto)
        {
            var user = await _context
                .Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(
                x => x.Email == dto.Login);

            if (user is null)
                throw new BadRequestException("Invalid username or password!");

            var verivicationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (verivicationResult == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid username or password!");

            var loggedUserDto = new LoggedUserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Role = new RoleDto() 
                {
                    Id = user.Role.Id,
                    Name = user.Role.Name
                }
            };

            return loggedUserDto;
        }

        public async Task Logout(LogoutUserDto dto)
        {

            await Task.CompletedTask;
        }

    }
}

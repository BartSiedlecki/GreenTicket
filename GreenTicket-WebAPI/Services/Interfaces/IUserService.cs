using GreenTicket_WebAPI.Models;

namespace GreenTicket_WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<BasketUserDetailsDto> GetUserDataAsync(Guid userId, UserDataType userDataType);
    }
}
using GreenTicket_WebAPI.Models;

namespace GreenTicket_WebAPI.Services.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<CityDto>> GetNavigationCitiesAsync();
    }
}
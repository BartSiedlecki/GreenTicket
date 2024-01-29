using GreenTicket_WebAPI.Models;

namespace GreenTicket_WebAPI.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetCountriesAsync();
    }
}
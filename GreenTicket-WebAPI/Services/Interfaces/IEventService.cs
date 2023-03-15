using GreenTicket_WebAPI.Models;

namespace GreenTicket_WebAPI.Services.Interfaces
{
    public interface IEventService
    {
        Task<EventPageDto> GetEventPageModelAsync(int id);
        Task<IEnumerable<EventNavigationSearchResultItemDto>> NavigationSearchAsync(string searchPhrase);
        Task<IEnumerable<EventCarouselDto>> GetCarouselModelsAsync(int qty);
        Task<IEnumerable<EventCardDto>> GetCardsAsync(CardCategory category, int qty);
        Task<IEnumerable<EventFilterPageDto>> GetFilteredEventsAsync(QueryParamsFilter queryParams);
    }
}
using GreenTicket_WebAPI.Models;

namespace GreenTicket_WebAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<EventCategoryNavDto>> GetNavigationCategoriesAsync();
    }
}
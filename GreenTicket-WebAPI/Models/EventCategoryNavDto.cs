using GreenTicket_WebAPI.Entities;

namespace GreenTicket_WebAPI.Models
{
    public class EventCategoryNavDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public ICollection<EventSubCategoryNavDto> SubCategories { get; set; } = null!;

    }
}

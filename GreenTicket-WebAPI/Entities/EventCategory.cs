namespace GreenTicket_WebAPI.Entities
{
    public enum EventCategories
    {
        Concerts = 1,
        Culture = 2,
        Sport = 3,
        Other = 4,    
    }

    public class EventCategory
    {
        public int Id { get; set; }
        public EventCategories Category { get; set; }
        public string Title { get; set; } = null!;
        public ICollection<EventSubCategory> SubCategories { get; set; } = null!;
    }
}

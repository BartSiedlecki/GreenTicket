namespace GreenTicket_WebAPI.Entities
{
    public class EventCategory
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public ICollection<EventSubCategory> SubCategories { get; set; } = null!;
    }
}

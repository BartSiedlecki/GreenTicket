namespace GreenTicket_WebAPI.Entities
{
    public class EventSubCategory
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public int CategoryId { get; set; }
        public EventCategory Category { get; set; } = null!;
    }
}

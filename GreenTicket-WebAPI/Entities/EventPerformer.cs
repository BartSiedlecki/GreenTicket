namespace GreenTicket_WebAPI.Entities
{
    public class EventPerformer
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
        public int PerformerId { get; set; }
        public Performer Performer { get; set; } = null!;
    }
}

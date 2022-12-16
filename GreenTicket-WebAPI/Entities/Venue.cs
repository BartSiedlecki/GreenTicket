namespace GreenTicket_WebAPI.Entities
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }
        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<Event> Event { get; set; } = null!;
    }
}

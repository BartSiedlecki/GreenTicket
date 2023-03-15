namespace GreenTicket_WebAPI.Models
{
    public class EventNavigationSearchResultItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDateTime { get; set; }
        public string VenueName { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}

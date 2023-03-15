namespace GreenTicket_WebAPI.Models
{
    public class EventCarouselDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDateTime { get; set; }
        public string City { get; set; } = null!;
        public string? ImageFileName { get; set; }

    }
}

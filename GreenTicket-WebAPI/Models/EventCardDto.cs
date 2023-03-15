namespace GreenTicket_WebAPI.Models
{
    public class EventCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDateTime { get; set; }
        public string City { get; set; } = null!;
        public string? ImageFileName { get; set; }
        public decimal PriceFrom { get; set; }
    }
}

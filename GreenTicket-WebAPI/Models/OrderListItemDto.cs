namespace GreenTicket_WebAPI.Models
{
    public class OrderListItemDto
    {
        public Guid Id { get; set; }
        public string OrderNo { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool AlreadyPaid { get; set; }

        public IEnumerable<EventCarouselDto> Events { get; set; } = null!;
    }
}

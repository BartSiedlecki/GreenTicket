namespace GreenTicket_WebAPI.Models
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public Guid QrCode { get; set; }
        public bool Cancelled { get; set; }
        public Decimal Price { get; set; }
        public bool IsStanding { get; set; }

        public string SectionName { get; set; } = null!;
        public int? SeatNo { get; set; }
        public string? RowName { get; set; } = null!;

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public VenueDto Venue { get; set; } = null!;
        public string? EventImage { get; set; }

    }
}

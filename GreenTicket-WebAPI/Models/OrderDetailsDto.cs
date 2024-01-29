namespace GreenTicket_WebAPI.Models
{
    public class OrderDetailsDto
    {
        public OrderDetailsDto()
        {
            Tickets = new HashSet<TicketDto>();
        }

        public Guid Id { get; set; }
        public string? OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public IEnumerable<TicketDto> Tickets { get; set; }
    }
}

namespace GreenTicket_WebAPI.Models
{
    public class CreateOrderTicketDto
    {
        public Guid PlaceId { get; set; }
        public bool IsStanding { get; set; }
    }
}

using GreenTicket_WebAPI.Entities;

namespace GreenTicket_WebAPI.Models
{
    public class OrderCreateDto
    {
        public OrderCreateDto()
        {
            Tickets = new HashSet<CreateOrderTicketDto>();
        }

        public Guid UserId { get; set; }

        public IEnumerable<CreateOrderTicketDto> Tickets { get; set; }
       
    }
}

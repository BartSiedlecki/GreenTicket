using GreenTicket_WebAPI.Entities;

namespace GreenTicket_WebAPI.Models
{
    public class RowDto
    {
        public RowDto()
        {
            Seats = new HashSet<SeatDto>();
        }

        public string Name { get; set; } = null!;
        public ICollection<SeatDto> Seats { get; set; }
    }
}

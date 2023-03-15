using GreenTicket_WebAPI.Entities;

namespace GreenTicket_WebAPI.Models
{
    public class SeatDto
    {
        public Guid SeatId { get; set; }
        public int Number { get; set; }
        public Decimal? CustomPrice { get; set; }
        public string? RestrictionDescpiption { get; set; }
        public bool Sold { get; set; } = false;
        public bool CurrentReservation { get; set; } = false;
        public bool Reserved { get; set; } = false;
    }
}

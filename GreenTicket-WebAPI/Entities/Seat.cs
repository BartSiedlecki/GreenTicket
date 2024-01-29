namespace GreenTicket_WebAPI.Entities
{
    public class Seat
    {
        public Seat()
        {
            Restrictions = new HashSet<Restriction>();
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public bool Sold { get; set; } = false;
        public string? ReservationSessionId { get; set; } 
        public DateTime? ReservationDate { get; set; } 
        public Guid RowId { get; set; } 
        public Row Row { get; set; } = null!;

        public ICollection<Restriction> Restrictions { get; set; }
    }
}

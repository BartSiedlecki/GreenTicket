namespace GreenTicket_WebAPI.Entities
{
    public class StandingPlace
    {
        public StandingPlace()
        {
            Restrictions = new HashSet<Restriction>();
        }

        public Guid Id { get; set; }
        public bool Sold { get; set; } = false;
        public string? ReservationSessionId { get; set; }
        public DateTime? ReservationDate { get; set; }
        public ICollection<Restriction> Restrictions { get; set; }
        public Section Section { get; set; } = null!;

    }
}
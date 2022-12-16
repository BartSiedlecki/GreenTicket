namespace GreenTicket_WebAPI.Entities
{
    public class Row
    {
        public Row()
        {
            Seats = new HashSet<Seat>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Seat> Seats { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; } = null!;

        
    }
}

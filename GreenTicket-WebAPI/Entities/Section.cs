namespace GreenTicket_WebAPI.Entities
{
    public class Section
    {
        public Section()
        {
            Rows = new HashSet<Row>();
            StandingPlaces = new HashSet<StandingPlace>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public SectionTypes SectionType { get; set; }
        public int Capacity { get; set; }
        public Decimal Price { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
        public ICollection<Row> Rows { get; set; } = null!;
        public ICollection<StandingPlace> StandingPlaces { get; set; } = null!;
    }

    public enum SectionTypes
    {
        Seated = 1,
        Standing = 2,
    }
}

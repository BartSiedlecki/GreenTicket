namespace GreenTicket_WebAPI.Entities
{
    public class Section
    {
        public Section()
        {
            Rows = new HashSet<Row>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public Decimal Price { get; set; }
        public bool IsStanding { get; set; } = false;

        public ICollection<Row> Rows { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
    }
}

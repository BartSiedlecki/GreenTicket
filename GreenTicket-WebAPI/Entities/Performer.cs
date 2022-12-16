namespace GreenTicket_WebAPI.Entities
{
    public class Performer
    {
        public Performer()
        {
            EventPerformers = new HashSet<EventPerformer>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<EventPerformer> EventPerformers { get; set; }

    }
}

namespace GreenTicket_WebAPI.Entities
{
   
    public class Event
    {
        public Event()
        {
            Sections = new HashSet<Section>();
            EventPerformers = new HashSet<EventPerformer>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public int EventSubCategoryId { get; set; }
        public EventSubCategory SubCategory { get; set; } = null!;
        public int VenueId { get; set; }
        public virtual Venue Venue { get; set; } = null!;
        public ICollection<Section> Sections { get; set; }
        public ICollection<EventPerformer> EventPerformers { get; set; }
    }
}


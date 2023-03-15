namespace GreenTicket_WebAPI.Entities
{
    public enum EventSubcategories
    {
        RockPop = 1,
        HardHeavy = 2,
        ClassicalMusic = 3,
        ElectronicTechno = 4,
        DiscoDance = 5,
        Jazz = 6,
        RapHipHop = 7,
        Others = 8,
        OtherConcerts = 9,
        Theatre = 10,
        BalletDance = 11,
        Musical = 12,
        OtherCulture = 13,
        Handball = 14,
        Football = 15,
        Vollayball = 15,
        MotorSports = 15,
        Bastekball = 15,
        OtherSport = 15,
        Family = 15,
        OtherOther = 15
    }

    public class EventSubCategory
    {
        public EventSubCategory()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public EventSubcategories Subcategory { get; set; }
        public string Title { get; set; } = null!;
        public int CategoryId { get; set; }
        public EventCategory Category { get; set; } = null!;
        public ICollection<Event> Events { get;}
    }
}

namespace GreenTicket_WebAPI.Entities
{
    public enum ImageType
    {
        Carousel = 1,
        Card = 2,
        SeatingPlan = 3
    }

    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public ImageType ImageType { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
    }
}

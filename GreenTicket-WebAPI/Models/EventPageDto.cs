using static System.Net.Mime.MediaTypeNames;

namespace GreenTicket_WebAPI.Models
{
    public class EventPageDto
    {
        public EventPageDto()
        {
            Sections = new HashSet<SectionDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; } = null!;
        public string City { get; set; } = null!;
        public string VenueName { get; set; } = null!;
        public int LimitPerUser { get; set; }
        public string? EventCardImage { get; set; }
        public string? SeatingPlanImage { get; set; }
        public decimal PriceFrom { get; set; }
        public ICollection<SectionDto> Sections { get; set; }

    }
}

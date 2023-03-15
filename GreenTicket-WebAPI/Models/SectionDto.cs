using GreenTicket_WebAPI.Entities;

namespace GreenTicket_WebAPI.Models
{
    public class SectionDto
    {
        public SectionDto()
        {
            Rows = new HashSet<RowDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public Decimal Price { get; set; }
        public bool IsStanding { get; set; } = false;

        public ICollection<RowDto> Rows { get; set; }
    }
}

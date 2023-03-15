namespace GreenTicket_WebAPI.Models
{
    public class EventSubCategoryNavDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int NoOfEventsOnSale { get; set; }
    }
}

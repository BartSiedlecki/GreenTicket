namespace GreenTicket_WebAPI.Entities
{
    public class OrderStatus
    {
        public Guid Id { get; set; }
        public OrderStatusType Type { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public string? Comment { get; set; }
        public Guid? ApprovedById { get; set; }
        public virtual User? ApprovedBy { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
    }


}

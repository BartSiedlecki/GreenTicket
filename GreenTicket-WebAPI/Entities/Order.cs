namespace GreenTicket_WebAPI.Entities
{
    public class Order
    {
        public Order()
        {
            Tickets = new HashSet<Ticket>();
            Statuses = new HashSet<OrderStatus>();
            Payments = new HashSet<Payment>();
        }

        public Guid Id { get; set; }
        public string? OrderNo { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; } = null!;
        public IEnumerable<OrderStatus> Statuses { get; set; } = null!;
        public IEnumerable<Payment> Payments { get; set; } = null!;
       
    }
}

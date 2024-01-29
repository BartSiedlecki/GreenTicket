namespace GreenTicket_WebAPI.Models
{
    public class PaymentOrderDto
    {
        public Guid Id { get; set; }
        public string OrderNo { get; set; } = null!;
        public string UserFirstName { get; set; } = null!;
        public string UserLastName { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool AlreadyPaid { get; set; }
    }
}

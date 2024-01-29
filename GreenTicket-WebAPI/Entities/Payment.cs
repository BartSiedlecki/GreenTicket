namespace GreenTicket_WebAPI.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public PaymentDirection Direction { get; set; }
        public decimal Amount { get; set; }
        public bool IsSucceed { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public string? Comment { get; set; }
        public string? UserRecognitionDetail { get; set; }
        // last 4 digits of card number, or email address, or phone number

        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
    }
}

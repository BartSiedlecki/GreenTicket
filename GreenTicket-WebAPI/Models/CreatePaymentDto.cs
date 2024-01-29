using GreenTicket_WebAPI.Entities;

namespace GreenTicket_WebAPI.Models
{
    public class CreatePaymentDto
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public string UserRecognitionDetail { get; set; }

    }
}

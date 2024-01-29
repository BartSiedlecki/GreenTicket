namespace GreenTicket_WebAPI.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid QrCode { get; set; }
        
        public bool Validated { get; set; } = false;
        public bool ValidationDate { get; set; } = false;
        public bool Cancelled { get; set; } = false;
        public bool CancellationDate { get; set; } = false;

       
        public Guid OrderID { get; set; }
        public Order Order { get; set; } = null!;

        public Guid? StandingPlaceId { get; set; }
        public StandingPlace StandingPlace { get; set; } = null!;
        public Guid? SeatId { get; set; }
        public Seat Seat { get; set; } = null!;
    }
}

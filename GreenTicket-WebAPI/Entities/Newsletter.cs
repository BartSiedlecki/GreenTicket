namespace GreenTicket_WebAPI.Entities
{
    public class Newsletter
    {
        public int ID { get; set; }
        public string EmailAddress { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string IPAddress { get; set; } = null!;
    }
}


// DODAĆ MIGRACJE
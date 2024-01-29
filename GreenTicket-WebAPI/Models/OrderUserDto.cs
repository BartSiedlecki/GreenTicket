namespace GreenTicket_WebAPI.Models
{
    public class OrderUserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        
    }
}

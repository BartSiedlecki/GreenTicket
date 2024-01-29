namespace GreenTicket_WebAPI.Models
{
    public class RegisterUserDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string RepeatPassword { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; } 
        public string Street { get; set; } = null!;
        public string StreetNo { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string CountryId { get; set; } = null!;
    }
}

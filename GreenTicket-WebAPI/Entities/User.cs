namespace GreenTicket_WebAPI.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;

        public int RoleId { get; set; } 
        public virtual Role Role { get; set; } = null!;
    }
}

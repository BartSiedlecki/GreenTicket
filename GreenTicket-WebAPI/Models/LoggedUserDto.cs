using GreenTicket_WebAPI.Models;

namespace GreenTicket_WebAPI.Models
{
    public class LoggedUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public RoleDto Role { get; set; } = null!;
    }
}

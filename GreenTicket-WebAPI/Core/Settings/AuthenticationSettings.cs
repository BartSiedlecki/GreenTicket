namespace GreenTicket_WebAPI.Core.Settings
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; } = null!;
        public string JwtIssuer { get; set; } = null!;
        public int JwtExpireMinutes { get; set; }
        public int JwtRefreshTokenExpireHours { get; set; }
    }
}

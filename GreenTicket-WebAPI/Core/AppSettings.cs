namespace PremiumAPI.Core
{
    public class AppSettings
    {
        public string Domain { get; set; } = null!;
        public int MinRequestTimeLog { get; set; }
        public string QueryStringKey { get; set; } = null!;
    }
}

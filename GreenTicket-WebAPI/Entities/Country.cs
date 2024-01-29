namespace GreenTicket_WebAPI.Entities
{
    public class Country
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; } = null!;
    }
}

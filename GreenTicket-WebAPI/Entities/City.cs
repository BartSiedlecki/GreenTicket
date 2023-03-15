namespace GreenTicket_WebAPI.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; } = null!;

    }
}

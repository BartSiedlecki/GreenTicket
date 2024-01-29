namespace GreenTicket_WebAPI.Entities
{
    public class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string PostalCode { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string StreetNo { get; set; } = null!;

        public int CityID { get; set; }
        public virtual City City { get; set; } = null!;
        public int? VenueID { get; set; }
        public virtual Venue? Venue { get; set; }
        public string CountryId { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }

    }
}

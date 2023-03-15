namespace GreenTicket_WebAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string StreetNo { get; set; } = null!;

        public int CityID { get; set; } 
        public virtual City City { get; set; } = null!;
        public int VenueID { get; set; }
        public virtual Venue Venue { get; set; } = null!;
    }
}

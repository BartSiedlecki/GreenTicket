namespace GreenTicket_WebAPI.Entities
{
    public class Restriction
    {
        public int Id { get; set; }
        public RestrictionTypes RestrictionType { get; set; }
        public decimal PriceReduction { get; set; }
    }
}

public enum RestrictionTypes
{
    RestrictedView = 1,
    SideView = 2,
    RearView = 3,
    Other = 4,
}


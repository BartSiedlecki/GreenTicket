namespace GreenTicket_WebAPI.Entities
{
    public class Seat
    {
        public Guid SeatId { get; set; }
        public int Number { get; set; }
        public Decimal? CustomPrice { get; set; }
        public string? RestrictionDescpiption { get; set; }
        public bool Sold { get; set; } = false;
        public Guid RowId { get; set; } 
        public Row Row { get; set; } = null!;
    }
}

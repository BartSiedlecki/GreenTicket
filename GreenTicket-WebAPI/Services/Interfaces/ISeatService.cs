namespace GreenTicket_WebAPI.Services.Interfaces
{
    public interface ISeatService
    {
        Task<DateTime> ReserveTicketAsync(int eventId, int sectionId, string seatId, string sessionId);
        Task CancelTicketReservationAsync(int eventId, int sectionId, string seatId, string sessionId);
    }
}
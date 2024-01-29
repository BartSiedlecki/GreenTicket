
namespace GreenTicket_WebAPI.Services
{
    public interface ITicketService
    {
        Task<byte[]> GetOrderTicketsAsync(Guid userId, Guid ticketId);
        Task<byte[]> GetTicketAsync(Guid userId, Guid orderId, Guid ticketId);
    }
}
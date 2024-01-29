using GreenTicket_WebAPI.Models;

namespace GreenTicket_WebAPI.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderListItemDto>> GetListAsync(Guid userId);
        Task<OrderDetailsDto> Get(Guid userId, Guid orderId);
        Task<Guid> CreateOrderAsync(Guid userId, IEnumerable<CreateOrderTicketDto> tickets);
        Task<PaymentOrderDto> GetPaymentOrderAsync(Guid userId, Guid orderId);
        Task MakePaymentAsync(Guid userId, CreatePaymentDto createPaymentDto);
    }
}
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Exceptions;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly GreenTicketDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(GreenTicketDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderListItemDto>> GetListAsync(Guid userId)
        {
            var orders = await _context
                .Orders
                .Include(o => o.Statuses)
                .Include(o => o.Payments)
                .Include(o => o.Tickets)
                    .ThenInclude(t => t.Seat)
                    .ThenInclude(s => s.Row)
                    .ThenInclude(r => r.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Venue)
                    .ThenInclude(r => r.Address)
                    .ThenInclude(r => r.City)
                .Include(o => o.Tickets)
                    .ThenInclude(t => t.Seat)
                    .ThenInclude(s => s.Row)
                    .ThenInclude(r => r.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Images)
                .Include(o => o.Tickets)
                    .ThenInclude(t => t.StandingPlace)
                    .ThenInclude(s => s.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Venue)
                    .ThenInclude(r => r.Address)
                    .ThenInclude(r => r.City)
                .Include(o => o.Tickets)
                    .ThenInclude(t => t.StandingPlace)
                    .ThenInclude(s => s.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Images)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var dtoList = _mapper.Map<IEnumerable<OrderListItemDto>>(orders);

            return dtoList;
        }

        public async Task<OrderDetailsDto> Get(Guid userId, Guid orderId)
        {
            var order = await _context
                            .Orders
                            .Include(o => o.Tickets)
                                .ThenInclude(t => t.Seat)
                                .ThenInclude(s => s.Row)
                                .ThenInclude(r => r.Section)
                                .ThenInclude(r => r.Event)
                                .ThenInclude(r => r.Venue)
                                .ThenInclude(r => r.Address)
                                .ThenInclude(r => r.City)
                            .Where(o => o.Id == orderId && o.User.Id == userId)
                            .FirstOrDefaultAsync();

            if (order is null)
            {
                throw new NotFoundException("Order not found");
            }

            var dto = _mapper.Map<OrderDetailsDto>(order);
            return dto;
        }

        public async Task<Guid> CreateOrderAsync(Guid userId, IEnumerable<CreateOrderTicketDto> dtoTickets)
        {
            var user = await _context
                .Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user is null)
            {
                throw new NotFoundException("User not found!");
            }

            var orderTickets = new List<Ticket>();
            var totalPrice = 0m;

            foreach (var dto in dtoTickets)
            {
                if (dto.IsStanding)
                {
                    var standingPlace = await _context
                        .StandingPlaces
                        .Include(sp => sp.Section)
                        .Where(sp => sp.Id == dto.PlaceId)
                        .FirstOrDefaultAsync();

                    if (standingPlace is null)
                    {
                        throw new NotFoundException("Standing place not found!");
                    }

                    var ticket = new Ticket
                    {
                        Id = Guid.NewGuid(),
                        QrCode = Guid.NewGuid(),
                        StandingPlaceId = dto.PlaceId
                    };
                    totalPrice += standingPlace.Section.Price;
                    orderTickets.Add(ticket);

                    standingPlace.Sold = true;
                }
                else
                {
                    var seat = await _context
                        .Seats
                        .Include(s => s.Row)
                        .ThenInclude(r => r.Section)
                        .Where(p => p.Id == dto.PlaceId)
                        .FirstOrDefaultAsync();

                    if (seat is null)
                    {
                        throw new NotFoundException("Place not found!");
                    }

                    var ticket = new Ticket
                    {
                        Id = Guid.NewGuid(),
                        QrCode = Guid.NewGuid(),
                        SeatId = dto.PlaceId
                    };

                    totalPrice += seat.Row.Section.Price;
                    orderTickets.Add(ticket);

                    seat.Sold = true;
                }

            }

            var order = new Order
            {
                User = user,
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                Tickets = orderTickets,
                Statuses = new List<OrderStatus>
                {
                    new OrderStatus
                    {
                        Id = Guid.NewGuid(),
                        Type = OrderStatusType.Placed,
                        Date = DateTime.Now
                    }
                }
            };
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<PaymentOrderDto> GetPaymentOrderAsync(Guid userId, Guid orderId)
        {
            var order = await _context
                .Orders
                .Where(o => o.Id == orderId && o.UserId == userId)
                .ProjectTo<PaymentOrderDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (order is null)
            {
                throw new NotFoundException("Order not found!");
            }

            var dto = _mapper.Map<PaymentOrderDto>(order);

            return dto;
        }

        public async Task MakePaymentAsync(Guid userId, CreatePaymentDto createPaymentDto)
        {
            var order = await _context
                .Orders
                .Include(o => o.Statuses)
                .Include(o => o.Payments)
                .Where(o => o.Id == createPaymentDto.OrderId && o.UserId == userId)
                .FirstOrDefaultAsync();

            if (order is null)
            {
                throw new NotFoundException("Order not found!");
            }

            var newPayment = new Payment
            {
                Id = Guid.NewGuid(),
                Order = order,
                Date = DateTime.Now,
                Direction = PaymentDirection.Ingoing,
                IsSucceed = true,
                Amount = createPaymentDto.Amount,
                PaymentMethod = createPaymentDto.PaymentMethod,
                UserRecognitionDetail = createPaymentDto.UserRecognitionDetail
            };

            _context.Payments.Add(newPayment);

            var newPaymentStatus = new OrderStatus
            {
                Id = Guid.NewGuid(),
                Type = OrderStatusType.Paid,
                Date = DateTime.Now,
                Order = order
            };

            _context.OrderStatuses.Add(newPaymentStatus);

            await _context.SaveChangesAsync();
        }
    }
}

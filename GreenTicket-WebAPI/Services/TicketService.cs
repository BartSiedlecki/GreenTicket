using AutoMapper;
using GreenTicket_WebAPI.Documents;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Exceptions;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;

namespace GreenTicket_WebAPI.Services
{
    public class TicketService : ITicketService
    {
        private readonly GreenTicketDbContext _context;
        private readonly IMapper _mapper;
        private readonly IQRCodeCreator _qrCodeCreator;
        private readonly IImageService _imageService;

        public TicketService(GreenTicketDbContext context, IMapper mapper, IQRCodeCreator qrCodeCreator, IImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _qrCodeCreator = qrCodeCreator;
            _imageService = imageService;
        }

        public async Task<byte[]> GetTicketAsync(Guid userId, Guid orderId, Guid ticketId)
        {
            var ticket = await _context.Tickets
                    .Include(t => t.Seat)
                    .ThenInclude(s => s.Row)
                    .ThenInclude(r => r.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Venue)
                    .ThenInclude(r => r.Address)
                    .ThenInclude(r => r.City)
                    .Include(t => t.Seat)
                    .ThenInclude(s => s.Row)
                    .ThenInclude(r => r.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Images)
                    .Include(t => t.StandingPlace)
                    .ThenInclude(s => s.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Venue)
                    .ThenInclude(r => r.Address)
                    .ThenInclude(r => r.City)
                    .Include(t => t.StandingPlace)
                    .ThenInclude(s => s.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Images)
                    .Include(t => t.Order)
                .Where(o => o.Id == ticketId && o.Order.UserId == userId && o.Order.Id == orderId)
                .FirstOrDefaultAsync();

            if (ticket is null)
            {
                throw new NotFoundException("Ticket not found");
            }

            var dto = _mapper.Map<TicketDto>(ticket);

            var pdfTicket = new TicketDocument(new List<TicketDto> { dto }, _qrCodeCreator, _imageService);
            // pdfTicket.ShowInPreviewer();
            var bytes = pdfTicket.GeneratePdf();

            return bytes;
        }

        public async Task<byte[]> GetOrderTicketsAsync(Guid userId, Guid orderId)
        {
            var tickets = await _context.Tickets
                    .Include(t => t.Seat)
                    .ThenInclude(s => s.Row)
                    .ThenInclude(r => r.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Venue)
                    .ThenInclude(r => r.Address)
                    .ThenInclude(r => r.City)
                    .Include(t => t.Seat)
                    .ThenInclude(s => s.Row)
                    .ThenInclude(r => r.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Images)
                    .Include(t => t.StandingPlace)
                    .ThenInclude(s => s.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Venue)
                    .ThenInclude(r => r.Address)
                    .ThenInclude(r => r.City)
                    .Include(t => t.StandingPlace)
                    .ThenInclude(s => s.Section)
                    .ThenInclude(r => r.Event)
                    .ThenInclude(r => r.Images)
                    .Include(t => t.Order)
                .Where(o => o.Order.UserId == userId && o.OrderID == orderId)
                .OrderBy(o => o.Seat.Row.Section.Event.Name)
                .ThenBy(o => o.Seat.Row.Section)
                .ThenBy(o => o.Seat.Row)
                .ThenBy(o => o.Seat)
                .ToListAsync();

            if (tickets.Count == 0)
            {
                throw new NotFoundException("Ticket not found");
            }

            var dto = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            var pdfTicket = new TicketDocument(dto, _qrCodeCreator, _imageService);
            // pdfTicket.ShowInPreviewer();
            var bytes = pdfTicket.GeneratePdf();

            return bytes;
        }
    }
}

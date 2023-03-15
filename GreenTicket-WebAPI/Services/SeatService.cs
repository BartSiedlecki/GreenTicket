using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Exceptions;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Services
{
    public class SeatService : ISeatService
    {
        private readonly GreenTicketDbContext _context;

        public SeatService(GreenTicketDbContext context)
        {
            _context = context;
        }

        public async Task ReserveTicketAsync(int eventId, int sectionId, string seatId, string sessionId)
        {
            var seat = await _context.Seats.Where(s => s.Row.Section.Event.Id == eventId &&
            s.Row.Section.Id == sectionId &&
            s.SeatId.ToString() == seatId)
            .FirstOrDefaultAsync();

            if (seat is null)
                throw new NotFoundException("Seat not found");

            if ((!string.IsNullOrEmpty(seat.ReservationSessionId) && seat.ReservationDate < DateTime.Now.AddMinutes(20) || seat.Sold))
                throw new BadRequestException("SeatAlreadyReserved");

            seat.ReservationSessionId = sessionId;
            seat.ReservationDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task CancelTicketReservationAsync(int eventId, int sectionId, string seatId, string sessionId)
        {
            var seat = await _context.Seats.Where(s => s.Row.Section.Event.Id == eventId &&
            s.Row.Section.Id == sectionId &&
            s.SeatId.ToString() == seatId)
            .FirstOrDefaultAsync();

            if (seat is null)
                throw new NotFoundException("Seat not found");

            seat.ReservationSessionId = null;
            seat.ReservationDate = null;

            await _context.SaveChangesAsync();
        }
    }
}

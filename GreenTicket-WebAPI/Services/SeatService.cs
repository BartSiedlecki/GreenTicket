using GreenTicket_WebAPI.Core.Settings;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Exceptions;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GreenTicket_WebAPI.Services
{
    public class SeatService : ISeatService
    {
        private readonly GreenTicketDbContext _context;
        private readonly IOptions<SystemSettings> _systemSettings;

        public SeatService(GreenTicketDbContext context, IOptions<SystemSettings> systemSettings)
        {
            _context = context;
            _systemSettings = systemSettings;
        }

        public async Task<DateTime> ReserveTicketAsync(int eventId, int sectionId, string seatId, string sessionId)
        {
            var seat = await _context.Seats.Where(s => s.Row.Section.Event.Id == eventId &&
            s.Row.Section.Id == sectionId &&
            s.Id.ToString() == seatId)
            .FirstOrDefaultAsync();

            if (seat is null)
                throw new NotFoundException("Seat not found");

            if ((!string.IsNullOrEmpty(seat.ReservationSessionId) && seat.ReservationDate < DateTime.Now.AddMinutes(20) || seat.Sold))
                throw new BadRequestException("SeatAlreadyReserved");

            seat.ReservationSessionId = sessionId;
            seat.ReservationDate = DateTime.Now;


            await _context.SaveChangesAsync();

            var reservationTime = _systemSettings.Value.TicketReservationTimeInMinutes;
            var reservedTo = DateTime.Now.AddMinutes(reservationTime); 
            return reservedTo;
        }

        public async Task CancelTicketReservationAsync(int eventId, int sectionId, string seatId, string sessionId)
        {
            var seat = await _context.Seats.Where(s => s.Row.Section.Event.Id == eventId &&
            s.Row.Section.Id == sectionId &&
            s.Id.ToString() == seatId &&
            s.ReservationSessionId == sessionId)
            .FirstOrDefaultAsync();

            if (seat is null)
                throw new NotFoundException("Seat not found");

            seat.ReservationSessionId = null;
            seat.ReservationDate = null;

            await _context.SaveChangesAsync();
        }
    }
}

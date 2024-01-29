using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Services
{
    public class StandingPlaceService
    {
        private readonly GreenTicketDbContext _context;
        public StandingPlaceService(GreenTicketDbContext context)
        {
            _context = context;
        }

        public async Task ReserveAsync(int eventId, int sectionId, string sessionId)
        {
            var standingPlace = _context.StandingPlaces.FirstOrDefault(s => s.Section.Event.Id == eventId &&
            s.Section.Id == sectionId &&
            string.IsNullOrEmpty(s.ReservationSessionId) &&
            !s.Sold);

            if (standingPlace is null)
                throw new NotFoundException("No standing room available");

            standingPlace.ReservationSessionId = sessionId;
            standingPlace.ReservationDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task CancelReservation(int eventId, int sectionId, string standingPlaceId, string sessionId)
        {
            var standingPlace = await _context.StandingPlaces.Where(s => s.Section.Event.Id == eventId &&
            s.Section.Id == sectionId &&
            s.Id.ToString() == standingPlaceId &&
            s.ReservationSessionId == sessionId)
            .FirstOrDefaultAsync();

            if (standingPlace is null)
            {
                throw new NotFoundException("Standing place not found");
            }

            standingPlace.ReservationSessionId = null;
            standingPlace.ReservationDate = null;

            await _context.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Exceptions;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Services
{
    public class SectionService : ISectionService
    {
        private readonly GreenTicketDbContext _context;
        private readonly IMapper _mapper;

        public SectionService(GreenTicketDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SectionDto> GetSectionPreviewAsync(int eventId, int SectionId, string session)
        {
            var sectionDto = await _context
                .Sections
                .Where(s => s.EventId == eventId &&
                s.Id == SectionId)
                .ProjectTo<SectionDto>(_mapper.ConfigurationProvider, new { sessionId = session })
                .FirstOrDefaultAsync();

            if (sectionDto is null)
                throw new NotFoundException("Section not found");

            return sectionDto;
        }
    }
}

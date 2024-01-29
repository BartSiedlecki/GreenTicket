using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenTicket_WebAPI.Documents;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

namespace GreenTicket_WebAPI.Controllers
{
    [ApiController]
    [Route("api/dev")]
    public class a___dev___test____Controller : ControllerBase
    {
        private readonly GreenTicketDbContext _context;
        private readonly IMapper _mapper;
        private readonly IQRCodeCreator _qrCodeCreator;
        private readonly IImageService _imageService;

        public a___dev___test____Controller(GreenTicketDbContext context, IMapper mapper, IQRCodeCreator qrCodeCreator, IImageService imageService)
        {
            _context = context;
            _mapper = mapper;
            _qrCodeCreator = qrCodeCreator;
            _imageService = imageService;
        }

        [HttpGet("test")]
        public async Task<ActionResult> TestAsync()
        {
            Ticket ticket = await _context.Tickets
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
                .Where(o => o.Id == new Guid("7FA8D00E-07A6-4D75-B434-7E314B6AE5E3"))
                .FirstOrDefaultAsync();

            var dto = _mapper.Map<TicketDto>(ticket);

            var pdfTicket = new TicketDocument(new List<TicketDto> { dto }, _qrCodeCreator, _imageService);
            pdfTicket.ShowInPreviewer();
            var bytes = pdfTicket.GeneratePdf();



            return Ok();
        }
    }
}

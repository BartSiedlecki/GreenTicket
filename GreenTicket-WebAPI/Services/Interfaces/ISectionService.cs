using GreenTicket_WebAPI.Models;

namespace GreenTicket_WebAPI.Services.Interfaces
{
    public interface ISectionService
    {
        Task<SectionDto> GetSectionPreviewAsync(int eventId, int SectionId, string session);
    }
}
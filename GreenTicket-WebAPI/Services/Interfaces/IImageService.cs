namespace GreenTicket_WebAPI.Services.Interfaces
{
    public interface IImageService
    {
        Task<byte[]> GetImageAsync(string fileName);
    }
}
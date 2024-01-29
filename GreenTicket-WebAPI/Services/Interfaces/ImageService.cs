namespace GreenTicket_WebAPI.Services.Interfaces
{
    public class ImageService : IImageService
    {

        public async Task<byte[]> GetImageAsync(string fileName)
        {
            var rootPath = Directory.GetCurrentDirectory();

            if (!fileName.EndsWith(".jpg"))
                throw new Exception();

            string[] paths = { rootPath, "Data", "Images", fileName };
            var filePath = Path.Combine(paths);

            if (!File.Exists(filePath))
                throw new Exception();

            byte[] bytes = await File.ReadAllBytesAsync(filePath);

            return bytes;
        }
    }
}

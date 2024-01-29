namespace GreenTicket_WebAPI.Services
{
    public class PDFCreator
    {
        private readonly ILogger<PDFCreator> _logger;

        public PDFCreator(ILogger<PDFCreator> logger)
        {
            _logger = logger;
        }


    }
}

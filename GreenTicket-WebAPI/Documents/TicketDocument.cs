using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GreenTicket_WebAPI.Documents
{
    public class TicketDocument : IDocument
    {
        private readonly IEnumerable<TicketDto> _tickets;
        private readonly IQRCodeCreator _qrCodeCreator;
        private readonly IImageService _imageService;

        public TicketDocument(IEnumerable<TicketDto> tickets, IQRCodeCreator qrCodeCreator, IImageService imageService)
        {
            _tickets = tickets;
            _qrCodeCreator = qrCodeCreator;
            _imageService = imageService;
        }

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    var marginY = 1.8f;
                    var marginX = 2f;

                    page.Size(PageSizes.A4.Portrait());
                    page.MarginTop(marginY, Unit.Centimetre);
                    page.MarginBottom(marginY, Unit.Centimetre);
                    page.MarginLeft(marginX, Unit.Centimetre);
                    page.MarginRight(marginX, Unit.Centimetre);
                    page.DefaultTextStyle(TextStyle.Default.FontSize(10));

                    page.Content().Column(column =>
                    {
                        column.Spacing(0);

                        _tickets.ToList().ForEach(ticket =>
                        {
                            column.Item().Component(new SinglePdfTicket(ticket, _qrCodeCreator, _imageService));
                            column.Item().PaddingVertical(5).LineHorizontal(0.3f).LineColor(Colors.Grey.Medium);
                        });
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    }
}

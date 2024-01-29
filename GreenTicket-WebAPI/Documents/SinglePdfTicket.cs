using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GreenTicket_WebAPI.Documents
{
    public class SinglePdfTicket : IComponent
    {
        private readonly TicketDto _ticket;
        private readonly IQRCodeCreator _qrCodeCreator;
        private readonly IImageService _imageService;

        public SinglePdfTicket(TicketDto ticket, IQRCodeCreator qrCodeCreator, IImageService imageService)
        {
            _ticket = ticket;
            _qrCodeCreator = qrCodeCreator;
            _imageService = imageService;
        }

        public void Compose(IContainer container)
        {
            Int32 ticketHeight = 120;
            Int32 borderHeight = 9;
            Int32 mediumRowHeightWidth = ticketHeight - 2 * borderHeight;
            Single borderFontSize = 6f;

            container
                .Height(ticketHeight)
                .Background("#2e3f4f")
                .Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(borderHeight);
                        columns.RelativeColumn();
                        columns.ConstantColumn(borderHeight);
                    });


                    // it is possible to provide an image as:
                    // 1) a binary array
                    var rootPath = Directory.GetCurrentDirectory();
                    var truckLogoPath = Path.Combine(rootPath, "Documents", "Images", "logo60.png");
                    byte[] imageData = File.ReadAllBytes(truckLogoPath);
                    //container.Image(imageData);

                    table.Cell().Row(1).Column(1).Height(borderHeight);
                    table.Cell().Row(1).Column(2).Height(borderHeight).AlignCenter().Text("Green ticket").FontColor("#62d04b").FontSize(borderFontSize).Bold();
                    table.Cell().Row(1).Column(3).Height(borderHeight);

                    table.Cell().Row(2).Column(1).Height(mediumRowHeightWidth).AlignMiddle().RotateLeft().Text("Green ticket").FontColor("#62d04b").FontSize(borderFontSize).Bold();
                    table.Cell().Row(2).Column(2).Height(mediumRowHeightWidth).Background("#475d74").Table(innerTable =>
                    {
                        innerTable.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.ConstantColumn(102);
                        });

                        innerTable.Cell().Row(1).Column(1).Padding(4).Table(contentTable =>
                        {
                            contentTable.ColumnsDefinition(contentTableColumn =>
                            {
                                contentTableColumn.RelativeColumn();
                                contentTableColumn.ConstantColumn(100);
                            });

                            contentTable.Cell().Row(1).Column(1).ColumnSpan(2)
                            .Column(column =>
                            {
                                column.Item().Text(_ticket.EventName).FontSize(14f).FontColor("#62d04b").Bold();
                            });

                            contentTable.Cell().Row(2).Column(1)
                            .Column(column =>
                            {
                                column.Item().Text($"{_ticket.EventStartDate.ToShortDateString()} {_ticket.EventStartDate.ToShortTimeString()} - {_ticket.EventEndDate.ToShortTimeString()}").FontSize(8f).FontColor(Colors.White).Bold();
                                column.Item().Text($"{_ticket.Venue.Name}").FontSize(6f).FontColor(Colors.White).Bold();
                                column.Item().Text($"{_ticket.Venue.City}, {_ticket.Venue.Street} {_ticket.Venue.StreetNo} " + "Warszawa, Ul. Szeroka 45A").FontSize(5f).FontColor(Colors.White);
                                column.Item().PaddingVertical(4).LineHorizontal(1).LineColor("#475d74");
                                if (_ticket.IsStanding)
                                {
                                    column.Item().Text($"Section: {_ticket.SectionName}").FontSize(10f).FontColor(Colors.Grey.Lighten1).Bold();
                                } else
                                {
                                    column.Item().Text($"Section: {_ticket.SectionName}, row: {_ticket.RowName}, seat: {_ticket.SeatNo}").FontSize(10f).FontColor(Colors.Grey.Lighten1).Bold();
                                }
                                column.Item().Text($"Price: {Math.Round(_ticket.Price, 2)}zł").FontSize(7f).FontColor(Colors.Grey.Lighten1).Bold();
                                column.Item().Text("Distribution of tickets only via GreenTicket.pl").FontSize(4f).FontColor(Colors.Grey.Lighten1);
                                column.Item().Text("Purchasing tickets not from an official source runs the risk of buying a fake ticket!").FontSize(4f).FontColor(Colors.Grey.Lighten1);
                            });

                            if (_ticket.EventImage is not null)
                            {

                                var eventImage = _imageService.GetImageAsync(_ticket.EventImage).Result;

                                contentTable.Cell().Row(2).Column(2).PaddingRight(4).AlignBottom().Background(Colors.White)
                                .Column(column =>
                                {
                                    column.Item().Border(3).BorderColor("#2e3f4f").Image(eventImage);
                                });
                            }

                        });

                        var qrCode = _qrCodeCreator.Create(_ticket.QrCode.ToString());

                        innerTable.Cell().Row(1).Column(2).Width(102).Height(102).Image(qrCode);

                    });
                    table.Cell().Row(2).Column(3).Height(mediumRowHeightWidth).AlignMiddle().RotateRight().Text("Green ticket").FontColor("#62d04b").FontSize(borderFontSize).Bold();

                    table.Cell().Row(3).Column(1).Height(borderHeight);
                    table.Cell().Row(3).Column(2).Height(borderHeight).AlignCenter().Text("Green ticket").FontColor("#62d04b").FontSize(borderFontSize).Bold();
                    table.Cell().Row(3).Column(3).Height(borderHeight);
                });
        }



    }
}

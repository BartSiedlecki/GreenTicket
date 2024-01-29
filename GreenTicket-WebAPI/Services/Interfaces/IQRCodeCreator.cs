using System.Drawing;

namespace GreenTicket_WebAPI.Services.Interfaces
{
    public interface IQRCodeCreator
    {
        byte[] Create(string ticketCode);
    }
}
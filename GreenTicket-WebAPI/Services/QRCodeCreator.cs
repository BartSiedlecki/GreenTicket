using GreenTicket_WebAPI.Services.Interfaces;
using QRCoder;
using System.Drawing;

namespace GreenTicket_WebAPI.Services
{
    public class QRCodeCreator : IQRCodeCreator
    {
        public byte[] Create(string ticketCode)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticketCode, QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            if (qrCodeImage is null)
            {
                throw new Exception("Cannot create QR Code!");
            }

            byte[] qrCode2 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(qrCodeImage).ConvertTo(qrCodeImage, typeof(byte[]));

            return qrCode2;
        }
    }
}

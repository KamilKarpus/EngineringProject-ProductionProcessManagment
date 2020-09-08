using IronBarCode;
using Newtonsoft.Json;
using PPM.Printing.Application.Configuration.Services;
using System.Drawing;
using System.Threading.Tasks;

namespace PPM.Printing.Infrastructure.Services
{
    public class QrCodeService : IQrCodeService
    {
        private const int _size = 500;
        Task<Bitmap> IQrCodeService.CreateQrCode(QrCodeDTO dto)
        {
            var codeInfo = JsonConvert.SerializeObject(dto);
            var barcode = QRCodeWriter.CreateQrCode(codeInfo, _size, QRCodeWriter.QrErrorCorrectionLevel.Medium);
            return Task.FromResult(barcode.ToBitmap());
            
        }
    }
}

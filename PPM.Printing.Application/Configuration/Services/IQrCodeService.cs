using System.Drawing;
using System.Threading.Tasks;

namespace PPM.Printing.Application.Configuration.Services
{
    public interface IQrCodeService
    {
        Task<Bitmap> CreateQrCode(QrCodeDTO dto);
    }
}

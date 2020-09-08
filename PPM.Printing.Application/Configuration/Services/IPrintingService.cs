using System;
using System.Threading.Tasks;

namespace PPM.Printing.Application.Configuration.Services
{
    public interface IPrintingService
    {
        Task<QrResult> PrepareQRCode(Guid packageId);
    }
}

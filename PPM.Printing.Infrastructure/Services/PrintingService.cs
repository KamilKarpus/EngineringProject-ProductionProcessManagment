using PPM.Infrastructure.BlobStorage;
using PPM.Printing.Application.Configuration.Services;
using PPM.Printing.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace PPM.Printing.Infrastructure.Services
{
    public class PrintingService : IPrintingService
    {

        private readonly IPackageRepository _packageRepository;
        private readonly IQrCodeService _qrCodeService;
        private readonly IBlobStorage _storage;

        public PrintingService(IPackageRepository packageRepository, IQrCodeService qrCodeService, IBlobStorage storage)
        {
            _packageRepository = packageRepository;
            _qrCodeService = qrCodeService;
            _storage = storage;
        }

        public async Task<QrResult> PrepareQRCode(Guid packageId)
        {
            var packageinfo = await _packageRepository.GetById(packageId);
            var qrCodeDto = new QrCodeDTO()
            {
                OrderId = packageinfo.OrderId,
                PackageId = packageinfo.Id
            };
            var fileName = $"{packageinfo.Id}.jpg";
            var result = await _qrCodeService.CreateQrCode(qrCodeDto);
            var file = await _storage.SendAsBlob(result,fileName);
            return new QrResult(file.Url, fileName, packageId, packageinfo.OrderId);
        }
    }
}

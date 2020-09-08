using MediatR;
using PPM.Application;
using PPM.Printing.Application.Configuration.Commands;
using PPM.Printing.Application.Configuration.Services;
using PPM.Printing.Application.Configuration.Services.Notify;
using PPM.Printing.Domain.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Printing.Application.Commands.Internal
{
    public class CreateQrCodeCommandHandler : ICommandHandler<CreateQrCodeCommand>
    {

        private readonly IPrintingRequestRepository _repository;
        private readonly IPrintingService _service;
        private readonly IPrintingNotifyService _notifyService;
        public CreateQrCodeCommandHandler(IPrintingRequestRepository repository,
            IPrintingService service, IPrintingNotifyService notifyService)
        {
            _repository = repository;
            _service = service;
            _notifyService = notifyService;
        }
        public async Task<Unit> Handle(CreateQrCodeCommand request, CancellationToken cancellationToken)
        {
            var printingRequest = await _repository.GetById(request.RequestId);
            if(printingRequest != null)
            {
                try
                {
                    var result = await _service.PrepareQRCode(printingRequest.PackageId);
                    printingRequest.Successful(result.FileUrl, result.OrderId);
                    await _notifyService.Notify(result.OrderId, result.PackageId,
                        result.FileUrl);
                }
                catch (Exception)
                {
                    printingRequest.Fail();
                    throw;
                }
                finally
                {
                    await _repository.Update(printingRequest);
                   
                }
            }
            return Unit.Value;
        }
    }
}

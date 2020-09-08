using MediatR;
using PPM.Printing.Application.Configuration.Commands;
using PPM.Printing.Domain;
using PPM.Printing.Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Printing.Application.Commands.RequestPrinting
{
    public class PrintingRequestCommandHandler : ICommandHandler<RequestPrintingCommand>
    {
        private readonly IPrintingRequestRepository _repository;
        private readonly IPackageExistance _packageExistance;
        private readonly IPrintingRequestExistance _printingExistance;

        public PrintingRequestCommandHandler(IPrintingRequestRepository repository,
            IPackageExistance packageExistance, IPrintingRequestExistance printingRequestExistance)
        {
            _repository = repository;
            _packageExistance = packageExistance;
            _printingExistance = printingRequestExistance;
        }

        public async Task<Unit> Handle(RequestPrintingCommand request, CancellationToken cancellationToken)
        {
            var printingRequest = PrintingRequest.Create(request.Id, request.PackageId,
                _packageExistance, _printingExistance);
            await _repository.Add(printingRequest);
            return Unit.Value;
        }
    }
}

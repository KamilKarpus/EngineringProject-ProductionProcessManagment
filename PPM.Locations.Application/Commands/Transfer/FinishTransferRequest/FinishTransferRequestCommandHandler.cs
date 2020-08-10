using MediatR;
using PPM.Locations.Application.Configuration.Commands;
using PPM.Locations.Domain.Exceptions;
using PPM.Locations.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Transfer.FinishTransferRequest
{
    public class FinishTransferRequestCommandHandler : ICommandHandler<FinishTransferRequestCommand>
    {
        private readonly ITransferRequestRepository _repository;
        public FinishTransferRequestCommandHandler(ITransferRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(FinishTransferRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.TransferId);
            if(result == null)
            {
                throw new TransferException("Transfer not found", ErrorCodes.TransferNotFound);
            }
            result.Finish();
            await _repository.Update(result);
            return Unit.Value;
        }
    }
}

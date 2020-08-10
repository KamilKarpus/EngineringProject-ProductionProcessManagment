using MediatR;
using PPM.Locations.Application.Configuration.Commands;
using PPM.Locations.Domain;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.Domain.Transfer;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Transfer.CreateTransferRequest
{
    public class CreateTransferRequestCommandHandler : ICommandHandler<CreateTransferRequestCommand>
    {
        private readonly ITransferRequestRepository _repository;
        private readonly IGetLocationState _locationState;
        private readonly ILocationExistance _locationExistance;
        public CreateTransferRequestCommandHandler(ITransferRequestRepository repository,
            IGetLocationState locationState, ILocationExistance locationExistance)
        {
            _repository = repository;
            _locationState = locationState;
            _locationExistance = locationExistance;
        }
        public async Task<Unit> Handle(CreateTransferRequestCommand request, CancellationToken cancellationToken)
        {
            var transferRequest = TransferRequest.Create(request.Id, request.PackageId, request.FromLocationId, request.ToLocationId, request.RequestedByUser,
                _locationState, _locationExistance);
            await _repository.Add(transferRequest);
            return Unit.Value;

        }
    }
}

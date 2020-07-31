using MediatR;
using PPM.Locations.Application.Configuration.Commands;
using PPM.Locations.Domain;
using PPM.Locations.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.AddLocation
{
    public class AddLocationCommandHandler : ICommandHandler<AddLocationCommand>
    {
        private readonly ILocationsRepository _repository;
        private readonly IUniqueName _uniqueName;
        private readonly IUniqueShortName _uniqueShortName;
        public AddLocationCommandHandler(ILocationsRepository repository, IUniqueName uniqueName,
            IUniqueShortName uniqueShortName)
        {
            _repository = repository;
            _uniqueName = uniqueName;
            _uniqueShortName = uniqueShortName;
        }
        public async Task<Unit> Handle(AddLocationCommand request, CancellationToken cancellationToken)
        {
            var location = Location.Create(request.Id, request.Name, request.Type, request.Description, request.Width, request.Height,
                request.HandleQR, request.ShortName, _uniqueShortName, _uniqueName);
            await _repository.AddAsync(location);
            return Unit.Value;
        }
    }
}

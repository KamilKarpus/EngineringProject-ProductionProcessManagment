using MediatR;
using PPM.Locations.Application.Configuration.Commands;
using PPM.Locations.Domain;
using PPM.Locations.Domain.Exceptions;
using PPM.Locations.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.AddLocation
{
    public class AddLocationCommandHandler : ICommandHandler<AddLocationCommand>
    {
        private readonly ILocationsRepository _repository;
        public AddLocationCommandHandler(ILocationsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(AddLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetLocationByName(request.Name);
            if(location != null)
            {
                throw new LocationException("Location name is taken", ErrorCodes.LocatioNameIsTaken);
            }
            location = Location.Create(request.Id, request.Name, request.Type, request.Description, request.Width, request.Height,
                request.HandleQR, request.ShortName);
            await _repository.AddAsync(location);
            return Unit.Value;
        }
    }
}

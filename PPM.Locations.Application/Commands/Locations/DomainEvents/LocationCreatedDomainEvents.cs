using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.Queries.Locations;
using PPM.Locations.Domain.DomainEvents;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Locations.DomainEvents
{
    public class LocationCreatedDomainEvents : IDomainEventHandler<LocationCreatedDomainEvent>
    {
        private readonly IMongoRepository<LocationShortInfo> _repository;
        public LocationCreatedDomainEvents(IMongoRepository<LocationShortInfo> repository)
        {
            _repository = repository;
        }
        public async Task Handle(LocationCreatedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.LocationId);
            if(result == null)
            {
                await _repository.Add(new LocationShortInfo()
                {
                    Id = @event.LocationId,
                    Name = @event.Name
                });
            }
        }
    }
}

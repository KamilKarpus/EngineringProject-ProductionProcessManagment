using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.ReadModels;
using PPM.Locations.Domain.DomainEvents;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Locations.DomainEvents
{
    public class LocationReadModelDomainEventHandler : IDomainEventHandler<LocationCreatedDomainEvent>,
        IDomainEventHandler<PackageAddedDominEvent>, IDomainEventHandler<PackageDeletedDomainEvent>
    {
        private readonly IMongoRepository<LocationReadModel> _repository;
        public LocationReadModelDomainEventHandler(IMongoRepository<LocationReadModel> repository)
        {
            _repository = repository;
        }
        public async Task Handle(LocationCreatedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.LocationId);
            if(result == null)
            {
                await _repository.Add(new LocationReadModel()
                {
                    Id = @event.LocationId,
                    Height = @event.Height,
                    LocationType = @event.LocationType,
                    Name = @event.Name,
                    ShortName = @event.ShortName,
                    Width = @event.Width,
                    SupportQR = @event.SupportQR,
                    Description = @event.Description,
                    Length = @event.Length
                });
            }
        }

        public async Task Handle(PackageDeletedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.LocationId);
            if(result != null)
            {
                var package = result.Packages.FirstOrDefault(p => p.Id == @event.PackageId);
                result.Packages.Remove(package);
                await _repository.Update(p => p.Id == @event.LocationId, result);
            }
        }

        public async Task Handle(PackageAddedDominEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.LocationId);
            if (result != null)
            {
                result.Packages.Add(new PackageReadModel()
                {
                    Id = @event.PackageId,
                    Height = @event.Height,
                    Progress = @event.Progress,
                    Weight = @event.Weight,
                    Width = @event.Width,
                    Length = @event.Length
                });
                await _repository.Update(p => p.Id == @event.LocationId, result);
            }
        }
    }
}

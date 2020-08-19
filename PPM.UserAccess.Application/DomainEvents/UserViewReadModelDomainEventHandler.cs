using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.UserAccess.Application.ReadModels;
using PPM.UserAccess.Domain.Users.DomainEvents;
using System.Threading.Tasks;

namespace PPM.UserAccess.Application.DomainEvents
{
    public class UserViewReadModelDomainEventHandler : IDomainEventHandler<UserCreatedDomainEvent>,
        IDomainEventHandler<UserPermissionChangedDomainEvent>
    {
        private readonly IMongoRepository<UserReadModel> _repository;
        public UserViewReadModelDomainEventHandler(IMongoRepository<UserReadModel> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UserCreatedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.UserId);
            if (result == null)
            {
                await _repository.Add(new UserReadModel()
                {
                    FirstName = @event.FirstName,
                    RegisterDate = @event.RegisterDate,
                    Id = @event.UserId,
                    JobPosition = @event.JobPosition,
                    LastName = @event.LastName,
                    Login = @event.Login,
                    Permissions = @event.Permissions
                });
            }
        }

        public async Task Handle(UserPermissionChangedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.UserId);
            if(result != null)
            {
                result.Permissions = @event.Permissions;
                await _repository.Update(p => p.Id == @event.UserId, result);
            }
        }
    }
}

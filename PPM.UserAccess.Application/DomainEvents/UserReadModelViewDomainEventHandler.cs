using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.UserAccess.Application.ReadModels;
using PPM.UserAccess.Domain.Users.DomainEvents;
using System.Threading.Tasks;

namespace PPM.UserAccess.Application.DomainEvents
{
    public class UserReadModelViewDomainEventHandler : IDomainEventHandler<UserCreatedDomainEvent>
    {
        private readonly IMongoRepository<UserShortViewModel> _repository;
        public UserReadModelViewDomainEventHandler(IMongoRepository<UserShortViewModel> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UserCreatedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.UserId);
            if(result == null)
            {
                await _repository.Add(new UserShortViewModel()
                {
                    Id = @event.UserId,
                    RegistrationDate = @event.RegisterDate,
                    FirstName = @event.FirstName,
                    JobPosition = @event.JobPosition,
                    LastName = @event.LastName,
                    Login = @event.Login
                });
            }
        }
    }
}

using PPM.Domain;
using System.Threading.Tasks;

namespace PPM.Application.Events
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        Task Handle(T @event);
    }
}

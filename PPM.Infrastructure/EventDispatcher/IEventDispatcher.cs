using PPM.Domain;
using System.Threading.Tasks;

namespace PPM.Infrastructure.EventDispatcher
{
    public interface IEventDispatcher
    {
        Task DispatchAsync(params IDomainEvent[] events);
    }
}

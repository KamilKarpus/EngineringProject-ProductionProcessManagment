using PPM.Infrastructure.Eventbus;

namespace PPM.EventBus
{
    public class InMemoryEventBusClient : IEventsBus
    {
        //private readonly ILogger _logger;

        //public InMemoryEventBusClient(ILogger logger)
        //{
        //    _logger = logger;
        //}
        public void Publish<T>(T @event) where T : IntegrationEvent
        {
            InMemoryEventBus.Instance.Publish(@event);
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
        {
            InMemoryEventBus.Instance.Subscribe(handler);
        }

    }
}

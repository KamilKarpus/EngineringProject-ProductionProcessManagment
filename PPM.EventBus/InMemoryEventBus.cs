using Newtonsoft.Json;
using PPM.Infrastructure.Eventbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.EventBus
{
    public sealed class InMemoryEventBus
    {
        static InMemoryEventBus()
        {
        }

        private InMemoryEventBus()
        {
            _handlers = new List<HandlerSubscription>();
        }

        public static InMemoryEventBus Instance { get; } = new InMemoryEventBus();

        private readonly List<HandlerSubscription> _handlers;

        public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
        {
            _handlers.Add(new HandlerSubscription(handler, typeof(T).Name, typeof(T)));
        }

        public async Task Publish<T>(T @event) where T : IntegrationEvent
        {
            var eventType = @event.GetType();

            var integrationEventHandlers = _handlers.Where(x => x.EventName == eventType.Name).ToList();

            foreach (var integrationEventHandler in integrationEventHandlers)
            {
                var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(integrationEventHandler.EventType);
                var eventToPublish = TranslateType(@event, integrationEventHandler.EventType);
                await (Task)concreteType.GetMethod("Handle").Invoke(integrationEventHandler.Handler, new object[] { eventToPublish });
            }
        }

        private object TranslateType(object @object, Type type)
        {
            var contractResolver = new NonPublicPropertiesResolver();
            var settings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            };

            var json = JsonConvert.SerializeObject(@object);
            var receiverType = JsonConvert.DeserializeObject(json, type, settings);
            return receiverType;
        }

        private class HandlerSubscription
        {
            public HandlerSubscription(IIntegrationEventHandler handler, string eventName, Type eventType)
            {
                Handler = handler;
                EventName = eventName;
                EventType = eventType;
            }

            public IIntegrationEventHandler Handler { get; }
            public Type EventType { get; }
            public string EventName { get; }
        }
    }
}

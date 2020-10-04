using Autofac;
using PPM.Application;

namespace PPM.Administration.Infrastucture.Configuration.Notify
{
    public class NotifyModule : Autofac.Module
    {
        private readonly IHubClient _client;
        public NotifyModule(IHubClient client)
        {
            _client = client;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_client)
                .As<IHubClient>();
        }
    }
}

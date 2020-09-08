using Autofac;
using PPM.Application;
using PPM.Printing.Application.Configuration.Services.Notify;
using PPM.Printing.Infrastructure.Services;

namespace PPM.Printing.Infrastructure.Configuration.Hub
{
    public class HubModule : Autofac.Module
    {
        private readonly IHubClient _client;
        public HubModule(IHubClient client)
        {
            _client = client;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_client).As<IHubClient>();
            builder.RegisterType<PrintingNotifyService>().As<IPrintingNotifyService>();
        }
    }
}

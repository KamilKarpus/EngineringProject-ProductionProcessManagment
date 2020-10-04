using Autofac;
using MediatR;
using PPM.Application.ModuleClient;
using PPM.Locations.Application.Queries.PackageInfo;
using PPM.Locations.Application.ReadModels;

namespace PPM.Locations.Infrastructure.Configuration.InternalClient
{
    public static class InternalClientStartup
    {
        public static void Initialize()
        {
            var client = LocationCompositionRoot.BeginLifetimeScope()
                .Resolve<IModuleClient>();
            var mediator = LocationCompositionRoot.BeginLifetimeScope()
                .Resolve<IMediator>();

            client.AddEndpointDispatcher("internal/locations", mediator);
            client.AddEndpointDefination<GetPackageInfoQuery, PackageInfoReadModel>("internal/locations", MethodsHttp.GET);
        }
    }
}

using Autofac;
using MediatR;
using PPM.Application.ModuleClient;
using PPM.Printing.Application.Queries.GetOrderPrinting;
using System.Collections.Generic;

namespace PPM.Printing.Infrastructure.Configuration.InternalClient
{
    public static class InternalClientStartup
    {
        public static void Initialize()
        {
            var client = PrintingCompositionRoot.BeginLifetimeScope()
                .Resolve<IModuleClient>();
            var mediator = PrintingCompositionRoot.BeginLifetimeScope()
                .Resolve<IMediator>();

            client.AddEndpointDispatcher("internal/printing", mediator);
            client.AddEndpointDefination<GetOrderPrintingQuery, List<OrderPrintingDTO>>("internal/printing", MethodsHttp.GET);
        }
    }
}

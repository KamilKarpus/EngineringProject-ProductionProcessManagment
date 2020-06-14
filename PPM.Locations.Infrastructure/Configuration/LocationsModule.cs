using Autofac;
using MediatR;
using PPM.Locations.Application;
using PPM.Locations.Application.Configuration.Commands;
using PPM.Locations.Application.Configuration.Queries;
using System.Threading.Tasks;

namespace PPM.Locations.Infrastructure.Configuration
{
    public class LocationsModule : ILocationModule
    {
        public async Task ExecuteCommand(ICommand command)
        {
            using (var scope = LocationCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            using (var scope = LocationCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            using (var scope = LocationCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}

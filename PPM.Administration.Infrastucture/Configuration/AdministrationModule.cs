using Autofac;
using MediatR;
using PPM.Administration.Application;
using PPM.Administration.Application.Configuration.Commands;
using PPM.Administration.Application.Configuration.Queries;
using System.Threading.Tasks;

namespace PPM.Administration.Infrastucture.Configuration
{
    public class AdministrationModule : IAdministrationModule
    {
        public async Task ExecuteCommand(ICommand command)
        {
            using (var scope = AdministrationCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            using (var scope = AdministrationCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            using (var scope = AdministrationCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}

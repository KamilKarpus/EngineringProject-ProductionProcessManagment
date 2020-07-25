using Autofac;
using MediatR;
using PPM.UserAccess.Application;
using PPM.UserAccess.Application.Configuration.Commands;
using PPM.UserAccess.Application.Configuration.Queries;
using System.Threading.Tasks;

namespace PPM.UserAccess.Infrastructure.Configuration
{
    public class UserModule : IUserAccessModule
    {
        public async Task ExecuteCommand(ICommand command)
        {
            using (var scope = UserCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            using (var scope = UserCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            using (var scope = UserCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}

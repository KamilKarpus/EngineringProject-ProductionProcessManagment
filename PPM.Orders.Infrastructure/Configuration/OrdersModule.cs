using Autofac;
using MediatR;
using PPM.Orders.Application.Configuration;
using PPM.Orders.Application.Configuration.Commands;
using PPM.Orders.Application.Configuration.Queries;
using System.Threading.Tasks;

namespace PPM.Orders.Infrastructure.Configuration
{
    public class OrdersModule : IOrdersModule
    {
        public async Task ExecuteCommand(ICommand command)
        {
            using (var scope = OrderCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            using (var scope = OrderCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            using (var scope = OrderCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}

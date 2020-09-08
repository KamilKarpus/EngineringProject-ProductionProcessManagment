using Autofac;
using MediatR;
using PPM.Printing.Application;
using PPM.Printing.Application.Configuration.Commands;
using PPM.Printing.Application.Configuration.Queries;
using System.Threading.Tasks;

namespace PPM.Printing.Infrastructure.Configuration
{
    public class PrintingModule : IPrintingModule
    {
        public async Task ExecuteCommand(ICommand command)
        {
            using (var scope = PrintingCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            using (var scope = PrintingCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            using (var scope = PrintingCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(query);
            }
        }
    }
}

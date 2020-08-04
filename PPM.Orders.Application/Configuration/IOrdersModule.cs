using PPM.Orders.Application.Configuration.Commands;
using PPM.Orders.Application.Configuration.Queries;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Configuration
{
    public interface IOrdersModule
    {
        Task ExecuteCommand(ICommand command);
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
    }
}

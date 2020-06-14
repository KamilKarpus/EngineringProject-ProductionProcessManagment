using PPM.Locations.Application.Configuration.Commands;
using PPM.Locations.Application.Configuration.Queries;
using System.Threading.Tasks;

namespace PPM.Locations.Application
{
    public interface ILocationModule
    {
        Task ExecuteCommand(ICommand command);
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
    }
}

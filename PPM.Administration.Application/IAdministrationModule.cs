using PPM.Administration.Application.Configuration.Commands;
using PPM.Administration.Application.Configuration.Queries;
using System.Threading.Tasks;

namespace PPM.Administration.Application
{
    public interface IAdministrationModule
    {
        Task ExecuteCommand(ICommand command);
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
    }
}

using PPM.UserAccess.Application.Configuration.Commands;
using PPM.UserAccess.Application.Configuration.Queries;
using System.Threading.Tasks;

namespace PPM.UserAccess.Application
{
    public interface IUserAccessModule
    {
        Task ExecuteCommand(ICommand command);
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
    }
}

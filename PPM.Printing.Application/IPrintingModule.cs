using PPM.Printing.Application.Configuration.Commands;
using PPM.Printing.Application.Configuration.Queries;
using System.Threading.Tasks;

namespace PPM.Printing.Application
{
    public interface IPrintingModule
    {
        Task ExecuteCommand(ICommand command);
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
    }
}

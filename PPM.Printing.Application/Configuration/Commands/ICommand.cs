using MediatR;

namespace PPM.Printing.Application.Configuration.Commands
{
    public interface ICommand : IRequest
    {

    }
    public interface ICommand<TReponse> : IRequest<TReponse>
    {

    }
}

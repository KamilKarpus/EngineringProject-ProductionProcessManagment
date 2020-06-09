using MediatR;

namespace PPM.Administration.Application.Configuration.Commands
{
    public interface ICommand : IRequest
    {

    }
    public interface ICommand<TReponse> : IRequest<TReponse>
    {

    }
}

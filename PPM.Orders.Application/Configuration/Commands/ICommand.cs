using MediatR;

namespace PPM.Orders.Application.Configuration.Commands
{
    public interface ICommand : IRequest
    {

    }
    public interface ICommand<TReponse> : IRequest<TReponse>
    {

    }
}

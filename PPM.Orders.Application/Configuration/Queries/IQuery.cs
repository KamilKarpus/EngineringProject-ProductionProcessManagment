using MediatR;

namespace PPM.Orders.Application.Configuration.Queries
{
    public interface IQuery<Result> : IRequest<Result>
    {
    }
}

using MediatR;

namespace PPM.Orders.Application.Configuration.Queries
{
    internal interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}

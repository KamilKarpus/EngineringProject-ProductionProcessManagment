using MediatR;

namespace PPM.Administration.Application.Configuration.Queries
{
    internal interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}

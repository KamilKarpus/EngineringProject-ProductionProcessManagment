using MediatR;

namespace PPM.Administration.Application.Configuration.Queries
{
    public interface IQuery<Result> : IRequest<Result>
    {
    }
}

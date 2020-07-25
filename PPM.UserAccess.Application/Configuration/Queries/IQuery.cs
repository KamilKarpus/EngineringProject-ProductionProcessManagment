using MediatR;

namespace PPM.UserAccess.Application.Configuration.Queries
{
    public interface IQuery<Result> : IRequest<Result>
    {
    }
}

using MediatR;

namespace PPM.Locations.Application.Configuration.Queries
{
    public interface IQuery<Result> : IRequest<Result>
    {
    }
}

using MediatR;

namespace PPM.Printing.Application.Configuration.Queries
{
    public interface IQuery<Result> : IRequest<Result>
    {
    }
}

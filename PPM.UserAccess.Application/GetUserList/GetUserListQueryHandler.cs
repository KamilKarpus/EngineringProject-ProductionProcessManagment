using MongoDB.Driver;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.Paggination;
using PPM.UserAccess.Application.Configuration.Queries;
using PPM.UserAccess.Application.ReadModels;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.UserAccess.Application.GetUserList
{
    public class GetUserListQueryHandler : IQueryHandler<GetUserListQuery, PagedList<UserShortViewModel>>
    {
        private readonly IMongoRepository<UserShortViewModel> _repository;
        public GetUserListQueryHandler(IMongoRepository<UserShortViewModel> repository)
        {
            _repository = repository;
        }
        public Task<PagedList<UserShortViewModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _repository.Collection.AsQueryable().ToPagedList(request.PageNumber, request.PageSize)
                );
        }
    }
}

using MongoDB.Driver;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.UserAccess.Application.Configuration.Queries;
using PPM.UserAccess.Application.ReadModels;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.UserAccess.Application.GetUserInfoById
{
    public class GetUserInfoByIdQueryHandler : IQueryHandler<GetUserInfoByIdQuery, UserReadModel>
    {
        private readonly IMongoRepository<UserReadModel> _repository;
        public GetUserInfoByIdQueryHandler(IMongoRepository<UserReadModel> repository)
        {
            _repository = repository;
        }
        public async Task<UserReadModel> Handle(GetUserInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Find(p => p.Id == request.UserId);
            return result;
        }
    }
}

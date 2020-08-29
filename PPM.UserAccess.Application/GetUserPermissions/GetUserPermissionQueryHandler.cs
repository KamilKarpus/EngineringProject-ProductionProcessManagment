using PPM.Infrastructure.DataAccess.Repositories;
using PPM.UserAccess.Application.Configuration.Queries;
using PPM.UserAccess.Application.ReadModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.UserAccess.Application.GetUserPermissions
{
    public class GetUserPermissionQueryHandler : IQueryHandler<GetUserPermissionQuery, List<PermissionDTO>>
    {
        private readonly IMongoRepository<UserReadModel> _repository;
        public GetUserPermissionQueryHandler(IMongoRepository<UserReadModel> repository)
        {
            _repository = repository;
        }
        public async Task<List<PermissionDTO>> Handle(GetUserPermissionQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Find(p => p.Id == request.UserId);
            var dtos = result.Permissions.Select(p => new PermissionDTO(p)).ToList();
            return dtos;
        }
    }
}

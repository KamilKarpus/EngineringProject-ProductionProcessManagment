using MediatR;
using PPM.UserAccess.Application.Configuration.Commands;
using PPM.UserAccess.Domain.Users;
using PPM.UserAccess.Domain.Users.Exception;
using PPM.UserAccess.Domain.Users.Repository;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UserAccess.Domain.Users.Rules;

namespace PPM.UserAccess.Application.ChangeUserrPermissions
{
    public class ChangeUserPermissionsCommandHandler : ICommandHandler<ChangeUserPermissionsCommand>
    {
        private IUserRepository _repository;
        public ChangeUserPermissionsCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ChangeUserPermissionsCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);
            if(user == null)
            {
                throw new UserException("User not found", ErrorCodes.UserNotFound);
            }
            var permissions = request.Permissions.Select(p => UserPermission.Of(p));
            user.ChangePermissions(permissions);
            await _repository.Update(user);
            return Unit.Value;
        }
    }
}

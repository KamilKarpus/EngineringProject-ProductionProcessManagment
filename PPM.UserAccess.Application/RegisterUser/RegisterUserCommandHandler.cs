using MediatR;
using PPM.UserAccess.Application.Configuration.Commands;
using PPM.UserAccess.Domain.Users;
using PPM.UserAccess.Domain.Users.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.UserAccess.Application.RegisterUser
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserLoginAvailability _loginAvailability;
        public RegisterUserCommandHandler(IUserRepository repository,
            IUserLoginAvailability loginAvailability)
        {
            _repository = repository;
            _loginAvailability = loginAvailability;
        }
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var password = PasswordManager.HashPassword(request.Password);

            var user = User.CreateUser(request.Id, request.Login, password,
                request.FirstName, request.LastName, request.JobPosition, _loginAvailability);

            await _repository.Add(user);
            return Unit.Value;
        }
    }
}

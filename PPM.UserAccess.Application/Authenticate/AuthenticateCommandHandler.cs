using PPM.UserAccess.Application.Configuration;
using PPM.UserAccess.Application.Configuration.Commands;
using PPM.UserAccess.Domain.Users.Repository;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.UserAccess.Application.Authenticate
{
    public class AuthenticateCommandHandler : ICommandHandler<AuthenticateCommand, AuthenticationResult>
    {
        private readonly IUserRepository _repository;
        public AuthenticateCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<AuthenticationResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByLogin(request.Login);
            if(user == null)
            {
                return new AuthenticationResult("User not exists");
            }
            if(!PasswordManager.VerifyHashedPassword(user.Password, request.Password))
            {
                return new AuthenticationResult("Invalid password");
            }

            var claims = user.Permissions?.Select(p => new Claim(CustomClaimTypes.Permissions, p.Permission)).ToList();
            claims.Add(new Claim(CustomClaimTypes.Login, user.Login));
            claims.Add(new Claim(CustomClaimTypes.Name, user.FullName));

            return new AuthenticationResult(
                new UserDTO()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Login = user.Login,
                    JobPosition = user.JobPosition,
                    Claims = claims
                });
        }
    }
}

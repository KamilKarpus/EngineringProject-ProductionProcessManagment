using IdentityServer4.Models;
using IdentityServer4.Validation;
using PPM.UserAccess.Application;
using PPM.UserAccess.Application.Authenticate;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Users
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserAccessModule _userAccessModule;

        public ResourceOwnerPasswordValidator(IUserAccessModule userAccessModule)
        {
            _userAccessModule = userAccessModule;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var authenticationResult = await _userAccessModule.ExecuteCommandAsync(new AuthenticateCommand()
            {
                Login = context.UserName,
                Password = context.Password
            });
            if (!authenticationResult.IsAuthenticate)
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    authenticationResult.AuthenticateError);
                return;
            }
            context.Result = new GrantValidationResult(
                authenticationResult.User.Id.ToString(),
                "forms",
                authenticationResult.User.Claims);
        }
    }
}

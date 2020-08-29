using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Api.Configuration.Authorization;
using PPM.UserAccess.Application;
using PPM.UserAccess.Application.ChangeUserrPermissions;
using PPM.UserAccess.Application.RegisterUser;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Users
{
    [ApiController, Route("api/users"), Authorize]
    [HasPermission(UsersPermissions.ManageUsers)]
    public class UserCommandApi : Controller
    {
        private readonly IUserAccessModule _module;
        public UserCommandApi(IUserAccessModule module)
        {
            _module = module;
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Add new user")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewUser([FromBody]RegisterUser user)
        {
            var id = Guid.NewGuid();
            await _module.ExecuteCommand(new RegisterUserCommand()
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                JobPosition = user.JobPosition,
                Login = user.Login,
                Password = user.Password
            });
            return Created("api/users/", new { id = id });
        }

        [HttpPut("{userId}/permissions")]
        [SwaggerOperation(Summary = "Upadate user permissions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePermissions(Guid userId, [FromBody] ChangeUserPermissions permissions)
        {
            await _module.ExecuteCommand(new ChangeUserPermissionsCommand()
            {
                Id = userId,
                Permissions = permissions.Permissions
            });
            return Ok();
        }
    }
}

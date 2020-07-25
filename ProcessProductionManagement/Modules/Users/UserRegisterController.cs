using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.UserAccess.Application;
using PPM.UserAccess.Application.RegisterUser;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Users
{
    [ApiController, Route("api/users")]
    public class UserRegisterController : Controller
    {
        private readonly IUserAccessModule _module;
        public UserRegisterController(IUserAccessModule module)
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
    }
}

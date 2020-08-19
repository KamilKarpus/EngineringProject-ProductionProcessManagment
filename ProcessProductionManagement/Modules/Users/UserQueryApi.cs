using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Infrastructure.Paggination;
using PPM.UserAccess.Application;
using PPM.UserAccess.Application.GetUserInfoById;
using PPM.UserAccess.Application.GetUserList;
using PPM.UserAccess.Application.ReadModels;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Users
{
    [ApiController, Route("api/users")]
    public class UserQueryApi : Controller
    {
        private readonly IUserAccessModule _module;
        public UserQueryApi(IUserAccessModule module)
        {
            _module = module;
        }
        [HttpGet]
        [SwaggerOperation(Summary = "Get list of user")]
        [ProducesResponseType(typeof(PagedList<UserShortViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserList([FromQuery]GetUserList query)
        {
            var result = await _module.ExecuteQuery(new GetUserListQuery()
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            });
            return Ok(result);
        }

        [HttpGet("{userId}")]
        [SwaggerOperation(Summary = "Get list of user")]
        [ProducesResponseType(typeof(UserReadModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserInfoId(Guid userId)
        {
            var result = await _module.ExecuteQuery(new GetUserInfoByIdQuery
            {
                UserId = userId
            });
            return Ok(result);
        }
    }
}

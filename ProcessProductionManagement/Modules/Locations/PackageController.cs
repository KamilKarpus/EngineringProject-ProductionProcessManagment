using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Api.Configuration.Authorization;
using PPM.Locations.Application;
using PPM.Locations.Application.Queries;
using PPM.Locations.Application.Queries.GetRecommendation;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Locations
{
    [ApiController, Route("api/packages"), Authorize]
    [HasPermission(LocationPermissions.View)]
    public class PackageController : ControllerBase
    {

        private readonly ILocationModule _module;
        public PackageController(ILocationModule module)
        {
            _module = module;
        }

        [HttpGet("{packageId}/recommendation")]
        [SwaggerOperation(Summary = "Get recommendation for package")]
        [ProducesResponseType(typeof(LocationShortInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLocationShortInfo(Guid packageId)
        {
            var result = await _module.ExecuteQuery(new GetRecommendationQuery() 
            {
                PackageId = packageId
            });
            return Ok(result);
        }
    }
}

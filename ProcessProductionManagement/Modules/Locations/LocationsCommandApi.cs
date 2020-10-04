using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Api.Configuration.Authorization;
using PPM.Api.Modules.Locations;
using PPM.Locations.Application;
using PPM.Locations.Application.Commands;
using PPM.Locations.Application.Commands.AddLocation;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Locations
{
    [ApiController, Route("api/locations"), Authorize]
    [HasPermission(LocationPermissions.CanEditLocation)]
    public class LocationsCommandApi : Controller
    {
        private readonly ILocationModule _module;
        public LocationsCommandApi(ILocationModule module)
        {
            _module = module;
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Create new location")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewLocation([FromBody]Commands.V1.AddLocation location)
        {
            var locationId = Guid.NewGuid();
            await _module.ExecuteCommand(new AddLocationCommand
            {
                Id = locationId,
                ShortName = location.ShortName,
                Description = location.Description,
                HandleQR = location.HandleQR,
                Height = location.Height,
                Name = location.Name,
                Type = location.Type,
                Width = location.Width,
                Length = location.Length
            });
            return Created("api/locations/", new { id = locationId });
        }
    }
}

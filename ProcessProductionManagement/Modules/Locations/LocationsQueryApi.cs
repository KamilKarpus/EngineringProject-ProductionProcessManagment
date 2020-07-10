﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Locations.Application;
using PPM.Locations.Application.Queries;
using PPM.Locations.Application.Queries.Locations;
using PPM.Locations.Application.Queries.LocationsByName;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Locations
{
    [ApiController, Route("api/locations")]
    public class LocationsQueryApi : Controller
    {
        private readonly ILocationModule _module;
        public LocationsQueryApi(ILocationModule module)
        {
            _module = module;
        }
        [HttpGet]
        [SwaggerOperation(Summary = "Get list of locations short info")]
        [ProducesResponseType(typeof(List<LocationShortInfo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLocationShortInfo()
        {
            var result = await _module.ExecuteQuery(new GetLocationsShortInfoListQuery());
            return Ok(result);
        }
        [HttpGet("byName")]
        [SwaggerOperation(Summary = "Get list of locations by name")]
        [ProducesResponseType(typeof(List<LocationShortInfo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLocationShortInfoByName([FromQuery]Queries.V1.GetLocationByNameShortInfo query)
        {
            var result = await _module.ExecuteQuery(new GetLocationsByNameQuery()
            {
                Name = query.Name
            });
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Administration.Application;
using PPM.Administration.Application.Queries;
using PPM.Administration.Application.Queries.ProductionFlows.GetFlowInfo;
using PPM.Administration.Application.Queries.ProductionFlows.GetFlowsList;
using PPM.Administration.Application.ReadModels;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Administration
{
    [ApiController, Route("api/administration")]
    public class AdministrationQueryApi : Controller
    {
        private readonly IAdministrationModule _module;
        public AdministrationQueryApi(IAdministrationModule module)
        {
            _module = module;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get production flow short info")]
        [ProducesResponseType(typeof(List<ProductionFlowShortInfo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFlowList([FromQuery]Queries.V1.GetProductionInfoListQuery query)
        {
            var result = await _module.ExecuteQuery(new GetProductionInfoListQuery()
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            });
            return Ok(result);
        }
        [HttpGet("{flowId}")]
        [SwaggerOperation(Summary = "Get production flow by Id")]
        [ProducesResponseType(typeof(ProductionFlowReadModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductionFlowById(Guid flowId)
        {
            var result = await _module.ExecuteQuery(new GetFlowInfoByIdQuery()
            {
                Id = flowId
            });
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Administration.Application;
using PPM.Administration.Application.Queries.ProductionFlows.GetFlowsList;
using Swashbuckle.AspNetCore.Annotations;
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
        public async Task<IActionResult> GetFlowList()
        {
            var result = await _module.ExecuteQuery(new GetProductionInfoListQuery());
            return Ok(result);
        }
    }
}

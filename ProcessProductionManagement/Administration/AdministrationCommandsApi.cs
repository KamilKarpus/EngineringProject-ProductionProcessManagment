using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Administration.Application;
using PPM.Administration.Application.Commands;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Administration
{
    [ApiController, Route("api/administration")]
    public class AdministrationCommandsApi : Controller
    {
        private readonly IAdministrationModule _module;
        public AdministrationCommandsApi(IAdministrationModule module)
        {
            _module = module;
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Create new production flow definition")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewProductionFlow([FromBody]Commands.V1.AddProductionFlow flow)
        {
            var flowId = Guid.NewGuid();
            await _module.ExecuteCommand(new AddProductionFlowCommand()
            {
                Id = flowId,
                Name = flow.Name
            });
            return Created("api/administration/", new { id = flowId });
        }
    }
}

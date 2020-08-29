using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Administration.Application;
using PPM.Administration.Application.Commands;
using PPM.Administration.Application.Commands.AddStep;
using PPM.Administration.Application.Commands.Flows.ChangeFlowStatus;
using PPM.Administration.Application.Commands.Flows.ChangeStepPosition;
using PPM.Api.Configuration.Authorization;
using PPM.Api.Modules.Administration;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Administration
{
    [ApiController, Route("api/administration"), Authorize]
    public class AdministrationCommandsApi : Controller
    {
        private readonly IAdministrationModule _module;
        public AdministrationCommandsApi(IAdministrationModule module)
        {
            _module = module;
        }
        [HttpPost]
        [HasPermission(AdministrationPermissions.EditFlow)]
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
        [HttpPost("{flowId}/steps")]
        [HasPermission(AdministrationPermissions.EditFlow)]
        [SwaggerOperation(Summary = "Add new Step")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStep(Guid flowId, [FromBody]Commands.V1.AddStep step)
        {
            var stepId = Guid.NewGuid();
            await _module.ExecuteCommand(new AddStepCommand
            {
                Id = stepId,
                Days = step.Days,
                LocationId = step.LocationId,
                Name = step.Name,
                Percentage = step.Percentage,
                ProductionFlowId = flowId
            });
            return Created($"api/administration/{flowId}/steps/", new { id = stepId });
        }
        [HttpPut("{flowId}")]
        [HasPermission(AdministrationPermissions.EditFlow)]
        [SwaggerOperation(Summary = "Change flow status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangeFlowStatus(Guid flowId, [FromBody]Commands.V1.ChangeStatus status)
        {
            await _module.ExecuteCommand(new ChangeFlowStatusCommand()
            {
                FlowId = flowId,
                StatusId = status.StatusId
            });
            return Ok();
        }
        [HttpPut("{flowId}/stepsPosition")]
        [HasPermission(AdministrationPermissions.EditFlow)]
        [SwaggerOperation(Summary = "Change step position")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangeStepPostion(Guid flowId, [FromBody]Commands.V1.ChangeStepPosition body)
        {
            await _module.ExecuteCommand(new ChangeStepPositionCommnad()
            {
                FlowId = flowId,
                StepId = body.StepId,
                StepNumber = body.StepNumber
            });
            return Ok();
        }

    }
}

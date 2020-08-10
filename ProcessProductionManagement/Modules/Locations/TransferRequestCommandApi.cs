using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Locations.Application;
using PPM.Locations.Application.Commands;
using PPM.Locations.Application.Commands.Transfer.CreateTransferRequest;
using PPM.Locations.Application.Commands.Transfer.FinishTransferRequest;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Locations
{
    [ApiController, Route("api/transfer")]
    public class TransferRequestCommandApi : Controller
    {
        private readonly ILocationModule _module;
        public TransferRequestCommandApi(ILocationModule module)
        {
            _module = module;
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Create new transfer request")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewTransfer([FromBody]Commands.V1.CreateTransfer transfer)
        {
            var transferId = Guid.NewGuid();
            await _module.ExecuteCommand(new CreateTransferRequestCommand()
            {
                Id = transferId,
                FromLocationId = transfer.FromLocationId,
                PackageId = transfer.PackageId,
                RequestedByUser = Guid.NewGuid(),
                ToLocationId = transfer.ToLocationId
            });
            return Created("api/transfer/", new { id = transferId });
        }
        [HttpPut("{transferId}")]
        [SwaggerOperation(Summary = "Finish Transfer")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTransferStatus(Guid transferId)
        {
            await _module.ExecuteCommand(new FinishTransferRequestCommand()
            {
                TransferId = transferId
            });
            return Ok();
        }
    }
}

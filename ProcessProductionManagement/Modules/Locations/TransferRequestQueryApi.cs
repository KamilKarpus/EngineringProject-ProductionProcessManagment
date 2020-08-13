using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Locations.Application;
using PPM.Locations.Application.Queries.Transfer;
using PPM.Locations.Application.ReadModels;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Locations
{
    [ApiController, Route("api/transfer")]
    public class TransferRequestQueryApi : Controller
    {
        private readonly ILocationModule _module;
        public TransferRequestQueryApi(ILocationModule module)
        {
            _module = module;
        }
        [HttpGet("{transferId}")]
        [SwaggerOperation(Summary = "Get transfer request by Id")]
        [ProducesResponseType(typeof(TransferReadModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTransferById(Guid transferId)
        {
            var result = await _module.ExecuteQuery(new GetTransferInfoQuery()
            {
                TransferId = transferId
            });
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPM.Printing.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPM.Printing.Application.Commands;
using PPM.Printing.Application.Commands.RequestPrinting;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;

namespace PPM.Api.Modules.Printing
{
    [ApiController, Route("api/printing"), Authorize]
    public class PrintingCommnadApi : ControllerBase
    {
        private readonly IPrintingModule _module;
        public PrintingCommnadApi(IPrintingModule module)
        {
            _module = module;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Request new printing")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RequestPrinting(Commands.V1.RequestPrinting request)
        {
            var id = Guid.NewGuid();
            await _module.ExecuteCommand(new RequestPrintingCommand()
            {
                Id = id,
                PackageId = request.PackageId
            });
            return Created("api/printing/", new { id = id });
        }
    }
}

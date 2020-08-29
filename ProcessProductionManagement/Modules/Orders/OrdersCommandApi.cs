using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Api.Configuration.Authorization;
using PPM.Orders.Application.Commands;
using PPM.Orders.Application.Commands.Orders.AddNewOrder;
using PPM.Orders.Application.Commands.Orders.AddPackage;
using PPM.Orders.Application.Configuration;
using PPM.Orders.Domain;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Orders
{
    [ApiController, Route("api/orders"), Authorize]
    [HasPermission(OrderPermissions.View)]
    public class OrdersCommandApi : Controller
    {
        private readonly IOrdersModule _module;
        public OrdersCommandApi(IOrdersModule module)
        {
            _module = module;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new Order")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOder([FromBody]Commands.V1.AddNewOrder order)
        {
            var id = Guid.NewGuid();
            await _module.ExecuteCommand(new AddNewOrderCommand()
            {
                Id = id,
                DeliveryDate = order.DeliveryDate,
                CompanyName = order.CompanyName,
                Description = order.Description
            });
            return Created("api/orders/", new { id = id });
        }
        [HttpPost("{orderId}/package")]
        [SwaggerOperation(Summary = "Add new package")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPackage(Guid orderId, [FromBody]Commands.V1.AddPackage package)
        {
            var id = Guid.NewGuid();
            await _module.ExecuteCommand(new AddPackageCommand()
            {
                PackageId = id,
                OrderId = orderId,
                FlowId = package.FlowId,
                Height = package.Height,
                Weight = package.Weight,
                Width = package.Width
            });
            return Created($"api/orders/{orderId}/package", new { id = id });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Orders.Application.Commands;
using PPM.Orders.Application.Commands.Orders.AddNewOrder;
using PPM.Orders.Application.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Orders
{
    [ApiController, Route("api/orders")]
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
        public async Task<IActionResult> AddOder(Commands.V1.AddNewOrder order)
        {
            var id = Guid.NewGuid();
            await _module.ExecuteCommand(new AddNewOrderCommand()
            {
                Id = id,
                FlowId = order.FlowId,
                DeliveryDate = order.DeliveryDate,
                CompanyName = order.CompanyName
            });
            return Created("api/orders/", new { id = id });
        }
    }
}

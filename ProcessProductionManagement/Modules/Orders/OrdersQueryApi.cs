using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPM.Infrastructure.Paggination;
using PPM.Orders.Application.Configuration;
using PPM.Orders.Application.Queries;
using PPM.Orders.Application.Queries.GetOrderInfo;
using PPM.Orders.Application.ReadModels;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Orders
{
    [ApiController, Route("api/orders")]
    public class OrdersQueryApi : Controller
    {
        private readonly IOrdersModule _module;
        public OrdersQueryApi(IOrdersModule module)
        {
            _module = module;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get orders list")]
        [ProducesResponseType(typeof(PagedList<OrderShortViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrdersList([FromQuery]Queries.V1.OrderListQuery query)
        {
            var result = await _module.ExecuteQuery(new GetOrderListQuery()
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get order info")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrderAsync(Guid id)
        {
            var result = await _module.ExecuteQuery(new GetOrderInfoQuery()
            {
                OrderId = id
            });
            return Ok(result);
        }
    }
}

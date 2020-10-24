using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Orders
{
    [Authorize]
    public class OrdersHub : Hub
    {
        [HubMethodName("createResource")]
        public async Task CreateResource(string orderId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, orderId);
            var group = Clients.Group(orderId);
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using PPM.Api.Modules.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Api.Configuration.SignalR
{
    public class OrderHubClient : IOrdersHubClient
    {
        private readonly IHubContext<OrdersHub> _context;

        public OrderHubClient(IHubContext<OrdersHub> context)
        {
            _context = context;
        }
        public async Task Notify<T>(params T[] data)
        {
            await _context.Clients.All.SendAsync("ordersStatus", data);
        }

        public async Task Notify<T>(string groupName, T data)
        {
            await _context.Clients.Group(groupName).SendAsync("ordersStatus", data);
        }

        public async Task Notify<T>(T data)
        {
            await _context.Clients.All.SendAsync("ordersStatus", data);
        }

        public async Task Notify<T>(string resource, string groupName, T data)
        {
            await _context.Clients.Group(groupName).SendAsync(resource, data);
        }

        public async Task NotifyResource<T>(string resource, T data)
        {
            await _context.Clients.All.SendAsync(resource, data);
        }
    }
}

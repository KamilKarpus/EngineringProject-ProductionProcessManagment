using Microsoft.AspNetCore.SignalR;
using PPM.Api.Modules.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Api.Configuration.SignalR
{
    public class AdministrationHubClient : IAdministrationHubClient
    {
        private readonly IHubContext<AdministrationHub> _context;
        public AdministrationHubClient(IHubContext<AdministrationHub> context)
        {
            _context = context;
        }
        public async Task Notify<T>(params T[] data)
        {
            await _context.Clients.All.SendAsync("flow", data);        
        }

        public async Task Notify<T>(string groupName, T data)
        {
            await _context.Clients.Group(groupName).SendAsync("flow", data);        
        }

        public async Task Notify<T>(T data)
        {
            await _context.Clients.All.SendAsync("flow", data);
        }

        public Task Notify<T>(string resource, string groupName, T data)
        {
            throw new NotImplementedException();
        }

        public Task NotifyResource<T>(string resource, T data)
        {
            throw new NotImplementedException();
        }
    }
}

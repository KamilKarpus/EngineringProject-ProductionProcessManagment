using Microsoft.AspNetCore.SignalR;
using PPM.Api.Modules.Printing;
using PPM.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Api.Configuration.SignalR
{
    public class PrintingHubClient : IPrintingHubClient

    {
        private readonly IHubContext<PrintingHub> _printingContext;
        public PrintingHubClient(IHubContext<PrintingHub> printingContext)
        {
            _printingContext = printingContext;
        }
        public async Task Notify<T>(params T[] data)
        {
            await _printingContext.Clients.All.SendAsync("status", data);
        }

        public async Task Notify<T>(string groupName, T data)
        {
            await _printingContext.Clients.Group(groupName).SendAsync("printingStatus",data);
        }

        public async Task Notify<T>(T data)
        {
            await _printingContext.Clients.All.SendAsync("printingStatus", data);
        }
    }
}

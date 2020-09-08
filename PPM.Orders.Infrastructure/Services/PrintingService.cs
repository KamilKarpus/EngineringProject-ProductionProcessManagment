using PPM.Application.ModuleClient;
using PPM.Orders.Application.Configuration.Services;
using PPM.Orders.Application.ReadModels;
using PPM.Orders.Infrastructure.Services.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPM.Orders.Infrastructure.Services
{
    public class PrintingService : IPrintingService
    {
        private string _basePath = "internal/printing";
        private readonly IModuleClient _client;
        public PrintingService(IModuleClient client)
        {
            _client = client;
        }
        public async Task<List<PrintingDTO>> GetbyOrderId(Guid orderId)
        {
           return await _client.GetAsync<List<PrintingDTO>>(_basePath, string.Empty, new PrintingRequestDTO(orderId));
        }
    }
}

using PPM.Application;
using PPM.Printing.Application.Configuration.Services.Notify;
using System;
using System.Threading.Tasks;

namespace PPM.Printing.Infrastructure.Services
{
    public class PrintingNotifyService : IPrintingNotifyService
    {
        private readonly IHubClient _client;
        public PrintingNotifyService(IHubClient client)
        {
            _client = client;
        }
        public async Task Notify(Guid orderId,Guid packageId, string fileUrl)
        {
            await _client.Notify<PrintingDTO>(orderId.ToString(), new PrintingDTO()
            {
                PackageId = packageId,
                FileUrl = fileUrl
            });
        }
    }
}

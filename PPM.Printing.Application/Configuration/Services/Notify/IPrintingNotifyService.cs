using System;
using System.Threading.Tasks;

namespace PPM.Printing.Application.Configuration.Services.Notify
{
    public interface IPrintingNotifyService
    {
        Task Notify(Guid orderId,Guid packageId, string fileUrl);
    }
}

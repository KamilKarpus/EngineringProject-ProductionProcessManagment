using System;

namespace PPM.Printing.Application.Configuration.Services
{
    public class QrResult
    {
        public string FileUrl { get; private set; }
        public Guid PackageId { get; private set; }
        public Guid OrderId { get; private set; }
        public QrResult(string url, string filenName, Guid packageId, Guid orderId)
        {
            FileUrl = $"{url}/{filenName}";
            PackageId = packageId;
            OrderId = orderId;
        }
    }
}

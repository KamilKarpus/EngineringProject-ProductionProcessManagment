using System;

namespace PPM.Printing.Application.Configuration.Services
{
    public class QrCodeDTO
    {
        public Guid PackageId { get; set; }
        public Guid OrderId { get; set; }
    }
}

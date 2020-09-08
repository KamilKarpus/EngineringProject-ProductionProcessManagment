using PPM.Printing.Application.Configuration.Commands;
using System;

namespace PPM.Printing.Application.Commands.RequestPrinting
{
    public class RequestPrintingCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
    }
}

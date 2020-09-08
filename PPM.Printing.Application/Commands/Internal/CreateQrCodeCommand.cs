using PPM.Printing.Application.Configuration.Commands;
using System;

namespace PPM.Printing.Application.Commands.Internal
{
    public class CreateQrCodeCommand : ICommand
    {
        public Guid RequestId { get; set; }
    }
}

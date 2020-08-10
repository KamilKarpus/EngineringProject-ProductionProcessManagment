using PPM.Locations.Application.Configuration.Commands;
using System;

namespace PPM.Locations.Application.Commands.Transfer.FinishTransferRequest
{
    public class FinishTransferRequestCommand : ICommand
    {
        public Guid TransferId { get; set; }
    }
}

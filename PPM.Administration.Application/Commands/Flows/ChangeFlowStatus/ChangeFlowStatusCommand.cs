using PPM.Administration.Application.Configuration.Commands;
using System;

namespace PPM.Administration.Application.Commands.Flows.ChangeFlowStatus
{
    public class ChangeFlowStatusCommand : ICommand
    {
        public Guid FlowId { get; set; }
        public int StatusId { get; set; }
    }
}

using PPM.Administration.Application.Configuration.Commands;
using System;

namespace PPM.Administration.Application.Commands.Flows.ChangeStepPosition
{
    public class ChangeStepPositionCommnad : ICommand
    {
        public Guid FlowId { get; set; }
        public Guid StepId { get; set; }
        public int StepNumber { get; set; }
    }
}

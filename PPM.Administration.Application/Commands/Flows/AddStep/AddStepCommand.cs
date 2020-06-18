using PPM.Administration.Application.Configuration.Commands;
using System;

namespace PPM.Administration.Application.Commands.AddStep
{
    public class AddStepCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid ProductionFlowId { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
        public Guid LocationId { get; set; }
        public int Percentage { get; set; }
    }
}

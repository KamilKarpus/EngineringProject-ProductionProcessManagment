using PPM.Administration.Application.Configuration.Commands;
using System;

namespace PPM.Administration.Application.Commands
{
    public class AddProductionFlowCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

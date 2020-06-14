using MediatR;
using PPM.Administration.Application.Configuration.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Commands.AddStep
{
    public class AddStepCommandHandler : ICommandHandler<AddStepCommand>
    {
        public AddStepCommandHandler()
        {

        }
        public Task<Unit> Handle(AddStepCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

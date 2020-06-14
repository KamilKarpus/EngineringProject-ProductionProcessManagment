using MediatR;
using PPM.Administration.Application.Configuration.Commands;
using PPM.Administration.Domain.Exceptions;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Commands
{
    public class AddProductionFlowCommandHandler : ICommandHandler<AddProductionFlowCommand>
    {
        private readonly IProductionFlowRepository _repository;
        public AddProductionFlowCommandHandler(IProductionFlowRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(AddProductionFlowCommand request, CancellationToken cancellationToken)
        {
            var flow = await _repository.GetByName(request.Name);
            if(flow != null)
            {
                throw new FlowException("Flow name is taken", ErrorCodes.NameIsTaken);
            }
            var flowToAdd = new ProductionFlow(request.Id, request.Name);
            await _repository.AddAsync(flowToAdd);
            return Unit.Value;
        }
    }
}

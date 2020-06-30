using MediatR;
using PPM.Administration.Application.Configuration.Commands;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Commands.Flows.ChangeFlowStatus
{
    public class ChangeFlowStatusCommandHandler : ICommandHandler<ChangeFlowStatusCommand>
    {
        private readonly IProductionFlowRepository _repository;
        public ChangeFlowStatusCommandHandler(IProductionFlowRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ChangeFlowStatusCommand request, CancellationToken cancellationToken)
        {
            var flow = await _repository.GetById(request.FlowId);
            switch (request.StatusId)
            {
                case Status.ReadyToUseId:
                    flow.ReadyToUse();
                    break;
                case Status.ConstructionId:
                    flow.Construction();
                    break;
            }
            await _repository.Update(flow);
            return Unit.Value;
        }
    }
}

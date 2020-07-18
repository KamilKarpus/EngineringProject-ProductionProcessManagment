using MediatR;
using PPM.Administration.Application.Configuration.Commands;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Commands.Flows.ChangeStepPosition
{
    public class ChangeStepPositionCommandHandler : ICommandHandler<ChangeStepPositionCommnad>
    {
        private IProductionFlowRepository _repository;
        private IFirstLocationSupportPrinting _printingSupport;
        public ChangeStepPositionCommandHandler(IProductionFlowRepository repository,
            IFirstLocationSupportPrinting supportPrinting)
        {
            _repository = repository;
            _printingSupport = supportPrinting;
        }
        public async Task<Unit> Handle(ChangeStepPositionCommnad request, CancellationToken cancellationToken)
        {
            var flow = await _repository.GetById(request.FlowId);
            flow.ChangeStepPosition(request.StepId, request.StepNumber, _printingSupport);
            await _repository.Update(flow);
            return Unit.Value;
        }
    }
}

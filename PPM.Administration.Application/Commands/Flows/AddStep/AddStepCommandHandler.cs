using MediatR;
using PPM.Administration.Application.Configuration.Commands;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Commands.AddStep
{
    public class AddStepCommandHandler : ICommandHandler<AddStepCommand>
    {
        private readonly IProductionFlowRepository _repository;
        private readonly ILocationExistence _locationExistence;
        private readonly IFirstLocationSupportPrinting _supportPrinting;
        public AddStepCommandHandler(IProductionFlowRepository repository, ILocationExistence existence,
            IFirstLocationSupportPrinting supportPrinting)
        {
            _repository = repository;
            _locationExistence = existence;
            _supportPrinting = supportPrinting;
        }
   
        public async Task<Unit> Handle(AddStepCommand request, CancellationToken cancellationToken)
        {
            var flow = await _repository.GetById(request.ProductionFlowId);
            if (request == null)
            {
                //throw exception
            }
            flow.AddStep(request.Id, request.Name, request.Days, request.LocationId, request.Percentage, _locationExistence, _supportPrinting);
            await _repository.Update(flow);
            return Unit.Value;
        }
    }
}

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
        public AddStepCommandHandler(IProductionFlowRepository repository, ILocationExistence existence)
        {
            _repository = repository;
            _locationExistence = existence;
        }
   
        public async Task<Unit> Handle(AddStepCommand request, CancellationToken cancellationToken)
        {
            var flow = await _repository.GetById(request.ProductionFlowId);
            if (request == null)
            {
                //throw exception
            }
            flow.AddStep(request.Id, request.Name, request.Days, request.LocationId, request.Percentage, _locationExistence);
            await _repository.Update(flow);
            return Unit.Value;
        }
    }
}

using MediatR;
using PPM.Orders.Application.Configuration.Commands;
using PPM.Orders.Domain;
using PPM.Orders.Domain.Exceptions;
using PPM.Orders.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Commands.Orders.AddNewOrder
{
    public class AddNewOrderCommandHandler : ICommandHandler<AddNewOrderCommand>
    {
        private IOrderRepository _repository;
        private IProductionFlowRepository _productionFlowRepository;
        public AddNewOrderCommandHandler(IOrderRepository repository, IProductionFlowRepository productionRepository)
        {
            _repository = repository;
            _productionFlowRepository = productionRepository;
        }
        public async Task<Unit> Handle(AddNewOrderCommand request, CancellationToken cancellationToken)
        {
            var flow = await _productionFlowRepository.GetById(request.FlowId);
            if(flow == null)
            {
                throw new ProductionFlowException("Flow doesn't exists", ErrorCode.FlowDoesntExists);
            }
            var order = Order.Create(request.Id, request.CompanyName, request.DeliveryDate, flow);
            await _repository.AddAsync(order);
            return Unit.Value;

        }
    }
}

using MediatR;
using PPM.Domain.ValueObject;
using PPM.Orders.Application.Configuration.Commands;
using PPM.Orders.Domain.Exceptions;
using PPM.Orders.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Commands.Orders.AddPackage
{
    public class AddPackageCommandHandler : ICommandHandler<AddPackageCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IProductionFlowRepository _productionFlowRepository;
        public AddPackageCommandHandler(IOrderRepository repository, IProductionFlowRepository productionReposistory)
        {
            _repository = repository;
            _productionFlowRepository = productionReposistory;
        }
        public async Task<Unit> Handle(AddPackageCommand request, CancellationToken cancellationToken)
        {
            var flow = await _productionFlowRepository.GetById(request.FlowId);
            if (flow == null)
            {
                throw new ProductionFlowException("Flow doesn't exists", ErrorCode.FlowDoesntExists);
            }
            var order = await _repository.GetbyId(request.OrderId);
            if(order == null)
            {
                throw new OrderException("Order doesn't exists", ErrorCode.OrderDoesntExists);
            }
            order.AddPackage(request.PackageId, Kilograms.FromDecimal(request.Weight),Meters.FromDecimal(request.Height),
                Meters.FromDecimal(request.Length),Meters.FromDecimal(request.Width), flow);

            await _repository.Update(order);
            return Unit.Value;
        }
    }
}

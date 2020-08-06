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
        public AddPackageCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(AddPackageCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetbyId(request.FlowId);
            if(order == null)
            {
                throw new OrderException("Order doesn't exists", ErrorCode.OrderDoesntExists);
            }
            order.AddPackage(request.PackageId, Kilograms.FromDecimal(request.Weight), Meters.FromDecimal(request.Height),
                Meters.FromDecimal(request.Width));

            await _repository.Update(order);
            return Unit.Value;
        }
    }
}

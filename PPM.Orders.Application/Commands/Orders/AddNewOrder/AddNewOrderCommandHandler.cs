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
        public AddNewOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(AddNewOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Order.Create(request.Id, request.CompanyName, request.DeliveryDate, request.Description);
            await _repository.AddAsync(order);
            return Unit.Value;

        }
    }
}

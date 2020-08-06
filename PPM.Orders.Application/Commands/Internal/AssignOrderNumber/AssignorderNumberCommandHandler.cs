using MediatR;
using PPM.Orders.Application.Configuration.Commands;
using PPM.Orders.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Commands.Internal.AssignOrderNumber
{
    public class AssignorderNumberCommandHandler : ICommandHandler<AssignOrderNumberCommand>
    {
        private IOrderRepository _repository;
        public AssignorderNumberCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(AssignOrderNumberCommand request, CancellationToken cancellationToken)
        {
            var number = await  _repository.GetLastNumber();
            var order = await _repository.GetbyId(request.OrderId);
            order.AssignNumber(number.Next());
            await _repository.Update(order);

            return Unit.Value;
            
        }
    }
}

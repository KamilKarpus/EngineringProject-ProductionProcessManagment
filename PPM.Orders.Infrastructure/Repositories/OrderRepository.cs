using MongoDB.Driver;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.EventDispatcher;
using PPM.Orders.Domain;
using PPM.Orders.Domain.Repositories;
using PPM.Orders.Infrastructure.Documents.Orders;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoRepository<OrderDocument> _repository;
        private readonly IEventDispatcher _dispatcher;
        public OrderRepository(IMongoRepository<OrderDocument> repository,
            IEventDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }
        public async Task AddAsync(Order order)
        {
            await _repository.Add(order.ToDocument());
            await _dispatcher.DispatchAsync(order.DomainEvents.ToArray());
        }

        public async Task<Order> GetbyId(Guid id)
        {
            var result = await _repository.Find(p => p.Id == id);
            return result?.AsEntity();
        }

        public async Task<OrderNumber> GetLastNumber()
        {
            var result = _repository.Collection.AsQueryable().Where(p => p.NumberYear == DateTime.Now.Year)
                .Select(p => p.OrderNumber).ToList();
            int number = 0;
            if (result.Any())
            {
                number = result.DefaultIfEmpty(0).Max();
            }
            return OrderNumber.From(number);
        }

        public async Task Update(Order order)
        {
            await _repository.Update(p => p.Id == order.Id, order.ToDocument());
            await _dispatcher.DispatchAsync(order.DomainEvents?.ToArray());;
        }
    }
}

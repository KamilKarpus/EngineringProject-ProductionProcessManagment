using System;
using System.Threading.Tasks;
using PPM.Orders.Domain;

namespace PPM.Orders.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetbyId(Guid id);
        Task AddAsync(Order order);
        Task Update(Order oder);
        Task<OrderNumber> GetLastNumber();
    }
}

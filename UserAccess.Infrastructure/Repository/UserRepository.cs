using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.EventDispatcher;
using PPM.UserAccess.Domain.Users;
using PPM.UserAccess.Domain.Users.Repository;
using PPM.UserAccess.Infrastructure.Documents;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.UserAccess.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoRepository<UserDocument> _repository;
        private readonly IEventDispatcher _dispatcher;

        public UserRepository(IMongoRepository<UserDocument> repository,
            IEventDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }
        public async Task Add(User user)
        {
            await _repository.Add(user?.ToDocument());
            await _dispatcher.DispatchAsync(user?.DomainEvents.ToArray());
        }

        public async Task<User> GetByLogin(string login)
        {
            var result = await _repository.Find(p => p.Login == login);
            return result?.AsEntity();
        }

        public async Task<bool> Exists(string login)
        {
            var result = await _repository.ExistsAsync(p => p.Login == login);
            return result;
        }

        public async Task Update(User user)
        {
            await _repository.Update(p => p.Id == user.Id, user.ToDocument());
            await _dispatcher.DispatchAsync(user?.DomainEvents.ToArray());
        }

        public async Task<User> GetById(Guid id)
        {
            var result = await _repository.Find(p => p.Id == id);
            return result?.AsEntity();
        }
    }
}

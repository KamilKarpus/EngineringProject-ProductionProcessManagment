using PPM.Infrastructure.DataAccess.Repositories;
using PPM.UserAccess.Domain.Users;
using PPM.UserAccess.Domain.Users.Repository;
using PPM.UserAccess.Infrastructure.Documents;
using System.Threading.Tasks;

namespace PPM.UserAccess.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoRepository<UserDocument> _repository;
        public UserRepository(IMongoRepository<UserDocument> repository)
        {
            _repository = repository;
        }
        public async Task Add(User user)
        {
            await _repository.Add(user?.ToDocument());
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
    }
}

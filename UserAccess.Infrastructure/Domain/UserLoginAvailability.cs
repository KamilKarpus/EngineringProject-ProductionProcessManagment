using PPM.UserAccess.Domain.Users;
using PPM.UserAccess.Domain.Users.Repository;

namespace PPM.UserAccess.Infrastructure.Domain
{
    public class UserLoginAvailability : IUserLoginAvailability
    {
        private readonly IUserRepository _repository;
        public UserLoginAvailability(IUserRepository repository)
        {
            _repository = repository;
        }
        public bool isAvailable(string login)
        {
            var result = _repository.Exists(login);
            result.Wait();
            return result.Result;
        }
    }
}

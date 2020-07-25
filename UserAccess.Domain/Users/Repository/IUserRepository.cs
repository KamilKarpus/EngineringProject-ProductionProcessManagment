using System.Linq;
using System.Threading.Tasks;

namespace PPM.UserAccess.Domain.Users.Repository
{
    public interface IUserRepository
    {
        public Task Add(User user);
        public Task<User> GetByLogin(string login);
        public Task<bool> Exists(string login);
    }
}

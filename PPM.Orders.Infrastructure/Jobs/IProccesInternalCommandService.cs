using System.Threading.Tasks;

namespace PPM.Orders.Infrastructure.Jobs
{
    public interface IProccesInternalCommandService
    {
        Task Proccess();
    }
}
using System.Threading.Tasks;

namespace PPM.Application
{
    public interface IHubClient
    {
        Task Notify<T>(params T[] data);
        Task Notify<T>(string groupName, T data);
        Task Notify<T>(string resource, string groupName, T data);
        Task Notify<T>(T data);
        Task NotifyResource<T>(string resource, T data);
    }
}

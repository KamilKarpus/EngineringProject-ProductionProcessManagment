using PPM.Infrastructure.Paggination;
using PPM.UserAccess.Application.Configuration.Queries;
using PPM.UserAccess.Application.ReadModels;

namespace PPM.UserAccess.Application.GetUserList
{
    public class GetUserListQuery : IQuery<PagedList<UserShortViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

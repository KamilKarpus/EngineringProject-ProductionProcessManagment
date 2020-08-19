using PPM.UserAccess.Application.Configuration.Queries;
using PPM.UserAccess.Application.ReadModels;
using System;

namespace PPM.UserAccess.Application.GetUserInfoById
{
    public class GetUserInfoByIdQuery : IQuery<UserReadModel>
    {
        public Guid UserId { get; set; }
    }
}

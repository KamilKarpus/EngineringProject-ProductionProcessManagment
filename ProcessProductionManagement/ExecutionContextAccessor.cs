using Microsoft.AspNetCore.Http;
using PPM.Application;
using System;
using System.Linq;

namespace PPM.Api
{
    public class ExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid UserId { 
            get 
            {
                if (_httpContextAccessor
                                        .HttpContext?
                                        .User?
                                        .Claims?
                                        .SingleOrDefault(x => x.Type == "sub")?
                                        .Value != null)

                {
                    return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == "sub").Value);

                }

                throw new ApplicationException("User context is not available");
            }
        }
    }
}

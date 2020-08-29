using System;

namespace PPM.Application
{
    public interface IExecutionContextAccessor
    {
        Guid UserId { get; }
    }
}

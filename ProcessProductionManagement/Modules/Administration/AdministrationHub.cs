using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Api.Modules.Administration
{
    [Authorize]
    public class AdministrationHub : Hub
    {
    }
}

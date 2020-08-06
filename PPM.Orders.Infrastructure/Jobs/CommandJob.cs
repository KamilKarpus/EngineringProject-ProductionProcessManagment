using Autofac;
using PPM.Orders.Infrastructure.Configuration;
using Quartz;
using System.Threading.Tasks;

namespace PPM.Orders.Infrastructure.Jobs
{
    [DisallowConcurrentExecution]
    public class CommandJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            using(var scope = OrderCompositionRoot.BeginLifetimeScope())
            {
                var proccesor = scope.Resolve<IProccesInternalCommandService>();
                await proccesor.Proccess();
            }
        }
    }
}

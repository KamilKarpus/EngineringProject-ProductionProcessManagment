using Autofac;
using PPM.Printing.Infrastructure.Configuration;
using Quartz;
using System.Threading.Tasks;

namespace PPM.Printing.Infrastructure.Jobs
{
    [DisallowConcurrentExecution]
    public class CommandJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            using(var scope = PrintingCompositionRoot.BeginLifetimeScope())
            {
                var proccesor = scope.Resolve<IProccesInternalCommandService>();
                await proccesor.Proccess();
            }
        }
    }
}

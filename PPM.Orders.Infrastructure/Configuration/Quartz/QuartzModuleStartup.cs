using PPM.Orders.Infrastructure.Jobs;
using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;

namespace PPM.Orders.Infrastructure.Configuration.Quartz
{
    internal static class QuartzModuleStartup
    {
        internal static  void Initialize()
        {
            var schedulerConfiguration = new NameValueCollection();
            schedulerConfiguration.Add("quartz.scheduler.instanceName", "Orders");

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(schedulerConfiguration);
            IScheduler scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            scheduler.Start().GetAwaiter().GetResult();

            var commandJob = JobBuilder.Create<CommandJob>().Build();
            var trigger =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/2 * * ? * *")
                    .Build();

            scheduler
                .ScheduleJob(commandJob, trigger)
                .GetAwaiter().GetResult();
        }
    }
}

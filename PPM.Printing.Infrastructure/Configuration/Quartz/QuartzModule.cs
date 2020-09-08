using Autofac;
using Autofac.Extras.Quartz;
using PPM.Printing.Infrastructure.Jobs;
using Quartz;

namespace PPM.Printing.Infrastructure.Configuration.Quartz
{
    public class QuartzModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProccesInternalCommandService>()
                .As<IProccesInternalCommandService>()
                .SingleInstance();

            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(CommandJob).Assembly));

        }
    }
}

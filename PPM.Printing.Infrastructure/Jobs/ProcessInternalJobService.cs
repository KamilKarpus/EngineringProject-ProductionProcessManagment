using Autofac;
using MediatR;
using Newtonsoft.Json;
using Polly;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.InternalCommands;
using PPM.Orders.Infrastructure.Configuration;
using System;
using System.Threading.Tasks;

namespace PPM.Printing.Infrastructure.Jobs
{
    public class ProccesInternalCommandService : IProccesInternalCommandService
    {
        private readonly IMongoRepository<InternalCommand> _repository;
        public ProccesInternalCommandService(IMongoRepository<InternalCommand> repository)
        {
            _repository = repository;
        }
        public async Task Proccess()
        {
            var commands = await _repository.FindMany(p => p.ProcessedDate == DateTime.MinValue);
            var policy = Policy
               .Handle<Exception>()
               .WaitAndRetryAsync(new[]
               {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(3)
               });
            foreach (var command in commands)
            {
                var result = await policy.ExecuteAndCaptureAsync(() => ProcessCommand(
                   command));
                if (result.Outcome == OutcomeType.Failure)
                {
                    command.Error = result.FinalException.ToString();
                    await _repository.Update(p => p.Id == command.Id, command);
                }
                if (result.Outcome == OutcomeType.Successful)
                {
                    command.ProcessedDate = DateTime.Now;
                    await _repository.Update(p => p.Id == command.Id, command);
                }
            }
        }
    
        private async Task ProcessCommand(
            InternalCommand internalCommand)
        {
            Type type = Assemblies.Application.GetType(internalCommand.Type);
            dynamic commandToProcess = JsonConvert.DeserializeObject(internalCommand.Data, type);
    
            using (var scope = OrderCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(commandToProcess);
            }
        }
    }
}


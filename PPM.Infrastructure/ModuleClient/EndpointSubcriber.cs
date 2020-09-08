using MediatR;
using PPM.Application.ModuleClient.Endpoints;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Infrastructure.ModuleClient
{
    public sealed class EndpointSubcriber
    {
        private List<EndpointDefinition> _endpointDefinitions;
        private Dictionary<string, IMediator> _endpointsDispatchers;
        public static EndpointSubcriber Instance { get; } = new EndpointSubcriber();
        public EndpointSubcriber()
        {
            _endpointDefinitions = new List<EndpointDefinition>();
            _endpointsDispatchers = new Dictionary<string, IMediator>();
        }


        public void AddEndpointDispatcher(string basepath, IMediator mediator)
           => _endpointsDispatchers.Add(basepath, mediator);

        public IMediator GetEndPointDispatcher(string basepath)
            => _endpointsDispatchers[basepath];

        public void AddEndpointDefination<parameter, result>(string path, string method)
          =>
             _endpointDefinitions.Add(
                new EndpointDefinition()
                {
                    Method = method,
                    Paramater = new EndpointParamater
                    {
                        Name = typeof(parameter).Name,
                        Type = typeof(parameter)
                    },
                    Response = new EndpointResponse
                    {
                        Name = typeof(result).Name,
                        Type = typeof(result)
                    },
                    Path = path
                });

        public EndpointDefinition GetEndpointDefinition(string path)
            => _endpointDefinitions.FirstOrDefault(p => p.Path == path);


    }
}

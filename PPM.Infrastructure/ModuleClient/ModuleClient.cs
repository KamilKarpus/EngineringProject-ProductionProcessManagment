using MediatR;
using Newtonsoft.Json;
using PPM.Application.ModuleClient;
using System;
using System.Threading.Tasks;

namespace PPM.Infrastructure.ModuleClient
{
    public class ModuleClient : IModuleClient
    {
        public async Task<TResult> GetAsync<TResult>(string path, string restofpath, object request) where TResult : class
        {
            var fullpath = path + restofpath;
            var endpointInfo = EndpointSubcriber.Instance.GetEndpointDefinition(fullpath);

            if (endpointInfo is null)
            {
                throw new InvalidOperationException($"No action has been defined for path: {fullpath}");

            }

            var dispatcher = EndpointSubcriber.Instance.GetEndPointDispatcher(path);

            if (dispatcher is null)
            {
                throw new InvalidOperationException($"No dispatcher has been defined for path: {fullpath}");
            }

            var receiverRequest = TranslateType(request, endpointInfo.Paramater.Type);

            var result = await dispatcher.Send(receiverRequest);

            return (TResult)TranslateType(result, typeof(TResult));
        }

        public void AddEndpointDefination<parameter, result>(string path, string method)
        {
            EndpointSubcriber.Instance.AddEndpointDefination<parameter, result>(path, method);
        }

        public void AddEndpointDispatcher(string path, IMediator mediator)
            => EndpointSubcriber.Instance.AddEndpointDispatcher(path, mediator);



        private object TranslateType(object @object, Type type)
        {
            var json = JsonConvert.SerializeObject(@object);
            var receiverType = JsonConvert.DeserializeObject(json, type);
            return receiverType;
        }
    }
}

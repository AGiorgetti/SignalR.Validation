using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SignalR.Validation
{
    /// <summary>
    /// primo approccio ad un pipeline module per la validazione su signalr usando data annotations
    /// </summary>
    public class ValidationModule : HubPipelineModule
    {
        private readonly ConcurrentDictionary<MethodDescriptor, IEnumerable<IValidateHubMethodInvocation>> _methodInvocationCache = new ConcurrentDictionary<MethodDescriptor,IEnumerable<IValidateHubMethodInvocation>>();

        public override Func<IHubIncomingInvokerContext, Task<object>> BuildIncoming(Func<IHubIncomingInvokerContext, Task<object>> invoke)
        {
            return base.BuildIncoming(context =>
            {
                // Get method attributes implementing IValidateHubMethodInvocation from the cache
                // If the attributes do not exist in the cache, retrieve them from the MethodDescriptor and add them to the cache
                var methodLevelValidator = _methodInvocationCache.GetOrAdd(context.MethodDescriptor,
                    methodDescriptor => methodDescriptor.Attributes.OfType<IValidateHubMethodInvocation>()).FirstOrDefault();

                // no validator... keep going on with the rest of the pipeline
                if (methodLevelValidator == null)
                    return invoke(context);

                var validationErrors = methodLevelValidator.ValidateHubMethodInvocation(context);
                // no errors... keep going on with the rest of the pipeline
                if (validationErrors.Count() == 0)
                    return invoke(context);

                string errorsInJson = JsonConvert.SerializeObject(validationErrors);

                // Send error back to the client
                return FromError<object>(new ValidationException(String.Format("ValidationError|{0}.", errorsInJson)));
            });
        }

        private static Task<T> FromError<T>(Exception e)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetException(e);
            return tcs.Task;
        }
    }
}

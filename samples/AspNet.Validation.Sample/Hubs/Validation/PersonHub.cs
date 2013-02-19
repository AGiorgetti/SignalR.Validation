using Microsoft.AspNet.SignalR;
using SignalR.Validation;

namespace AspNet.Validation.Sample.Hubs.Validation
{
    public class PersonHub : Hub
    {
        [Validate]
        public bool FuncWithValidation(Person person)
        {
            // do nothing, just to check if validation get called successfully
            return true;
        }

        public bool FuncWithoutValidation(Person person)
        {
            // do nothing, just to check if validation get called successfully
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
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